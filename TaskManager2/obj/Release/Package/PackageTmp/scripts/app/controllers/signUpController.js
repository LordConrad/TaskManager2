﻿(function() {
    angular.module('app.controllers').controller('signUpController', [
        '$scope',
        '$location',
        '$timeout',
        'authService',
        function($scope, $location, $timeout, authService) {
            var startTimer = function () {
                var timer = $timeout(function () {
                    $timeout.cancel(timer);
                    $location.path('/login');
                }, 2000);
            };

            $scope.savedSuccessfully = false;
            $scope.message = '';

            $scope.registration = {
                username: '',
                password: '',
                confirmPassword: ''
            };

            $scope.signUp = function() {
                authService.saveRegistration($scope.registration).then(function(response) {
                        $scope.savedSuccessfully = true;
                        $scope.message = "Пользователь создан";
                        startTimer();
                    },
                    function(response) {
                        var errors = [];
                        for (var key in response.data.modelState) {
                            for (var i = 0; i < response.data.modelState[key].length; i++) {
                                errors.push(response.data.modelState[key][i]);
                            }
                        }
                        $scope.message = "Ошибка при создании пользователя: " + errors.join(' ');
                    });
            };

            
        }
    ]);
})();
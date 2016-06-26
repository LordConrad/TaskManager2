(function() {
    angular.module('app.controllers').controller('loginController', [
        '$scope',
        '$location',
        'authService',
        function($scope, $location, authService) {
            $scope.loginData = {
                username: '',
                password: ''
            };

            $scope.flip = function () {
                $scope.message = '';
                $scope.flipped = !$scope.flipped;
            };

            $scope.message = '';
            $scope.loading = false;

            $scope.login = function () {
                $scope.loading = true;
                authService.login($scope.loginData).then(function (response) {
                    $scope.loading = false;
                    $location.path('/profile');
                }, function (err) {
                    $scope.loading = false;
                    if (err == null) {
                        $scope.message = 'Сервер недоступен';
                    } else {
                        $scope.message = err.error_description;
                    }
                });
            }

            $scope.registration = {
                username: '',
                fullname: '',
                password: '',
                confirmPassword: ''
            };

            $scope.signUp = function () {
                $scope.message = '';
                authService.saveRegistration($scope.registration).then(function(response) {
                        $scope.message = "Пользователь создан";
                        $scope.flip();
                        $scope.loginData.username = $scope.registration.username;
                        $scope.loginData.password = $scope.registration.password;
                    },
                    function(response) {
                        var errors = [];
                        for (var key in response.data.modelState) {
                            for (var i = 0; i < response.data.modelState[key].length; i++) {
                                errors.push(response.data.modelState[key][i]);
                            }
                        }
                        $scope.message = errors[0];
                    });
            };
        }
    ]);
})();
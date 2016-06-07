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

            $scope.login = function() {
                authService.login($scope.loginData).then(function(response) {
                    $location.path('/recipientTasks');
                }, function(err) {
                    //$scope.message = err.error_description;
                });
            }
        }
    ]);
})();
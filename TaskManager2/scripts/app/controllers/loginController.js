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

            $scope.message = '';
            $scope.loading = false;

            $scope.login = function () {
                $scope.loading = true;
                authService.login($scope.loginData).then(function (response) {
                    $scope.loading = false;
                    $location.path('/recipientTasks');
                }, function (err) {
                    $scope.loading = false;
                    if (err == null) {
                        $scope.message = 'Сервер недоступен';
                    } else {
                        $scope.message = err.error_description;
                    }
                });
            }
        }
    ]);
})();
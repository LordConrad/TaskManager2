(function() {
    angular.module('app.controllers').controller('navbarController', [
        '$scope',
        'authService',
        function ($scope, authService) {
            $scope.isAuth = function() {
                return authService.authData.isAuth;
            };

            $scope.userId = function() {
                return authService.authData.userId;
            };

            $scope.fullName = function() {
                return authService.authData.username;
            };

            $scope.logOut = function() {
                authService.logOut();
            };
        }
    ]);
})();
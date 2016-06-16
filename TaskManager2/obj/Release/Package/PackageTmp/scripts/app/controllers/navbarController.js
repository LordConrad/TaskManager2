(function() {
    angular.module('app.controllers').controller('navbarController', [
        '$scope',
        'authService',
        '$location',
        function ($scope, authService, $location) {
            $scope.isAuth = function() {
                return authService.authData.isAuth;
            };

            $scope.isActive = function (viewLocation) {
                return viewLocation === $location.path();
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
(function() {
    angular.module('app.controllers').controller('navbarController', [
        '$scope',
        'authService',
        '$location',
        'viewsRoot',
        function ($scope, authService, $location, viewsRoot) {
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

            $scope.recipientTasksUrl = viewsRoot + '/#/recipientTasks';
            $scope.exchangeUrl = viewsRoot + '/#/exchange';
        }
    ]);
})();
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

            $scope.isSender = function() {
                return authService.authData.userRoles.indexOf('Sender') !== -1;
            }

            $scope.isRecipient = function () {
                return authService.authData.userRoles.indexOf('Recipient') !== -1;
            }

            $scope.isChief = function () {
                return authService.authData.userRoles.indexOf('Chief') !== -1;
            }

            $scope.recipientTasksUrl = viewsRoot + '/#/recipientTasks';
            $scope.senderTasksUrl = viewsRoot + '/#/senderTasks';
            $scope.unassignedTasksUrl = viewsRoot + '/#/unassignedTasks';
            $scope.exchangeUrl = viewsRoot + '/#/exchange';
            $scope.profileUrl = viewsRoot + '/#/profile/' + authService.authData.userId;
        }
    ]);
})();

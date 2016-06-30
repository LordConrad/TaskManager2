(function() {
    angular.module('app.controllers').controller('profileController', [
        '$scope',
        'authService',
        '$location',
        function ($scope, authService, $location) {
            var backupValues = {};

            $scope.setEditField = function (propertyName) {
                backupValues[propertyName] = $scope.profileInfo[propertyName].value;
                $scope.profileInfo[propertyName].isEdit = true;
            }

            $scope.cancelEditField = function (propertyName) {
                $scope.profileInfo[propertyName].value = backupValues[propertyName];
                $scope.profileInfo[propertyName].isEdit = false;
            }

            $scope.acceptEditField = function(propertyName) {
                $scope.profileInfo[propertyName].isEdit = false;
            }

            if (authService.authData.isAuth) {
                $scope.profileInfo = {
                    username: {
                        value: authService.authData.username,
                        isEdit: false
                    }
                };

                $scope.name = authService.authData.username;
            } else {
                $location.path('/login');
            }

            
        }
    ]);
})();
(function() {
    angular.module('app.controllers').controller('myProfileController', [
        '$scope',
        'authService',
        '$location',
        function ($scope, authService, $location) {
            if (authService.authData.isAuth) {
                $scope.name = authService.authData.username;
            } else {
                $location.path('/login');
            }
        }
    ]);
})();
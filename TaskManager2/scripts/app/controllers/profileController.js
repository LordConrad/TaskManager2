(function() {
    angular.module('app.controllers').controller('profileController', [
        '$scope',
        'authService',
        '$location',
        function ($scope, authService, $location) {


            if (authService.authData.isAuth) {

                var profileInfo;
                authService.getUserProfile(authService.authData.userId).then(function(response) {
                    profileInfo = response;
                });

                $scope.profileInfo = {
                    username: {
                        title: 'Имя пользователя',
                        value: authService.authData.username
                    }
                };

                $scope.name = authService.authData.username;
            } else {
                $location.path('/login');
            }

            
        }
    ]);
})();
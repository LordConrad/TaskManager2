(function () {
    angular.module('app.controllers').controller('profileController', [
        '$scope',
        'authService',
        '$location',
        function ($scope, authService, $location) {


            if (authService.authData.isAuth) {

                var profileInfo;
                authService.getUserProfile(authService.authData.userId).then(function (response) {
                    profileInfo = response.data;

                    $scope.profileInfo = {
                        username: {
                            title: 'Имя пользователя',
                            value: profileInfo.fullName
                        },
                        location: {
                            title: 'Кабинет',
                            value: profileInfo.location
                        }
                    };

                    $scope.name = profileInfo.fullName;
                });
            } else {
                $location.path('/login');
            }


        }
    ]);
})();
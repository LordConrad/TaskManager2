(function () {
    angular.module('app.controllers').controller('profileController', [
        '$scope',
        'authService',
        'profileService',
        '$location',
        function ($scope, authService, profileService, $location) {
            var saveField = function(title, newValue) {
                profileService.updateProfile(title, newValue);
            };
            if (authService.authData.isAuth) {

                var profileInfo;
                authService.getUserProfile(authService.authData.userId).then(function (response) {
                    profileInfo = response.data;

                    $scope.profileInfo = {
                        username: {
                            title: 'Имя пользователя',
                            value: profileInfo.fullName,
                            saveMethod: saveField
                        },
                        location: {
                            title: 'Кабинет',
                            value: profileInfo.location,
                            saveMethod: saveField
                        },
                        sex: {
                            title: 'Пол',
                            value: profileInfo.sex,
                            saveMethod: saveField
                        },
                        position: {
                            title: 'Должность',
                            value: profileInfo.position,
                            saveMethod: saveField
                        },
                        workPhoneNumber: {
                            title: 'Рабочий телефон',
                            value: profileInfo.workPhoneNumber,
                            saveMethod: saveField
                        },
                        cellPhoneNumber: {
                            title: 'Мобильный телефон',
                            value: profileInfo.cellPhoneNumber,
                            saveMethod: saveField
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
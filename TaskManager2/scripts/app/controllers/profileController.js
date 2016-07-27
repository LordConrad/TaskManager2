(function () {
    angular.module('app.controllers').controller('profileController', [
        '$scope',
        'authService',
        'profileService',
        '$location',
        '$routeParams',
        function ($scope, authService, profileService, $location, $routeParams) {
            var saveField = function(title, newValue) {
                profileService.updateProfile(title, newValue);
            };

            var currentUserId = authService.authData.userId;
            var userId = $routeParams.id;

            if (authService.authData.isAuth) {

                var profileInfo;
                authService.getUserProfile(userId).then(function (response) {
                    profileInfo = response.data;

                    $scope.profileInfo = {
                        username: {
                            title: 'Имя пользователя',
                            value: profileInfo.fullName,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
                        },
                        location: {
                            title: 'Кабинет',
                            value: profileInfo.location,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
                        },
                        sex: {
                            title: 'Пол',
                            value: profileInfo.sex,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
                        },
                        position: {
                            title: 'Должность',
                            value: profileInfo.position,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
                        },
                        workPhoneNumber: {
                            title: 'Рабочий телефон',
                            value: profileInfo.workPhoneNumber,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
                        },
                        cellPhoneNumber: {
                            title: 'Мобильный телефон',
                            value: profileInfo.cellPhoneNumber,
                            saveMethod: saveField,
                            isEditable: userId === currentUserId
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
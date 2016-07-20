(function() {
    angular.module('app.services').factory('profileService', [
        '$http',
        '$rootScope',
        'apiRoot',
        'authService',
        function($http, $rootScope, apiRoot, authService) {
            var updateProfile = function (title, newValue) {
                    $rootScope.loading = true;
                    return $http({
                        method: 'POST',
                        url: apiRoot + '/account/updateProfile',
                        data: JSON.stringify({
                            title: title,
                            newValue: newValue,
                            userId: authService.authData.userId
                        })
                    }).success(function (response) {
                        return response;
                    }).finally(function () {
                        $rootScope.loading = false;
                    });
            }
            return {
                updateProfile: updateProfile
            };
        }
    ]);
})();
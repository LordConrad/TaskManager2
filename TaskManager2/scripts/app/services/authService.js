(function() {
    angular.module('app.services').factory('authService', [
        '$http',
        '$q',
        'localStorageService',
        '$location',
        '$rootScope',
        function($http, $q, localStorageService, $location, $rootScope) {
            var serviceHostUrl = 'http://localhost:1135';
            var authServiceFactory = {};
            var authentication = {
                isAuth: false,
                login: '',
                username: '',
                userId: '',
                userRoles: []
            };

            var updateAuthData = function () {
                var authData = localStorageService.get('authorizationData');
                if (authData) {
                    authentication.isAuth = true;
                    authentication.username = authData.username;
                    authentication.userId = authData.userId;
                    authentication.userRoles = authData.userRoles;
                    authentication.login = authData.login;
                }
            };

            var clearAuthData = function () {
                localStorageService.remove('authorizationData');
                authentication.isAuth = false;
                authentication.login = "";
                authentication.username = "";
                authentication.userId = "";
                authentication.userRoles = [];
            };

            var logOut = function () {
                clearAuthData();
                $location.path('/login');
            }

            var saveRegistration = function(registration) {
                clearAuthData();
                $rootScope.loading = true;
                return $http.post(serviceHostUrl + '/api/account/register', registration).then(function(response) {
                    $rootScope.loading = false;
                    return response;
                });
            };

            var login = function(loginData) {
                var data = "grant_type=password&username=" + loginData.username + '&password=' + loginData.password;
                var deffered = $q.defer();
                $http.post(serviceHostUrl + '/token', data, {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                }).success(function (response) {
                    authentication.isAuth = true;
                    authentication.userId = response.userId;
                    authentication.login = response.login;
                    authentication.username = response.username;
                    authentication.userRoles = response.userRoles;
                    localStorageService.set('authorizationData', {
                        token: response.access_token,
                        username: response.username,
                        login: response.login,
                        userId: response.userId,
                        userRoles: response.userRoles
                    });
                    deffered.resolve(response);
                }).error(function(err, status) {
                    clearAuthData();
                    deffered.reject(err);
                }).finally(function (parameters) {
                    updateAuthData();
                });
                return deffered.promise;
            };

            

            updateAuthData();

            authServiceFactory.saveRegistration = saveRegistration;
            authServiceFactory.login = login;
            authServiceFactory.logOut = logOut;
            authServiceFactory.updateAuthData = updateAuthData;
            authServiceFactory.authData = authentication;

            return authServiceFactory;
        }
    ]);
})();
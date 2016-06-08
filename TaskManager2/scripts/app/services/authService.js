(function() {
    angular.module('app.services').factory('authService', [
        '$http',
        '$q',
        'localStorageService',
        function($http, $q, localStorageService) {
            var serviceHostUrl = 'http://localhost:1135';
            var authServiceFactory = {};
            var authentication = {
                isAuth: false,
                username: ''
            };

            var logOut = function () {
                localStorageService.remove('authorizationData');
                authentication.isAuth = false;
                authentication.username = "";
            };

            var saveRegistration = function(registration) {
                logOut();

                return $http.post(serviceHostUrl + '/api/account/register', registration).then(function(response) {
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
                    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.username });
                    authentication.isAuth = true;
                    authentication.username = loginData.username;
                    deffered.resolve(response);
                }).error(function(err, status) {
                    logOut();
                    deffered.reject(err);
                });
                return deffered.promise;
            };

            var fillAuthData = function() {
                var authData = localStorageService.get('authorizationData');
                if (authData) {
                    authentication.isAuth = true;
                    authentication.username = authData.username;
                }
            };

            authServiceFactory.saveRegistration = saveRegistration;
            authServiceFactory.login = login;
            authServiceFactory.logOut = logOut;
            authServiceFactory.fillAuthData = fillAuthData;
            authServiceFactory.authentication = authentication;

            return authServiceFactory;
        }
    ]);
})();
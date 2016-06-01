(function() {
    angular.module('app.services').factory('authService', [
        '$http',
        '$q',
        'localStorageService',
        function($http, $q, localStorageService) {
            var serviceHostUrl = 'http://localhost:1135';
            var authServiceFactory = {};
            var _authentication = {
                isAuth: false,
                username: ''
            };

            var _saveRegistration = function(registration) {
                _logOut();

                return $http.post(serviceHostUrl + '/api/account/register', registration).then(function(response) {
                    return response;
                });
            };

            var _login = function(loginData) {
                var data = "grant_type=password&username=" + loginData.username + '&password=' + loginData.password;
                var deffered = $q.defer();

                $http.post(serviceHostUrl + '/token', data, {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                }).success(function(response) {
                    _authentication.isAuth = true;
                    _authentication.username = loginData.username;
                    deffered.resolve(response);
                }).error(function(err, status) {
                    _logOut();
                    deffered.reject(err);
                });
                return deffered.promise;
            };

            var _logOut = function() {
                localStorageService.remove('authorizationData');
                _authentication.isAuth = false;
                _authentication.username = "";
            };

            var _fillAuthData = function() {
                var authData = localStorageService.get('authorizationData');
                if (authData) {
                    _authentication.isAuth = true;
                    _authentication.username = authData.username;
                }
            };

            authServiceFactory.saveRegistration = _saveRegistration;
            authServiceFactory.login = _login;
            authServiceFactory.logOut = _logOut;
            authServiceFactory.fillAuthData = _fillAuthData;
            authServiceFactory.authentication = _authentication;

            return authServiceFactory;
        }
    ]);
})();
(function() {
    angular.module('app.services').factory('exchangeService', [
        '$http',
        '$rootScope',
            function($http, $rootScope) {
                var serviceHostUrl = 'http://localhost:1135';

                var getCurrencyRates = function (date) {
                    $rootScope.loading = true;
                    return $http({
                        method: 'POST',
                        url: serviceHostUrl + '/api/getExchangeRates',
                        data: JSON.stringify({ date: date })
                    }).success(function(response, status) {
                        return response;
                    }).error(function(err, status) {
                        return err;
                    }).finally(function() {
                        $rootScope.loading = false;
                    });
                };

                return {
                    getCurrencyRates: getCurrencyRates
                };
            }
        ]);
})();
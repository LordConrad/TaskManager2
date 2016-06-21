(function() {
    angular.module('app.services').factory('exchangeService', [
        '$http',
        '$rootScope',
        'apiRoot',
            function($http, $rootScope, apiRoot) {

                var getCurrencyRates = function (date) {
                    $rootScope.loading = true;
                    return $http({
                        method: 'POST',
                        url: apiRoot + '/getExchangeRates',
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
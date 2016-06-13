(function() {
    angular.module('app.services').factory('exchangeService', [
        '$soap',
            function($soap) {
                var exchangeServiceUrl = 'http://www.nbrb.by/Services/ExRates.asmx';

                var getCurrenciesInfo = function() {
                    $soap.post(exchangeServiceUrl, 'ExRatesDaily2', { onDate: '2016-06-13' });
                };

                return {
                    getCurrenciesInfo: getCurrenciesInfo
                };
            }
        ]);
})();
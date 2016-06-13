(function() {
    angular.module('app.controllers').controller('exchangeController', [
        '$scope',
        'exchangeService',
        function($scope, exchangeService) {
            exchangeService.getCurrencyRates('13.06.2016').then(function(response) {
                $scope.data = response.data;
            });
        }
    ]);
})();
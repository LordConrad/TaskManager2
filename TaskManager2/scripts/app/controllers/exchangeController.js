(function() {
    angular.module('app.controllers').controller('exchangeController', [
        '$scope',
        'exchangeService',
        function($scope, exchangeService) {
            exchangeService.getCurrenciesInfo().then(function(response) {
                var res = response;
            });
        }
    ]);
})();
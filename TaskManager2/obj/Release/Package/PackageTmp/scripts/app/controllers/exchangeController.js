(function() {
    angular.module('app.controllers').controller('exchangeController', [
        '$scope',
        'exchangeService',
        function ($scope, exchangeService) {
            var currenciesArray = ['RUB', 'EUR', 'USD'];
            
            $scope.currencyFilter = function(cur) {
                return currenciesArray.indexOf(cur.currencyAbbreviation) > -1;
            }

            $scope.$watch('dt', function(newDate) {
                updateRates();
            });


            $scope.today = function () {
                $scope.dt = new Date();
            };
            $scope.today();

            $scope.clear = function () {
                $scope.dt = null;
            };

            $scope.options = {
                minDate: new Date(1997, 02, 17, 0, 0, 0, 0),
                maxDate: new Date(),
                showWeeks: false
            };

            // Disable weekend selection
            function disabled(data) {
                var date = data.date,
                  mode = data.mode;
                return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
            }
            
            $scope.setDate = function (year, month, day) {
                $scope.dt = new Date(year, month, day);
            };

            function updateRates() {
                exchangeService.getCurrencyRates($scope.dt).then(function (response) {
                    $scope.currencies = response.data;
                });
            }


        }
    ]);
})();
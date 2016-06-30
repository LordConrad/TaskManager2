(function() {
    var app = angular.module('app').directive('flipper', function() {
        return {
            restrict: 'E',
            template: '<div class="flipper" ng-transclude ng-class="{flipped: flipped}"></div>',
            transclude: true,
            scope: {
                flipped: '='
            }
        }
    });

    app.directive('front', function() {
        return {
            restrict: 'E',
            template: '<div class="front" ng-transclude></div>',
            transclude: true
        }
    });

    app.directive('back', function () {
        return {
            restrict: 'E',
            template: '<div class="back" ng-transclude></div>',
            transclude: true
        }
    });

})();
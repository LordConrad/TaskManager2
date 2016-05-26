var app = angular.module('app',
    [
        'ngRoute',
        'ui.bootstrap',
        'app.controllers',
        'angularSpinners',
        'app.spinnerService',
        'ngTable',
        'ngResource'
    ]);

angular.module('app.controllers', []);
angular.module('app.spinnerService', []);
angular.module('angularSpinners', []);

app.config([
    '$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
        $routeProvider.
            when('/myTasks', {
                templateUrl: 'scripts/app/views/myTasks.html',
                controller: 'myTasksController'
            }).
            otherwise({
                redirectTo: '/myTasks'
            });
    }

]);

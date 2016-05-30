(function () {
    var app = angular.module('app',
        [
            'ngRoute',
            'ui.bootstrap',
            'app.controllers',
            'angularSpinners',
            'app.services',
            'ngTable',
            'ngResource'
        ]);

    angular.module('app.controllers', []);
    angular.module('app.services', []);
    angular.module('angularSpinners', []);

    app.config([
        '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $routeProvider.
                when('/myTasks', {
                    templateUrl: 'scripts/app/views/myTasks.html',
                    controller: 'myTasksController'
                }).
                when('/recipientTask/:taskId', {
                    templateUrl: 'scripts/app/views/recipientTask.html',
                    controller: 'recipientTaskController'
                }).
                when('/senderTask', {
                    templateUrl: 'scripts/app/views/senderTask.html',
                    controller: 'senderTaskController'
                }).
                otherwise({
                    redirectTo: '/myTasks'
                });
        }

    ]);

    
})();
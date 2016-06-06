(function () {
    var app = angular.module('app',
        [
            'ngRoute',
            'ui.bootstrap',
            'app.controllers',
            'angularSpinners',
            'app.services',
            'ngTable',
            'ngResource',
            'LocalStorageModule'
        ]);

    angular.module('app.controllers', []);
    angular.module('app.services', []);
    angular.module('angularSpinners', []);

    app.config([
        '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $routeProvider.
                when('/recipientTasks', {
                    templateUrl: 'scripts/app/views/recipientTasks.html',
                    controller: 'recipientTasksController'
                }).
                when('/recipientTask/:taskId', {
                    templateUrl: 'scripts/app/views/recipientTask.html',
                    controller: 'recipientTaskController'
                }).
                when('/senderTasks', {
                    templateUrl: 'scripts/app/views/senderTasks.html',
                    controller: 'senderTasksController'
                }).
                otherwise({
                    redirectTo: '/recipientTasks'
                });
        }

    ]);

    
})();
(function () {
    var app = angular.module('app',
        [
            'ngRoute',
            'ui.bootstrap',
            'app.controllers',
            'app.services',
            'ngTable',
            'ngResource',
            'LocalStorageModule'
        ]);

    angular.module('app.controllers', []);
    angular.module('app.services', []);

    app.config([
        '$routeProvider',
        '$httpProvider',
        function($routeProvider, $httpProvider, authService) {
            $routeProvider.
                when('/login', {
                    templateUrl: 'scripts/app/views/login.html',
                    controller: 'loginController'
                }).
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
                when('/myProfile', {
                    templateUrl: 'scripts/app/views/myProfile.html',
                    controller: 'myProfileController'
                }).
                when('/exchange', {
                    templateUrl: 'scripts/app/views/exchange.html',
                    controller: 'exchangeController'
                }).
                otherwise({
                    redirectTo: '/myProfile' 
                });
            $httpProvider.interceptors.push('authInterceptorService');
        }

    ]);

    angular.module('app').run([
        '$rootScope', function ($rootScope) {
            $rootScope.loading = false;
        }
    ]);

})();
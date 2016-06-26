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

    angular.module('app.controllers', [])
        .config(['$provide', function($provide) {
                $provide.value('viewsRoot', $('#viewsRoot').attr('href'));
            }
        ]);
    angular.module('app.services', [])
        .config(['$provide', function($provide) {
                $provide.value('apiRoot', $('#apiRoot').attr('href'));
            }
        ]);

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
                when('/profile', {
                    templateUrl: 'scripts/app/views/profile.html',
                    controller: 'profileController'
                }).
                when('/exchange', {
                    templateUrl: 'scripts/app/views/exchange.html',
                    controller: 'exchangeController'
                }).
                otherwise({
                    redirectTo: '/profile' 
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
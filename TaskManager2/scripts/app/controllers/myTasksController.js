(function () {
    angular.module('app.controllers').controller('myTasksController',
    [
        '$scope',
        '$http',
        'ngTableParams',
        'taskService',
        function ($scope, $http, NgTableParams, taskService) {

            $scope.tableParams = new NgTableParams(
            {
                page: 1,
                count: 25,
                sorting: {name: 'asc'}
            }, {
                total: 0,
                getData: function ($defer, params) {
                    taskService.getMyTasks($defer, params, $scope.filter);
                }
            });

            $scope.$watch("filter.$", function () {
                $scope.tableParams.reload();
            });
        }
    ]);
})();
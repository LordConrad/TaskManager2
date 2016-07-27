(function () {
    angular.module('app.controllers').controller('unassignedTasksController', [
        '$scope',
        'ngTableParams',
        'taskService',
        'commentService',
        '$location',
        'authService',
        function ($scope, NgTableParams, taskService, commentService, $location, authService) {

            $scope.showTask = function (id) {
                $location.path('/unassignedTask/' + id);
            };

            $scope.tableParams = new NgTableParams(
            {
                page: 1,
                count: 25,
                sorting: { name: 'asc' }
            }, {
                total: 0,
                getData: function ($defer, params) {
                    var filterText = $scope.filter ? $scope.filter.Text : '';
                    taskService.getUnassignedTasks($defer, params, filterText);
                }
            });

            $scope.$watch("filter.Text", function () {
                $scope.tableParams.reload();
            });
        }
    ]);
})();
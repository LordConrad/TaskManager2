(function() {
    angular.module('app.controllers').controller('senderTaskController', [
        '$scope',
        'ngTableParams',
        'taskService',
        'commentService',
        '$location',
        function ($scope, NgTableParams, taskService, commentService, $location) {

            //$scope.checkDeadline = function (deadline) {
            //    if (deadline) {
            //        if (new Date(deadline) < new Date('2015-04-01')) {
            //            return { 'background': '-webkit-linear-gradient(left, rgba(255,255,255,1) 51%,rgba(255,96,99,1) 100%)' };
            //        }
            //    }
            //    return null;
            //};

            $scope.showTask = function (id) {
                $location.path('/senderTask/' + id);
            };

            $scope.tableParams = new NgTableParams(
            {
                page: 1,
                count: 25,
                sorting: { name: 'asc' }
            }, {
                total: 0,
                getData: function ($defer, params) {
                    taskService.getSenderTasks($defer, params, $scope.filter, senderId);
                }
            });

            $scope.$watch("filter.Text", function () {
                $scope.tableParams.reload();
            });
        }
    ]);
})();
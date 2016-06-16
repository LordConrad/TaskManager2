(function () {
    angular.module('app.controllers').controller('recipientTasksController',
    [
        '$scope',
        'ngTableParams',
        'taskService',
        '$location',
        'authService',
        function ($scope, NgTableParams, taskService, $location, authService) {

            //$scope.checkDeadline = function (deadline) {
            //    if (deadline) {
            //        if (new Date(deadline) < new Date('2015-04-01')) {
            //            return { 'background': '-webkit-linear-gradient(left, rgba(255,255,255,1) 51%,rgba(255,96,99,1) 100%)' };
            //        }
            //    }
            //    return null;
            //};

            $scope.showTask = function(id) {
                $location.path('/recipientTask/' + id);
            };

            $scope.tableParams = new NgTableParams(
            {
                page: 1,
                count: 25,
                sorting: {name: 'asc'}
            }, {
                total: 0,
                getData: function ($defer, params) {
                    var filterText = $scope.filter ? $scope.filter.Text : '';
                    taskService.getRecipientTasks($defer, params, filterText, authService.authData.userId);
                }
            });

            $scope.$watch("filter.Text", function () {
                if ($scope.filter) {
                    $scope.tableParams.reload();
                }
            });
        }
    ]);
})();
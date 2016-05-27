(function() {
    angular.module('app.controllers').controller('recipientTaskController',
    [
        '$scope',
        '$routeParams',
        'taskService',
        '$location',
        function ($scope, $routeParams, taskService, $location) {

            $scope.backToList = function() {
                $location.path('/myTasks');
            };


            $scope.getStatusLabelStyle = function(complete, accept) {
                if (accept) {
                    return { 'color': 'green' };
                } else {
                    if (complete) {
                        return { 'color': 'yellow' };
                    } else {
                        return { 'color': 'red' };
                    }
                }
            };

            taskService.getMyTask($routeParams.taskId).then(function(response) {
                $scope.task = response.data;
            });
        }
    ]);
})();
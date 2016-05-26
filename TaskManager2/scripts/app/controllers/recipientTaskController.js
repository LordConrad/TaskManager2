(function() {
    angular.module('app.controllers').controller('recipientTaskController',
    [
        '$scope',
        '$routeParams',
        'taskService',
        function ($scope, $routeParams, taskService) {
            
            taskService.getMyTask($routeParams.taskId).then(function(data) {
                $scope.task = data;
            });
        }
    ]);
})();
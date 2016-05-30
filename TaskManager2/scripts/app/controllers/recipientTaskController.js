(function() {
    angular.module('app.controllers').controller('recipientTaskController',
    [
        '$scope',
        '$routeParams',
        'taskService',
        'commentService',
        '$location',
        
        function ($scope, $routeParams, taskService, commentService, $location) {

            $scope.backToList = function() {
                $location.path('/myTasks');
            };

            $scope.addComment = function (taskId, authorId, text) {
                $scope.newComment = null;
                commentService.addNewComment(taskId, authorId, new Date, text).then(function(response) {
                    refreshComments();
                });
            }

            function refreshTask() {
                taskService.getMyTask($routeParams.taskId).then(function (response) {
                    $scope.task = response.data;
                });
            }

            function refreshComments() {
                commentService.getTaskComments($routeParams.taskId).then(function(response) {
                    $scope.comments = response.data;
                });
            }


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

            refreshTask();
            refreshComments();
        }
    ]);
})();
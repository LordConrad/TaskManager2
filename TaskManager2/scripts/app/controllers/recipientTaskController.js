(function () {
    angular.module('app.controllers').controller('recipientTaskController',
    [
        '$scope',
        '$routeParams',
        'taskService',
        'commentService',
        '$location',

        function ($scope, $routeParams, taskService, commentService, $location) {

            $scope.backToList = function () {
                $location.path('/myTasks');
            };

            $scope.addButtonText = "Добавить";
            $scope.addingComment = false;

            $scope.addComment = function () {
                $scope.addingComment = true;
                $scope.addButtonText = "Добавление...";
                // TODO: use logged user id instead recipient ID
                commentService.addNewComment($scope.task.Id, $scope.task.RecipientId, $scope.newComment).then(function (response) {
                    $scope.newComment = null;
                    refreshComments();
                    $scope.addingComment = false;
                    $scope.addButtonText = "Добавить";
                });
            };

            function refreshTask() {
                $scope.loading = true;
                taskService.getRecipientTask($routeParams.taskId).then(function (response) {
                    $scope.task = response.data;
                    $scope.loading = false;
                });
            }

            function refreshComments() {
                commentService.getTaskComments($routeParams.taskId).then(function (response) {
                    $scope.comments = response.data;
                });
            }


            $scope.getStatusLabelStyle = function (complete, accept) {
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
(function () {
    angular.module('app.controllers').controller('recipientTaskController',
    [
        '$scope',
        '$routeParams',
        'taskService',
        'commentService',
        '$location',
        'authService',
        'viewsRoot',
        function ($scope, $routeParams, taskService, commentService, $location, authService, viewsRoot) {

            $scope.backToList = function () {
                $location.path('/recipientTasks');
            };

            $scope.addButtonText = "Добавить";
            $scope.addingComment = false;

            $scope.profileUrl = viewsRoot + '/#/profile';

            $scope.completeTask = function() {
                taskService.completeTask($routeParams.taskId).then(function(response) {
                    if (response.status === 200) {
                        refreshTask();
                    };
                });
            };

            $scope.addComment = function () {
                $scope.addingComment = true;
                $scope.addButtonText = "Добавление...";
                commentService.addNewComment($scope.task.id, authService.authData.userId, $scope.newComment).then(function (response) {
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


            $scope.getStatusLabelStyle = function(complete, accept) {
                if (accept || complete) {
                    return { 'color': 'green' };
                } else {
                    return { 'color': 'red' };
                }
            };

            refreshTask();
            refreshComments();
        }
    ]);
})();
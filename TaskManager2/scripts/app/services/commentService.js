(function() {
    angular.module('app.services').factory('commentService', [
        '$http',
        '$rootScope',
        'apiRoot',
        function($http, $rootScope, apiRoot) {

            var getTaskComments = function (taskId) {
                return $http({
                    method: 'GET',
                    url: apiRoot + '/comment/' + taskId
                }).success(function(data, status) {
                    return data;
                }).error(function(error) {
                    alert('error getting comments');
                }).finally(function() {
                });
            }

            var addNewComment = function(taskId, authorId, text ) {
                return $http({
                        method: 'POST',
                        url: apiRoot + '/comment',
                        data: angular.toJson(
                        {
                            TaskId: taskId,
                            AuthorId: authorId,
                            CommentText: text
                        }),
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                ).success(function(data) {
                    return data;
                }).error(function(err) {
                    alert('error adding comment');
                });
            }

            return {
                getTaskComments: getTaskComments,
                addNewComment: addNewComment
            };
        }
    ]);
})();
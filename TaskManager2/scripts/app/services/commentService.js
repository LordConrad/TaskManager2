(function() {
    angular.module('app.services').factory('commentService', [
        '$http',
        function($http) {
            var serviceHostUrl = 'http://localhost:1135';

            var getTaskComments = function(taskId) {
                return $http({
                    method: 'GET',
                    url: serviceHostUrl + '/api/comment/' + taskId
                }).success(function(data, status) {
                    return data;
                }).error(function(error) {
                    alert('error getting comments');
                });
            }

            var addNewComment = function(taskId, authorId, date, text ) {
                return $http({
                        method: 'POST',
                        url: serviceHostUrl + '/api/comment',
                        data: angular.toJson(
                        {
                            TaskId: taskId,
                            AuthorId: authorId,
                            CommentDate: date,
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
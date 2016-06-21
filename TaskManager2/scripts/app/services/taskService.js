(function () {
    angular.module('app.services').factory('taskService', [
        '$http',
        '$filter',
        '$rootScope',
        'apiRoot',
        function ($http, $filter, $rootScope, apiRoot) {

            function filterData(data, filter) {
                var res = $filter('filter')(data, filter);
                return res;
            }

            function orderData(data, params) {
                var res = params.sorting() ? $filter('orderBy')(data, params.orderBy()) : data;
                return res;
            }

            function sliceData(data, params) {
                var pageSize = params.count();
                var currentPage = params.page();
                if (data.length + pageSize <= currentPage * pageSize) {

                    currentPage = currentPage - Math.floor(currentPage * pageSize / (data.length + pageSize));
                    currentPage = currentPage < 1 ? 1 : currentPage;
                    params.page(currentPage);
                }
                var res = data.slice((currentPage - 1) * pageSize, currentPage * pageSize);

                return res;
            }

            function transformData(data, filter, params) {
                var res = sliceData(orderData(filterData(data, filter), params), params);
                return res;
            }

            var getRecipientTask = function(taskId) {
                $rootScope.loading = true;
                return $http({
                    method: 'GET',
                    url: apiRoot + '/recipientTask/' + taskId
                }).success(function(data, status) {
                    return data;
                }).error(function(data, status) {
                    alert('error');
                }).finally(function() {
                    $rootScope.loading = false;
                });
            };

            var getRecipientTasks = function ($defer, params, filter, recipientId) {
                $rootScope.loading = true;
                $http({
                    method: 'GET',
                    url: apiRoot + '/recipientTasks/' + recipientId

                }).success(function (data, status) {

                    var filteredData = $filter('filter')(data, filter);
                    params.total(filteredData.length);
                    var transformedData = transformData(data, filter, params);

                    $defer.resolve(transformedData);
                }).error(function (data, status) {
                    alert('error');
                }).finally(function () {
                    $rootScope.loading = false;
                });
            };

            var completeTask = function (taskId) {
                $rootScope.loading = true;
                return $http({
                    method: 'GET',
                    url: apiRoot + '/completeTask/' + taskId
                }).success(function(data, status) {
                    return data;
                }).error(function(error, status) {
                    return error;
                }).finally(function() {
                    $rootScope.loading = false;
                });
            }

            var getSenderTasks = function ($defer, params, filter, senderId) {
                $http({
                    method: 'GET',
                    url: apiRoot + '/senderTask'
                });
            };

            return {
                getRecipientTasks: getRecipientTasks,
                getRecipientTask: getRecipientTask,
                completeTask: completeTask
            };
        }
    ]);
})();
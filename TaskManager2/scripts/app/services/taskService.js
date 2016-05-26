angular.module('app').factory('taskService', [
    '$http',
    'spinnerService',
    '$filter',
    function ($http, spinnerService, $filter) {

        var filteredData;

        function filterData(data, filter) {
            var res = $filter('filter')(data, filter);
            return res;
        }

        function orderData(data, params) {
            var res = params.sorting() ? $filter('orderBy')(data, params.orderBy()) : filteredData;
            return res;
        }

        function sliceData(data, params) {
            var pageSize = params.count();
            var currentPage = params.page();
            if (data.length < currentPage * pageSize) {
                currentPage = 1;
                params.page(currentPage);
            }
            var res = data.slice((currentPage - 1) * pageSize, currentPage * pageSize);
            
            return res;
        }

        function transformData(data, filter, params) {
            var res = sliceData(orderData(filterData(data, filter), params), params);
            return res;
        }

        var getMyTasks = function ($defer, params, filter) {
            spinnerService.show('myTasksSpinner');
            $http({
                method: 'GET',
                url: 'http://localhost:1135/api/task'
            }).success(function (data, status) {
                
                filteredData = $filter('filter')(data, filter);
                params.total(filteredData.length);
                var transformedData = transformData(filteredData, filter, params);
                
                $defer.resolve(transformedData);
            }).error(function (data, status) {
                alert('error');
            }).finally(function () {
                spinnerService.hide('myTasksSpinner');
            });
        };

        return {
            getMyTasks: getMyTasks
        };
    }
]);
(function() {
    angular.module('app').directive('fieldEditor', [
        function() {

            return {
                restrict: 'A',
                templateUrl: "scripts/app/views/templates/fieldEditor.html",
                replace: true,
                scope: {
                    fieldObject: '=fieldEditor'
                },
                link: function(scope, element, attrs) {
                    scope.$watch("fieldObject", function(fieldObject) {
                        if (fieldObject) {
                            scope.view = {
                                editableValue: fieldObject.value,
                                title: fieldObject.title,
                                isEditEnable: false
                            };
                        }
                    });

                    scope.view = {
                        editableValue: "",
                        title: "",
                        isEditEnable: false
                    };

                    scope.enableEdit = function() {
                        scope.view.isEditEnable = true;
                        scope.view.editableValue = scope.fieldObject.value;
                        setTimeout(function() {
                            element.find('input')[0].focus();
                        });

                    };

                    scope.disableEdit = function() {
                        scope.view.isEditEnable = false;
                    };

                    scope.save = function() {
                        if (scope.fieldObject.value !== scope.view.editableValue) {
                            scope.fieldObject.saveMethod(scope.fieldObject.title, scope.view.editableValue);
                        }
                        scope.fieldObject.value = scope.view.editableValue;
                        scope.disableEdit();
                    };
                }
            };
        }]);
})();



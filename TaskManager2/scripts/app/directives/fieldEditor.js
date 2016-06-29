(function() {
    angular.module('app').directive('fieldEditor', function() {

        return {
            restrict: 'A',
            templateUrl: "scripts/app/views/templates/fieldEditor.html",
            replace: true,
            scope: {
                fieldObject: '=fieldEditor'
            },
            link: function(scope, element, attrs) {
                scope.view = {
                    editableValue: scope.fieldObject.value,
                    title: scope.fieldObject.title,
                    isEditEnable: false
                }

                scope.enableEdit = function() {
                    scope.view.isEditEnable = true;
                    scope.view.editableValue = scope.fieldObject.value;
                    setTimeout(function() {
                        element.find('input')[0].focus();
                    });
                    
                }

                scope.disableEdit = function() {
                    scope.view.isEditEnable = false;
                }

                scope.save = function() {
                    scope.fieldObject.value = scope.view.editableValue;
                    scope.disableEdit();
                }
            }
        }
    });
})();



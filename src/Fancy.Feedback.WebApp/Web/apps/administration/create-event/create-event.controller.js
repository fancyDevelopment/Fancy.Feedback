(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("CreateEventController", ["$scope", "$state", "$http", "Events", function ($scope, $state, $http, Events) {

            var vm = this;

            vm.isSaving = false;
            vm.hasError = false;

            // Get the required information to render the form
            vm.formInfo = Events.create();

            // Add submit function to the scope
            vm.onSubmit = function (form) {

                // First we broadcast an event so all fields validate themselves
                $scope.$broadcast('schemaFormValidate');

                // Then we check if the form is valid
                if (form.$valid) {

                    vm.hasError = false;
                    vm.isSaving = true;

                    // If the form is valid send data to web application
                    $http({
                        method: vm.formInfo.Model._actions.create.method,
                        url: vm.formInfo.Model._actions.create.href,
                        data: vm.formInfo.Model
                    }).success(function () {

                        vm.isSaving = false;

                        // ToDo: Show save success message
                    });

                } else {
                    vm.hasError = true;
                }

            };

        }]);

}());
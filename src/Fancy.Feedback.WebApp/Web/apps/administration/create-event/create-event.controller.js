(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("CreateEventController", ["$scope", "$state", "$http", function ($scope, $state, $http) {

            var vm = this;

            vm.isSaving = false;
            vm.hasError = false;

            // Get the url to the resource from the descriptions
            var url = "/events/meta";

            // Get the required information to render the form
            $http.get(url).success(function (data) {
                vm.schema = data.Schema;
                vm.form = data.Form;
                vm.event = {};
            });

            // Add submit function to the scope
            vm.onSubmit = function (form) {

                // First we broadcast an event so all fields validate themselves
                $scope.$broadcast('schemaFormValidate');

                // Then we check if the form is valid
                if (form.$valid) {

                    vm.hasError = false;
                    vm.isSaving = true;

                    // If the form is valid send data to web application
                    $http.put(url, vm.coach).success(function () {

                        vm.isSaving = false;

                        // ToDo: Show save success message
                    });

                } else {
                    vm.hasError = true;
                }

            };

        }]);

}());
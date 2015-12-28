(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("CreateEventController", ["$scope", "$state", "$http", "appStateService", function ($scope, $state, $http, appStateService) {

            var vm = this;

            vm.isSaving = false;
            vm.hasError = false;

            // Get the url to the action
            var url = appStateService["actionUrl"];
            var metaUrl = url + "/desc";

            // Get the required information to render the form
            $http.get(metaUrl).success(function (data) {
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
                    $http.put(url, vm.event).success(function () {

                        vm.isSaving = false;

                        // ToDo: Show save success message
                    });

                } else {
                    vm.hasError = true;
                }

            };

        }]);

}());
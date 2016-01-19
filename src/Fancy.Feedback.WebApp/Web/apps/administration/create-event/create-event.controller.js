(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("CreateEventController", ["$scope", "$state", "$http", "Events", function ($scope, $state, $http, Events) {

            var vm = this;

            vm.isSaving = false;
            vm.hasError = false;

            // Get the required information to render the form
            Events.create().then(function(data) {
                vm.formInfo = data;
            });

            // Add submit function to the scope
            vm.onSubmit = function (form) {

                // First we broadcast an event so all fields validate themselves
                $scope.$broadcast('schemaFormValidate');

                // Then we check if the form is valid
                if (form.$valid) {

                    vm.hasError = false;
                    vm.isSaving = true;

                    // If the form is valid send data via hateoas method to web application
                    vm.formInfo.Model.create().then(function() {
                        vm.isSaving = false;
                    });

                } else {
                    vm.hasError = true;
                }

            };

        }]);

}());
(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("DashboardController", ["$http", function($http) {

            var vm = this;

            $http.get("/dashboard").then(function(response) {

                vm.data = response.data;

            });

        }]);

}());
(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("DashboardController", ["$http", function($http) {

            var vm = this;

            $http.get("/dashboard").success(function(data) {

                vm.data = data;

            });

        }]);

}());
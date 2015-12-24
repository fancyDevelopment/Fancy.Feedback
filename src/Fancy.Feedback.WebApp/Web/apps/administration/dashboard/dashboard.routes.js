(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                // The dashboard main view
                .state('dashboard', {
                    url: "/dashboard",
                    controller: "DashboardController",
                    controllerAs: "vm",
                    templateUrl: "/apps/administration/dashboard/dashboard.tpl.html"
                });

        }]);

})();
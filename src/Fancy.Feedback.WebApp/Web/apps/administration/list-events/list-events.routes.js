(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                // The list events main view
                .state('list-events', {
                    url: "/list-events",
                    controller: "ListEventsController",
                    controllerAs: "vm",
                    templateUrl: "/apps/administration/list-events/list-events.tpl.html"
                });

        }]);

})();
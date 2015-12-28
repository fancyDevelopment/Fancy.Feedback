(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                // The dashboard main view
                .state('create-event', {
                    url: "/create-event/{actionUrl}",
                    controller: "CreateEventController",
                    controllerAs: "vm",
                    templateUrl: "/apps/administration/create-event/create-event.tpl.html"
                });

        }]);

})();
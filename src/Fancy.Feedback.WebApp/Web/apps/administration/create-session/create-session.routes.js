(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                // The create session view
                .state('create-session', {
                    url: "/create-session",
                    controller: "CreateSessionController",
                    controllerAs: "vm",
                    templateUrl: "/apps/administration/create-session/create-session.tpl.html"
                });

        }]);

})();
(function () {
    'use strict';

    // Register object path library to angular js
    ObjectPath.registerModule(angular);

    var administrationApp = angular.module("Fancy.Feedback.Apps.Administration", ["ngResource", "ui.router", "schemaForm"]);

    administrationApp.constant("resourceUrls", { events: "/events" });

    administrationApp.config(["$urlRouterProvider", function ($urlRouterProvider) {

        // For any unmatched url, redirect to dashboard
        $urlRouterProvider.otherwise("/dashboard");

    }]);

})();
(function () {
    'use strict';

    var administrationApp = angular.module("Fancy.Feedback.Apps.Administration", ["ui.router"]);

    administrationApp.config(["$urlRouterProvider", function ($urlRouterProvider) {

        // For any unmatched url, redirect to dashboard
        $urlRouterProvider.otherwise("/dashboard");

    }]);

})();
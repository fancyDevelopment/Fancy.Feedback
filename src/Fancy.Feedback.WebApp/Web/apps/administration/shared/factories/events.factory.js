(function () {
    'use strict';

    angular.module("Fancy.Feedback.Apps.Administration")
        .service("Events", ["$resource", function ($resource) {

            return $resource("/events/:id/:action",
            {
                pageSize: 10
            },
            {
                query: { method: "GET", isArray: false },
                create: {method: "GET", params: {action: "create"}}
            });

        }]);

})();
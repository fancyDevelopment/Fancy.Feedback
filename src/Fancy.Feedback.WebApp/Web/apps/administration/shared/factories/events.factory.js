(function () {
    'use strict';

    angular.module("Fancy.Feedback.Apps.Administration")
        .service("Events", ["hateoasResourceService", function (hateoasResourceService) {

            var resource = hateoasResourceService.createHateoasResource(
                "/events",
                {
                    create: {
                        url: "/create",
                        method: "GET"
                    }
                });

            return resource;

        }]);

})();
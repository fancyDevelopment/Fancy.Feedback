(function () {
    'use strict';

    angular.module("Fancy.Feedback.Apps.Administration")
        .service("Events", ["$resource", "$http", "$q", function ($resource, $http, $q) {

            var resource = $resource("/events/:id/:action",
            {
                pageSize: 10
            },
            {
                query: { method: "GET", isArray: false },
                create: {
                    method: "GET",
                    params: { action: "create" },
                    transformResponse: function (data, headers) {
                        var object = angular.fromJson(data);
                        injectHateoasMethods(object);
                        return object;
                    }
                }
            });

            return resource;

            function injectHateoasMethods(object) {
                angular.forEach(object, function (value, key) {

                    if (key !== "_actions" && key !== "_links" && angular.isObject(value)) {

                        injectHateoasMethods(value);

                    } else if (key === "_actions") {

                        angular.forEach(value, function (actionValue, actionKey) {

                            if (actionValue.method === "PUT" || actionValue.method === "POST") {

                                value["execute" + actionKey] = function () {

                                    $http({
                                        method: actionValue.method,
                                        url: actionValue.href,
                                        data: object
                                    }).then(function (response) {

                                    });

                                };

                            } else if (actionValue.method === "GET" || actionValue.method === "DELETE") {

                                $http({
                                    method: actionValue.method,
                                    url: actionValue.href
                                }).then(function (response) {

                                });

                            }
                        });
                    }
                });
            }

        }]);

})();
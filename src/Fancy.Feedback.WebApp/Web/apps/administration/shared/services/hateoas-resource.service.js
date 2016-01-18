(function () {
    'use strict';

    angular.module("Fancy.Feedback.Apps.Administration")
        .service("hateoasResourceService", ["$http", "$q", function ($http, $q) {

            // Declare a function to create a hateoas enabled resource
            this.createHateoasResource = function(baseUrl, operations) {

                var resource = {};

                if (!operations) {
                    operations = {};
                }

                if (!operations.query) {
                    operations.query = {
                        url: "",
                        method: "GET",
                        params: { pageSize: 10 }
                    };
                }

                if (!operations.get) {
                    operations.get = {
                        url: "/:id",
                        method: "GET",
                        params: {}
                    };
                }

                angular.forEach(operations, function(value, key) {

                    resource[key] = function (params) {

                        var completeUrl = baseUrl + value.url;

                        if (!params) {
                            params = {};
                        }

                        angular.forEach(value.params, function(value, key) {
                            if (!params[key]) {
                                params[key] = value;
                            }
                        });

                        angular.forEach(params, function (value, key) {
                            var searchKey = ":" + key;
                            if (completeUrl.indexOf(searchKey) != -1) {
                                completeUrl = completeUrl.replace(searchKey, value);
                            }
                        });

                        var deferredResponse = $q.defer();

                        $http({
                            method: value.method,
                            url: completeUrl,
                            transformResponse: hateoasResponseTransformer
                        }).then(function (response) {
                            deferredResponse.resolve(response.data);
                        });

                        return deferredResponse.promise;
                    }

                });


                return resource;
            }

            function hateoasResponseTransformer(data, header) {
                var object = angular.fromJson(data);
                injectHateoasMethods(object);
                return object;
            }

            function injectHateoasMethods(object) {
                angular.forEach(object, function (value, key) {

                    if (key !== "_actions" && key !== "_links" && angular.isObject(value)) {

                        injectHateoasMethods(value);

                    } else if (key === "_actions") {

                        angular.forEach(value, function (actionValue, actionKey) {

                            if (actionValue.method === "PUT" || actionValue.method === "POST") {

                                value["execute" + actionKey] = function () {

                                    var deferredResponse = $q.defer();

                                    $http({
                                        method: actionValue.method,
                                        url: actionValue.href,
                                        data: object
                                    }).then(function (response) {
                                        deferredResponse.resolve(response.data);
                                    });

                                    return deferredResponse.promise;

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
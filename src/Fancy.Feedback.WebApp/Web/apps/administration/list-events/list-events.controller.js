(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("ListEventsController", ["Events", function (Events) {

            var vm = this;

            vm.events = Events.query();

            var createEvent = Events.create();

        }]);

}());
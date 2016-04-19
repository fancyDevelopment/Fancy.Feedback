(function () {
    "use strict";

    angular.module("Fancy.Feedback.Apps.Administration")
        .controller("CreateSessionController", ["Events", function(Events) {

            var vm = this;

            Events.query().then(function(data) {
                vm.events = data;
            });

            vm.addSession = function(event) {
                event.addSession().then(function(data) {
                    vm.addSessionData = data;
                });
            }

        }]);

}());
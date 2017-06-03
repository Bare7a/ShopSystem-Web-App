'use strict';

app.controller('AddMessageController',
    function ($rootScope, $scope, messagesService, notifyService, $routeParams, $location) {

        $rootScope.title = "Sent a new message";

        $scope.messageData = {};
        $scope.messageData.AddresseeUsername = $routeParams.username != undefined ? $routeParams.username : "";

        $scope.addMessage = function (messageData) {
            messagesService.createMessage(
                messageData,
                function success() {
                    $location.path('/messages');
                    notifyService.showInfo("Message successfully sent!");
                },
                function error(response) {
                    notifyService.showError("Message was not sent", response['data']);
                }
            );
        };
    }
);
'use strict';

app.controller('ViewMessageController',
    function ($rootScope, $scope, messagesService, notifyService, $routeParams, $location) {

        $rootScope.title = "Message";

        $scope.getMessage = function () {
            messagesService.getMessageById(
                $routeParams.id,
                function success(response) {
                    $scope.message = response['data'];
                },
                function error(response) {
                    $location.path('/messages');
                    notifyService.showError("Cannot load message", response['data']);
                }
            );
        };

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

        $scope.getMessage();
    }
);
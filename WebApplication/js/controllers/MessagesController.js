'use strict';

app.controller('MessagesController',
    function ($scope, messageService, notifyService, $routeParams, $location, productsPageSize) {

        $scope.messagesParams = {
            'startPage': 1,
            'pageSize': productsPageSize
        };

        $scope.reloadMessages = function () {
            messageService.getAllMessages(
                $scope.messagesParams,
                function success(response) {
                    $scope.messages = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load messages", response['data']);
                }
            );
        };


        $scope.addMessage = function (messageData) {
            messageService.createMessage(messageData,
                function success() {
                    $location.path('/messages');
                    notifyService.showInfo("Message successfully sent!");
                },
                function error(response) {
                    notifyService.showError("Message was not sent", response['data']);
                }
            );
        };

        $scope.getMessage = function () {
            messageService.getMessageById(
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

        $scope.messageTypeClicked = function (messageTypeId) {
            $scope.messagesParams.Type = messageTypeId;
            $scope.messagesParams.startPage = 1;
            $scope.reloadMessages();
        };
    }
);
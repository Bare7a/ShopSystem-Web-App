'use strict';

app.controller('MessagesController',
    function ($scope, userService, notifyService, $routeParams) {

        $scope.messagesParams = {
            'startPage': 1,
            'pageSize': 5
        };

        $scope.reloadMessages = function () {
            userService.getAllMessages(
                $scope.messagesParams,
                function success(response) {
                    console.log(response);
                    $scope.messages = response['data'];
                },
                function error(response) {
                    console.log(response);
                    notifyService.showError("Cannot load messages", response['data']);
                }
            );
        };


        $scope.addNewMessage = function (messageData) {
            userService.createNewComment(messageData,
                function success() {
                    notifyService.showInfo("Message successfully sent!");
                },
                function error(err) {
                    notifyService.showError("Message was not sent.", err);
                }
            );
        };

        $scope.message = function () {
            userService.getMessageById(
                $routeParams.id,
                function success(response) {
                    $scope.product = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load message", response['data']);
                }
            );
        };

        $scope.reloadMessages();
        //$scope.message();
    }
);
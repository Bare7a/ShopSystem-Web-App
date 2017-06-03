'use strict';

app.controller('ListMessagesController',
    function ($rootScope, $scope, messagesService, notifyService, $routeParams, $location, messagesPageSize) {

        $rootScope.title = "Messages";

        $scope.messagesParams = {
            'startPage': 1,
            'pageSize': messagesPageSize
        };

        $scope.reloadMessages = function () {
            messagesService.getAllMessages(
                $scope.messagesParams,
                function success(response) {
                    $scope.messages = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load messages", response['data']);
                }
            );
        };

        $scope.reloadMessages();

        $scope.messageTypeClicked = function (messageTypeId) {
            $scope.messagesParams.Type = messageTypeId;
            $scope.messagesParams.startPage = 1;
            $scope.reloadMessages();
        };
    }
);
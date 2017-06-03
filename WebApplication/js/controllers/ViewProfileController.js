'use strict';

app.controller('ViewProfileController',
    function ($rootScope, $scope, notifyService, accountService, authService , $location, $routeParams) {

        $rootScope.title = $routeParams.username + "'s profile";

        $scope.getUser = function () {
            accountService.getProfile(
                $routeParams.username,
                function success(response) {
                    $scope.user = response['data'];
                },
                function error(response) {
                    console.log(response);
                    console.log($routeParams.username)
                    notifyService.showError("User not found!", response['data']);
                }
            )
        };

        $scope.addFeedback = function (feedbackData) {
            accountService.createFeedback($routeParams.id, feedbackData,
                function success() {
                    $scope.reloadFeedbacks();
                    notifyService.showInfo("Feedback successfully added!");
                },
                function error(response) {
                    notifyService.showError("Failed to add a feedback.", response['data']);
                }
            );
        };

        $scope.reloadFeedbacks = function () {
            accountService.getAllFeedbacks(
                $routeParams.username,
                function success(response) {
                    $scope.feedbacks = response['data'];
                },
                function error(response) {
                    notifyService.showError("Failed to load the feedbacks.", response['data']);
                }
            );
        };

        $scope.feedbackData = {};
        $scope.feedbackData.AddresseeUsername = $routeParams.username;
        $scope.feedbackScores = [{ 'val': 1 }, { 'val': 2 }, { 'val': 3 }, { 'val': 4 }, { 'val': 5 }];
        $scope.getUser();
        $scope.reloadFeedbacks();
    }
);
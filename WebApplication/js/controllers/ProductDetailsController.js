'use strict';

app.controller('ProductDetailsController',
    function ($scope, productsService, notifyService, $location, $routeParams) {
         $scope.product = function () {
            productsService.getProductById(
                $routeParams.id,
                function success(response) {
                    $scope.product = response['data'];
                },
                function error(response) {
                    $location.path('/');
                    notifyService.showError("Cannot load product", response['data']);
                }
            );
        };

         $scope.videos = function () {
             productsService.getAllVideos(
                 $routeParams.id,
                 function success(response) {
                     $scope.videos = response['data'];
                 },
                 function error(response) {
                     $location.path('/');
                     notifyService.showError("Cannot load videos", response['data']);
                 }
             );
         };

         $scope.pictures = function () {
             productsService.getAllPictures(
                 $routeParams.id,
                 function success(response) {
                     $scope.pictures = response['data'];
                 },
                 function error(response) {
                     $location.path('/');
                     notifyService.showError("Cannot load pictures", response['data']);
                 }
             );
         };

        $scope.addComment = function (commentData) {
            productsService.createComment($routeParams.id, commentData,
                function success() {
                    $scope.reloadComments();
                    notifyService.showInfo("Comment successfully added!");
                },
                function error(response) {
                    notifyService.showError("Failed to add a comment.", response);
                }
            );
        };

        $scope.reloadComments = function () {
            productsService.getAllComments($routeParams.id,
                function success(response) {
                    $scope.comments = response['data'];
                },
                function error(response) {
                    notifyService.showError("Failed to load the comments.", response['data']);
                }
            );
        };

        $scope.product();
        $scope.pictures();
        $scope.videos();
        $scope.reloadComments();
    }
);
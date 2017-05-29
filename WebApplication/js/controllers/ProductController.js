'use strict';

app.controller('ProductController',
    function ($scope, userService, productsService, notifyService, $routeParams) {
        $scope.product = function () {
            productsService.getProductById(
                $routeParams.id,
                function success(response) {
                    $scope.product = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load product", response['data']);
                }
            );
        };


        $scope.addComment = function (commentData) {
            userService.createNewComment($routeParams.id, commentData,
                function success() {
                    notifyService.showInfo("Comment successfully added!");
                },
                function error(err) {
                    notifyService.showError("Failed to add a comment.", err);
                }
            );
        };

        $scope.product();
    }
);
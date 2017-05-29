'use strict';

app.controller('ProductController',
    function ($scope, productsService, notifyService, $routeParams) {
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

        $scope.product();
    }
);
'use strict';

app.controller('HomeController',
    function ($scope, productsService, notifyService, pageSize) {

        $scope.productsParams = {
            'startPage': 1,
            'pageSize': pageSize
        };

        $scope.reloadProducts = function () {
            productsService.getAllProducts(
                $scope.productsParams,
                function success(response) {
                    $scope.products = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load products", response['data']);
                }
            );
        };

        $scope.reloadProducts();
    }
);
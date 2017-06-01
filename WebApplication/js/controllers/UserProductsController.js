'use strict';

app.controller('UserProductsController',
    function ($scope, productService, notifyService, $location, $routeParams, userProductsPageSize) {
        $scope.productsParams = {
            'startPage': 1,
            'pageSize': userProductsPageSize
        };

        $scope.reloadProducts = function () {
            productService.getAllUserProducts(
                $scope.productsParams,
                function success(response) {
                    $scope.products = response['data'];
                },
                function error(response) {
                    $location.path('/');
                    notifyService.showError("Cannot load products", response['data']);
                }
            );
        };

        $scope.deleteProduct = function (id) {
            productService.deleteProductById(
                id,
                function success() {
                    $scope.reloadProducts();
                    notifyService.showInfo("Product successfully deleted!");
                },
                function error(response) {
                    $location.path('/');
                    notifyService.showError("Cannot delete the product", response['data']);
                }
            )
        }

        $scope.reloadProducts();
    }
);
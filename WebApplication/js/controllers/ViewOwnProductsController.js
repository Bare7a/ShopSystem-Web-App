'use strict';

app.controller('ViewOwnProductsController',
    function ($rootScope, $scope, productsService, notifyService, $location, $routeParams, userProductsPageSize) {

        $rootScope.title = "My products";

        $scope.productsParams = {
            'startPage': 1,
            'pageSize': userProductsPageSize
        };

        $scope.reloadProducts = function () {
            productsService.getAllUserProducts(
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
            productsService.deleteProductById(
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
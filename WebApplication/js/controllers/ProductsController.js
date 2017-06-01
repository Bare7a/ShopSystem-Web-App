'use strict';

app.controller('ProductsController',
    function ($scope, productService, notifyService, citiesService, categoriesService, $routeParams, productsPageSize) {
        $scope.productsParams = {
            'startPage': 1,
            'pageSize': productsPageSize
        };

        $scope.reloadProducts = function () {
            productService.getAllProducts(
                $scope.productsParams,
                function success(response) {
                    $scope.products = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load products", response['data']);
                }
            );
        };

        $scope.productsFilterClicked = function () {
            $scope.reloadProducts();
        };

        $scope.cities = citiesService.getCities();
        $scope.categories = categoriesService.getCategories();

        $scope.reloadProducts();
    }
);
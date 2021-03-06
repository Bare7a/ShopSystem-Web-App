﻿'use strict';

app.controller('ListProductsController',
    function ($rootScope, $scope, productsService, notifyService, citiesService, categoriesService, $routeParams, productsPageSize) {

        $rootScope.title = "Products";

        $scope.productsParams = {
            'startPage': 1,
            'pageSize': productsPageSize
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

        $scope.productsFilterClicked = function () {
            $scope.reloadProducts();
        };

        $scope.cities = citiesService.getCities();
        $scope.categories = categoriesService.getCategories();

        $scope.reloadProducts();
    }
);
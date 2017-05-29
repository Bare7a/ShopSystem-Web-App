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

        $scope.$on("categorySelectionChanged", function (event, selectedCategoryId) {
            $scope.productsParams.categoryId = selectedCategoryId;
            $scope.productsParams.startPage = 1;
            $scope.reloadProducts();
        });


        $scope.$on("citySelectionChanged", function (event, selectedCityId) {
            $scope.citiesParams.cityId = selectedCityId;
            $scope.citiesParams.startPage = 1;
            $scope.reloadProducts();
        });


        $scope.reloadProducts();
    }
);
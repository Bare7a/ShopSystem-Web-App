'use strict';

app.controller('HomeController',
    function ($scope, productsService, notifyService, pageSize) {
        $scope.productsParams = {
            'startPage': 1,
            'pageSize': pageSize
        };

        $scope.reloadProducts = function () {
            productsService.getProducts(
                $scope.productsParams,
                function success(data) {
                    $scope.products = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load products", err);
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
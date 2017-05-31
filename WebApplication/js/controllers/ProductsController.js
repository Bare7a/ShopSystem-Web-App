'use strict';

app.controller('ProductsController',
    function ($scope, productService, notifyService, citiesService, categoriesService, $location, $routeParams, productsPageSize, userProductsPageSize) {
        $scope.productsParams = {
            'startPage': 1,
            'pageSize': productsPageSize
        };

        $scope.userProductsParams = {
            'startPage': 1,
            'pageSize': userProductsPageSize
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

        $scope.product = function () {
            productService.getProductById(
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

        $scope.reloadUserProducts = function () {
            productService.getAllUserProducts(
                $scope.userProductsParams,
                function success(response) {
                    $scope.userProducts = response['data'];
                },
                function error(response) {
                    $location.path('/');
                    notifyService.showError("Cannot load products", response['data']);
                }
            );
        };


        $scope.addComment = function (commentData) {
            productService.createComment($routeParams.id, commentData,
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
            productService.getAllComments($routeParams.id,
                function success(response) {
                    $scope.comments = response['data'];
                },
                function error(response) {
                    notifyService.showError("Failed to load the comments.", response['data']);
                }
            );
        };

        $scope.productsFilterClicked = function () {
            $scope.reloadProducts();
        };

        $scope.cities = citiesService.getCities();
        $scope.categories = categoriesService.getCategories();
    }
);
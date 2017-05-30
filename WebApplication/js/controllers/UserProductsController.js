'use strict';

app.controller('UserProductsController',
    function ($scope, userService, notifyService, $routeParams) {

        $scope.userProductsParams = {
            'startPage': 1,
            'pageSize': 5
        };

        $scope.reloadUserProducts = function () {
            userService.getAllUserProducts(
                $scope.userProductsParams,
                function success(response) {
                    $scope.userProducts = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load products", response['data']);
                }
            );
        };

        $scope.reloadUserProducts();
    }
);
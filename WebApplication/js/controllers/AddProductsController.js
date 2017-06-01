'use strict';

app.controller('AddProductsController',
    function ($scope, productService, notifyService, categoriesService, $location, $compile) {

        $scope.addProduct = function () {
            productService.createProduct(
                $scope.productData,
                function success(response) {
                    $location.path('/user/products');
                    notifyService.showInfo("Product successfully added!");
                },
                function error(response) {
                    notifyService.showError("Failed to add a product.", response['data']);
                }
            )
        }

        $scope.categories = categoriesService.getCategories();

        $scope.productData = {};

        $scope.productData.videos = [];
        $scope.productData.pictures = [];

        $scope.addVideoInput = function () {
            $scope.productData.videos.push({});
        }

        $scope.removeVideoInput = function () {
            $scope.productData.videos.pop();
        }


        $scope.imageSelected = function (fileInputField) {
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    $scope.productData.pictures.push({ "Image": reader.result, "Id": $scope.productData.pictures.length });
                    var delButton = "<div id='img-" + $scope.productData.pictures.length + "' class='col-xs-6'><img class='img-responsive' src='" + reader.result + "'><a class='btn btn-warning form-control' ng-click='deleteImage(" + $scope.productData.pictures.length + ")'>Delete Image</a></div>";
                    var temp = $compile(delButton)($scope);
                    angular.element(document.getElementById('images')).append(temp);
                };
                reader.readAsDataURL(file);
            }
        };

        $scope.deleteImage = function (id) {
            $scope.productData.pictures.splice(id - 1, 1);
            var imgStr = '#img-' + id;
            $(imgStr).remove();
        };
    }
);
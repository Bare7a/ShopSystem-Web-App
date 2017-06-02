'use strict';

app.controller('AddProductsController',
    function ($scope, productsService, notifyService, categoriesService, $location, $compile) {

        $scope.addProduct = function () {
            productsService.createProduct(
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

        $scope.imageId = 0;

        $scope.imageSelected = function (fileInputField) {
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    $scope.productData.pictures.push({ "Id": $scope.imageId, "Image": reader.result});
                    var delButton = "<div id='img-" + $scope.imageId + "' class='col-xs-6'><img class='img-responsive' src='" + reader.result + "'><a class='btn btn-warning form-control' ng-click='deleteImage(" + $scope.imageId + ")'>Delete Image</a></div>";
                    var temp = $compile(delButton)($scope);
                    angular.element(document.getElementById('images')).append(temp);

                    $scope.imageId++;
                };
                reader.readAsDataURL(file);
            }
        };

        $scope.deleteImage = function (id) {

            $scope.productData.pictures = $.grep($scope.productData.pictures, function (e) {
                return e.Id != id;
            });

            console.log($scope.productData.pictures);

            var imgStr = '#img-' + id;
            $(imgStr).remove();
        };
    }
);
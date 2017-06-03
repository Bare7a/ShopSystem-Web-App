'use strict';

app.controller('EditProductsController',
    function ($rootScope, $scope, productsService, notifyService, categoriesService, $location, $compile, $routeParams) {

        $rootScope.title = "Edit product";

        $scope.editProduct = function () {
            productsService.editProduct(
                $routeParams.id,
                $scope.product,
                function success(response) {
                    $location.path('/products/user');
                    notifyService.showInfo("Product successfully edited!");
                },
                function error(response) {
                    notifyService.showError("Failed to edit the product", response['data']);
                }
            )
        };

        $scope.product = function () {
            productsService.getUserProductById(
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

        $scope.reloadPictures = function () {
            productsService.getAllPictures(
                $routeParams.id,
                function success(response) {
                    $scope.pictures = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load the pictures for this product", response['data']);
                }
            )
        }

        $scope.addPicture = function (pictureData) {
            productsService.createPicture(
                pictureData,
                function success() {
                    $scope.reloadPictures();
                    notifyService.showInfo("Picture successfully added!")
                },
                function error(response) {
                    notifyService.showError("Cannot add this picture for the product", response['data']);
                }
            )
        };

        $scope.deletePicture = function (id) {
            productsService.deletePictureById(
                id,
                function success(response) {
                    $scope.reloadPictures();
                    notifyService.showInfo("Picture successfully deleted!");
                },
                function error(response) {
                    notifyService.showError("Cannot delete the picture", response['data']);
                }
            )
        }

        $scope.reloadVideos = function () {
            productsService.getAllVideos(
                $routeParams.id,
                function success(response) {
                    $scope.videos = response['data'];
                },
                function error(response) {
                    notifyService.showError("Cannot load the pictures for this product", response['data']);
                }
            )
        }

        $scope.addVideo = function (videoData) {
            productsService.createVideo(
                $routeParams.id,
                videoData,
                function success() {
                    $scope.reloadVideos();
                    notifyService.showInfo("Video successfully added!")
                },
                function error(response) {
                    notifyService.showError("Cannot add this video for the product", response['data']);
                }
            )
        };

        $scope.deleteVideo = function (id) {
            productsService.deleteVideoById(
                id,
                function success(response) {
                    $scope.reloadVideos();
                    notifyService.showInfo("Video successfully deleted!");
                },
                function error(response) {
                    notifyService.showError("Cannot delete the video", response['data']);
                }
            )
        }

        $scope.categories = categoriesService.getCategories();

        $scope.imageSelected = function (fileInputField) {
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    var pictureData = { 'ProductId': $routeParams.id, 'Image': reader.result };
                    $scope.addPicture(pictureData);
                };

                reader.readAsDataURL(file);
            } else {
                notifyService.showError('Unsuported image file');
            }
        }

        $scope.conditions = [{ 'Id': 0, 'Name': 'New' }, { 'Id': 1, 'Name': 'Used' }];

        $scope.videoTypes = [{ 'Id': 0, 'Name': 'YouTube' }, { 'Id': 1, 'Name': 'Vbox7' }, { 'Id': 2, 'Name': 'Vimeo' }];

        $scope.product();
        $scope.reloadPictures();
        $scope.reloadVideos();
    }
);
'use strict';

app.controller('AuthController',
    function ($scope, $location, citiesService, authService, notifyService) {
        $scope.userData = {cityId: null};
        $scope.cities = citiesService.getCities();

        $scope.register = function(userData) {
            authService.register(userData,
            function success() {
                notifyService.showInfo("Registered successfully");
                $location.path('/');
            },
            function error(err) {
                notifyService.showError("Failed to register", err);
            })
        }

        $scope.login = function (userData) {
            authService.login(userData,
                function success() {
                    notifyService.showInfo("Login Successful");
                    if (authService.getCurrentUser().isAdmin)
                        $location.path('/admin/home');
                    else
                        $location.path('/user/home/');
                },
                function error(err) {
                    notifyService.showError("Failed to login", err);
                });
        };

        $scope.fileSelected = function (fileInputField) {
            delete $scope.userData.profilePicture;
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    $scope.userData.profilePicture = reader.result;
                    $(".image-box").html("<img class='img-responsive' src='" + reader.result + "'>");
                };
                reader.readAsDataURL(file);
            } else {
                $(".image-box").html("<p>File type not supported!</p>");
            }
        };
    }
);
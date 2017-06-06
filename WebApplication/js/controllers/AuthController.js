'use strict';

app.controller('AuthController',
    function ($rootScope, $scope, $location, citiesService, authService, notifyService) {

        $rootScope.title = "Login";

        $scope.cities = citiesService.getCities();

        $scope.register = function(userData) {
            authService.register(userData,
            function success() {
                notifyService.showInfo("Registered successfully </br> You can log in to your account now!");
                $location.path('/login');
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
                        $location.path('/');
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
                    $scope.userData.ProfilePicture = reader.result;
                    $(".image-box").html("<img class='img-responsive avatar-img' src='" + $scope.userData.ProfilePicture + "'>");
                };
                reader.readAsDataURL(file);
            } else {
                $(".image-box").html("<p>File type not supported!</p>");
            }
        };
    }
);
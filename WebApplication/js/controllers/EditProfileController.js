'use strict';

app.controller('EditProfileController',
    function ($rootScope, $scope, notifyService, accountService, citiesService, $location, $routeParams) {

        $rootScope.title = "Edit profile";

        $scope.editProfile = function () {
            accountService.editProfile(
                $scope.user,
                function success(response) {
                    $location.path('/user/' + $scope.user.Username);
                    notifyService.showInfo("Your profile was successfully edited!");
                },
                function error(response) {
                    notifyService.showError("Failed to edit your profile", response['data']);
                }
            )
        };

        $scope.user = function () {
            accountService.getAccount(
                function success(response) {
                    $scope.user = response['data'];
                },
                function error(response) {
                    notifyService.showError("Failed load profile", response['data']);
                }
            )
        }

        $scope.fileSelected = function (fileInputField) {
            delete $scope.user.profilePicture;
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    $scope.user.ProfilePicture = reader.result;
                    $(".image-box").html("<img class='img-responsive avatar-img' src='" + $scope.user.ProfilePicture + "'>");
                };
                reader.readAsDataURL(file);
            } else {
                $(".image-box").html("<p>File type not supported!</p>");
            }
        };

        $scope.user();
        $scope.cities = citiesService.getCities();
    }
);
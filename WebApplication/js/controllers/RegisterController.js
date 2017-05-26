'use strict';

app.controller('RegisterController',
    function ($scope, $location, townsService, authService, notifyService) {
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
    }
);
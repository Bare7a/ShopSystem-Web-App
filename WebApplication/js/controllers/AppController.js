'use strict';

app.controller('AppController',
    function ($scope, $location, authService, notifyService) {

        $scope.authService = authService;

        $scope.location = $location;

        $scope.logout = function () {
            authService.logout();
            notifyService.showInfo("Logout successful");
            $location.path('/');
        }
    }
);
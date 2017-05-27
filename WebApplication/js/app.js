﻿var app = angular.module("WebApp", ['ngRoute', 'ngResource', 'ui.bootstrap']);

app.constant('baseServiceUrl', 'http://localhost:11184');
app.constant('pageSize', 4);

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when('/', {
        templateUrl: 'templates/home.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/login.html',
        controller: 'AuthController'
    });

    $routeProvider.otherwise(
        { redirectTo: '/' }
    );

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $locationProvider.html5Mode(true);
});

app.run(function ($rootScope, $location, authService) {
    $rootScope.$on('$locationChangeStart', function (event) {
        if ($location.path().indexOf("/user/") != -1 && !authService.isLoggedIn()) {
            $location.path('/login');
        }
    });

    $rootScope.$on('$locationChangeStart', function (event) {
        if ($location.path().indexOf("/admin/") != -1 && !authService.isAdmin()) {
            $location.path('/login');
        } else if (($location.path().indexOf('/user/') != -1) && authService.isAdmin()) {
            $location.path('/admin/home')
        }
    })
});
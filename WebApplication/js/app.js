var app = angular.module("WebApp", ['ngRoute', 'ngResource', 'ui.bootstrap'])
    .filter('trustAsResourceUrl', ['$sce', function ($sce) {
        return function (val) {
            return $sce.trustAsResourceUrl(val);
        };
    }]);

app.constant('baseServiceUrl', 'http://localhost:11184');
app.constant('productsPageSize', 7);
app.constant('userProductsPageSize', 10);
app.constant('messagesPageSize', 10);

app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    $routeProvider.when('/', {
        templateUrl: 'templates/products/products.html',
        controller: 'ListProductsController'
    });

    $routeProvider.when('/product/:id', {
        templateUrl: 'templates/products/product.html',
        controller: 'ViewProductController'
    });

    $routeProvider.when('/products/user', {
        templateUrl: 'templates/products/user-products.html',
        controller: 'ViewOwnProductsController'
    });

    $routeProvider.when('/products/add', {
        templateUrl: 'templates/products/add-product.html',
        controller: 'AddProductController'
    });

    $routeProvider.when('/products/edit/:id', {
        templateUrl: 'templates/products/edit-product.html',
        controller: 'EditProductsController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/users/login.html',
        controller: 'AuthController'
    });

    $routeProvider.when('/user/:username', {
        templateUrl: 'templates/users/profile.html',
        controller: 'ViewProfileController'
    });

    $routeProvider.when('/account/edit', {
        templateUrl: 'templates/users/edit-profile.html',
        controller: 'EditProfileController'
    });

    $routeProvider.when('/messages', {
        templateUrl: 'templates/messages/messages.html',
        controller: 'ListMessagesController'
    });

    $routeProvider.when('/message/:id', {
        templateUrl: 'templates/messages/message.html',
        controller: 'ViewMessageController'
    });

    $routeProvider.when('/messages/sent', {
        templateUrl: 'templates/messages/sent-message.html',
        controller: 'AddMessageController'
    });

    $routeProvider.when('/messages/sent/:username', {
        templateUrl: 'templates/messages/sent-message.html',
        controller: 'AddMessageController'
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
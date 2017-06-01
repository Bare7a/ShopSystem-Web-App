var app = angular.module("WebApp", ['ngRoute', 'ngResource', 'ui.bootstrap'])
    .filter('trustAsResourceUrl', ['$sce', function ($sce) {
        return function (val) {
            return $sce.trustAsResourceUrl(val);
        };
    }]);

app.constant('baseServiceUrl', 'http://localhost:11184');
app.constant('productsPageSize', 7);
app.constant('userProductsPageSize', 10);
app.constant('messagesPageSize', 20);

app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    $routeProvider.when('/', {
        templateUrl: 'templates/products/products.html',
        controller: 'ProductsController'
    });

    $routeProvider.when('/product/:id', {
        templateUrl: 'templates/products/product.html',
        controller: 'ProductDetailsController'
    });

    $routeProvider.when('/user/products', {
        templateUrl: 'templates/products/user-products.html',
        controller: 'UserProductsController'
    });

    $routeProvider.when('/products/add', {
        templateUrl: 'templates/products/add-product.html',
        controller: 'AddProductsController'
    });

    $routeProvider.when('/products/edit/:id', {
        templateUrl: 'templates/products/edit-product.html',
        controller: 'EditProductsController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/users/login.html',
        controller: 'AuthController'
    });

    $routeProvider.when('/messages', {
        templateUrl: 'templates/messages/messages.html',
        controller: 'MessagesController'
    });

    $routeProvider.when('/message/:id', {
        templateUrl: 'templates/messages/message.html',
        controller: 'MessagesController'
    });

    $routeProvider.when('/messages/sent', {
        templateUrl: 'templates/messages/sent-message.html',
        controller: 'MessagesController'
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
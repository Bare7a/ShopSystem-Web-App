'use strict';

app.factory('productService',
    function ($http, baseServiceUrl, authService) {
        return {
            getAllProducts: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Products',
                    params: params
                };

                $http(request).then(success, error);
            },

            getProductById: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Products/' + id,
                };

                $http(request).then(success, error);
            },

            createProduct: function (productData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Products',
                    headers: authService.getAuthHeaders(),
                    data: productData
                };

                $http(request).then(success, error);
            },

            getAllUserProducts: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/UserProducts',
                    headers: authService.getAuthHeaders(),
                    params: params
                };

                $http(request).then(success, error);
            },

            getAllComments: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Comments/' + id,
                };

                $http(request).then(success, error);
            },

            createComment: function (productId, commentData, success, error) {
                commentData.ProductId = productId;

                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Comments',
                    headers: authService.getAuthHeaders(),
                    data: commentData
                };

                $http(request).then(success, error);
            }
        }
    }
);

app.factory('citiesService',
    function ($resource, baseServiceUrl) {
        var citiesResource = $resource(
            baseServiceUrl + '/api/Cities',
            null,
            {
                'getAll': { method: 'GET' }
            }
        );

        return {
            getCities: function (success, error) {
                return citiesResource.query(success, error);
            }
        };
    }
);

app.factory('categoriesService',
    function ($resource, baseServiceUrl) {
        var categoriesResource = $resource(
            baseServiceUrl + '/api/Categories'
        );

        return {
            getCategories: function (success, error) {
                return categoriesResource.query(success, error);
            }
        };
    }
);
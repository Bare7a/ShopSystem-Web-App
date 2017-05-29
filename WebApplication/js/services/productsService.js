'use strict';

app.factory('productsService',
    function ($http, baseServiceUrl) {
        return {
            getAllProducts: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Products',
                    params: params
                };

                $http(request).then(success,error);
            },

            getProductById: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Products/' + id,
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
'use strict';

app.factory('productsService',
    function ($resource, baseServiceUrl) {
        var productsResource = $resource(
            baseServiceUrl + '/api/Products',
            null,
            {
                'getAll': {method:'GET'}
            }
        );

        return {
            getProducts: function(params, success, error) {
                return productsResource.getAll(params, success, error);
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
                'getAll': {method: 'GET'}
            }
        );

        return {
            getCities: function(success, error) {
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
            getCategories: function(success, error) {
                return categoriesResource.query(success, error);
            }
        };
    }
);
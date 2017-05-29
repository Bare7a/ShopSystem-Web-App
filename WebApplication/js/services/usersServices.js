app.factory('userService',
    function ($http, baseServiceUrl, authService) {
        return {
            createNewProduct: function (productData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Products',
                    headers: authService.getAuthHeaders(),
                    data: productData
                };

                $http(request).then(success, error);
            },

            createNewComment: function (productId, commentData, success, error) {
                commentData.ProductId = productId;

                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Comments',
                    headers: authService.getAuthHeaders(),
                    data: commentData
                };

                console.log(request);

                $http(request).then(success, error);
            },
        }
    });
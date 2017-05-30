app.factory('userService',
    function ($http, baseServiceUrl, authService) {
        return {
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

                console.log(request);

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
            },

            createMessage: function (messageData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Messages',
                    headers: authService.getAuthHeaders(),
                    data: messageData
                };

                $http(request).then(success, error);
            },

            getAllMessages: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Messages',
                    headers: authService.getAuthHeaders(),
                    params: params
                };

                $http(request).then(success, error);
            },

            getMessageById: function (id, success, error) {
                var request = {
                    method: 'GET',
                    headers: authService.getAuthHeaders(),
                    url: baseServiceUrl + '/api/Message/' + id
                };

                $http(request).then(success, error);
            }

        };
    });
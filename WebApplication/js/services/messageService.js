app.factory('messageService',
    function ($http, baseServiceUrl, authService) {
        return {


            createMessage: function (messageData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Messages',
                    headers: authService.getAuthHeaders(),
                    data: messageData
                };

                console.log(request);

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
                    url: baseServiceUrl + '/api/Messages/' + id
                };

                $http(request).then(success, error);
            }

        };
    });
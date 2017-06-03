'use strict';

app.factory('accountService',
    function ($http, baseServiceUrl, authService) {
        return {

            getProfile: function (username, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Account/UserInfo/' + username
                }

                $http(request).then(success, error);
            },

            editProfile: function (userData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/Account/EditProfile',
                    headers: authService.getAuthHeaders(),
                    data: userData
                };

                $http(request).then(success, error);
            },

            getAccount: function (success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Account/Info',
                    headers: authService.getAuthHeaders()
                };

                $http(request).then(success, error);
            },

            createFeedback: function (productId, commentData, success, error) {
                commentData.ProductId = productId;

                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Feedbacks',
                    headers: authService.getAuthHeaders(),
                    data: commentData
                };

                $http(request).then(success, error);
            },

            getAllFeedbacks: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/Feedbacks/' + id,
                };

                $http(request).then(success, error);
            }


        }
    }
);
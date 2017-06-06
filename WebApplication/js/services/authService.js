'use strict';

app.factory('authService',
    function ($http, baseServiceUrl) {
        return {
            login: function (userData, success, error) {
                var loginData = 'Username=' + userData.Username +
                    '&Password=' + userData.Password +
                    '&grant_type=password';

                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/Token',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: loginData
                };
                $http(request).then(function (response) {
                    sessionStorage['currentUser'] = JSON.stringify(response['data']);
                    success(response['data']);
                }, function (response) {
                    error(response['data']);
                });
            },

            register: function (userData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Account/Register',
                    data: userData
                };
                $http(request).then(function (response) {
                    success(response['data']);
                }, function (response) {
                    error(response['data']);
                });
            },

            logout: function () {
                sessionStorage.removeItem('currentUser');
            },

            getCurrentUser: function () {
                var userObject = sessionStorage['currentUser'];
                if (userObject) {
                    return JSON.parse(sessionStorage['currentUser']);
                }
            },

            getCurrentUsername: function () {
                var userObject = sessionStorage['currentUser'];
                if (userObject) {
                    return JSON.parse(userObject).userName;
                }
            },

            isAnonymous: function () {
                return sessionStorage['currentUser'] == undefined;
            },

            isLoggedIn: function () {
                return sessionStorage['currentUser'] != undefined;
            },

            isNormalUser: function () {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (!currentUser.isAdmin);
            },

            isAdmin: function () {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (currentUser.isAdmin);
            },

            getAuthHeaders: function () {
                var headers = {};
                var currentUser = this.getCurrentUser();

                if (currentUser) {
                    headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                }

                return headers;
            }
        }
    }
);
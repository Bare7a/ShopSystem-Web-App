'use strict';

app.factory('authService',
    function ($http, baseServiceUrl) {
        return {
            login: function (userData, success, error) {
                var loginData = 'Username=' + userData.username +
                    '&Password=' + userData.password +
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

            register: function(userData, success, error) {
                var registerData = 'Username=' + userData.username +
                    '&Password=' + userData.password +
                    '&ConfirmPassword=' + userData.confirmPassword +
                    '&Email=' + userData.email +
                    '&CityId=' + userData.cityId +
                    '&ProfilePicture=' + userData.profilePicture +
                    '&Facebook=' + userData.facebook +
                    '&Skype=' + userData.skype +
                    '&PhoneNumber=' + userData.phoneNumber;

                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/Account/Register',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: registerData
                };
                $http(request).then(function (response) {
                    success(response['data']);
                }, function (response) {
                    error(response['data']);
                });
            },

            logout: function() {
                sessionStorage.removeItem('currentUser');
            },

            getCurrentUser : function() {
                var userObject = sessionStorage['currentUser'];
                if (userObject) {
                    return JSON.parse(sessionStorage['currentUser']);
                }
            },

            isAnonymous: function () {
                return sessionStorage['currentUser'] == undefined;
            },

            isLoggedIn: function () {
                return sessionStorage['currentUser'] != undefined;
            },

            isNormalUser : function() {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (!currentUser.isAdmin);
            },

            isAdmin : function() {
                var currentUser = this.getCurrentUser();
                return (currentUser != undefined) && (currentUser.isAdmin);
            },

            getAuthHeaders : function() {
                var headers = {};
                var currentUser = this.getCurrentUser();
                if(currentUser) {
                    headers['Authorization'] = 'Bearer ' + currentUser.access_token;
                }
                return headers;
            }
        }
    }
);
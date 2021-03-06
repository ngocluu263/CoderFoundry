﻿angular.module('app')
    .factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = '/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        token: "",
        houseHold: ""
    };

    var _register = function (registration) {

        _logOut();

        return $http.post('/api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post('/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            _authentication.isAuth = true;
            _authentication.username = response.userName;
            _authentication.token = response.access_token;
            _authentication.houseHold = response.houseHold;

            localStorageService.set('authorizationData', _authentication);

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.username = "";
        _authentication.name = "";
        _authentication.claims = null;
        _authentication.token = "";
        _authentication.houseHold = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.username = authData.username;
            _authentication.token = authData.token;
            _authentication.houseHold = authData.houseHold;
        }

    }

    authServiceFactory.register = _register;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);
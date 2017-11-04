(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('authenticationService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;
               
        //Login
        var _login = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Account/Login', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };
               
        //Register
        var _register = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Account/Register', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };
        return {
            login: _login,
            register: _register
        };

    }]);
}());


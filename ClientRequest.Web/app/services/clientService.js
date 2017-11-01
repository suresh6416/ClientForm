(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('clientService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;

        //Get Clients
        var _getClients = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Client').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Save Client
        var _saveClient = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Client', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Check Is number exist or not
        var _isNumberExists = function (number) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Client/IsNumberExists?number=' + number).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Client By ID
        var _getById = function (id) {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Client/GetById/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Delete Client
        var _deleteClient = function (id) {
            var deferred = $q.defer();

            $http.delete(serviceBase + 'api/Client/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {
            getClients: _getClients,
            saveClients: _saveClient,
            isNumberExists: _isNumberExists,
            getById: _getById,
            deleteClient: _deleteClient
        };

    }]);
}());


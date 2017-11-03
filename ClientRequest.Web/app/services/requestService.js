(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('requestService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;

        //Get Requests
        var _getRequests = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Request').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Save Request
        var _saveRequest = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Request', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Check Is number exist or not
        var _isNumberExists = function (number) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Request/IsNumberExists?number=' + number).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Request By ID
        var _getById = function (id) {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Request/GetById/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Delete Request
        var _deleteRequest = function (id) {
            var deferred = $q.defer();

            $http.delete(serviceBase + 'api/Request/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {
            getRequests: _getRequests,
            saveRequests: _saveRequest,
            isNumberExists: _isNumberExists,
            getById: _getById,
            deleteRequest: _deleteRequest
        };

    }]);
}());


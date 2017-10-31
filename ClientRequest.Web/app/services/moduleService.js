(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('moduleService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;

        //Get Modules
        var _getModules = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Module').success(function (response) {                
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Save Modules
        var _saveModules = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Module', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Check Is number exist or not
        var _isNumberExists = function (number) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/Module/IsNumberExists?number=' + number).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Product By ID
        var _getById = function (id) {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/Module/GetById/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Product By ID
        var _deleteModule = function (id) {
            var deferred = $q.defer();

            $http.delete(serviceBase + 'api/Module/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {            
            getModules: _getModules,
            saveModules: _saveModules,
            isNumberExists: _isNumberExists,
            getById: _getById,
            deleteModule: _deleteModule
        };

    }]);
}());


(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('dataLookupService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;

        //Get Module Lookup
        var _getModuleLookup = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/DataLookup/ModuleLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };      

        //Get Job Nature Lookup
        var _getJobNatureLookup = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/DataLookup/JobNatureLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Module Lookup
        var _getClientLookup = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/DataLookup/ClientLookup').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {
            getModuleLookup: _getModuleLookup,
            getJobNatureLookup: _getJobNatureLookup,
            getClientLookup: _getClientLookup
        };

    }]);
}());


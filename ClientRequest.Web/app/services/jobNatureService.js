(function () {
    'use strict';

    angular.module('ClientRequestApp').factory('jobNatureService', ['$http', '$q', '$rootScope', 'clientRequestConstants', function ($http, $q, $rootScope, clientRequestConstants) {

        var serviceBase = clientRequestConstants.apiServiceBaseUri;

        //Get Job Natures
        var _getJobNatures = function () {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/JobNature').success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Save Job Nature
        var _saveJobNature = function (data) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/JobNature', data).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Check Is number exist or not
        var _isNumberExists = function (number) {
            var deferred = $q.defer();

            $http.post(serviceBase + 'api/JobNature/IsNumberExists?number=' + number).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Get Job Nature By ID
        var _getById = function (id) {
            var deferred = $q.defer();

            $http.get(serviceBase + 'api/JobNature/GetById/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        //Delete Job Nature
        var _deleteJobNature = function (id) {
            var deferred = $q.defer();

            $http.delete(serviceBase + 'api/JobNature/' + id).success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        };

        return {
            getJobNatures: _getJobNatures,
            saveJobNatures: _saveJobNature,
            isNumberExists: _isNumberExists,
            getById: _getById,
            deleteJobNature: _deleteJobNature
        };

    }]);
}());


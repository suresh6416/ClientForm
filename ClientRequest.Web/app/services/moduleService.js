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

        return {            
            getModules: _getModules
        };

    }]);
}());


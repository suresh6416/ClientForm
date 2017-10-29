angular.module('ClientRequestApp').controller('moduleController', ['$rootScope', '$scope', '$state', 'moduleService', function ($rootScope, $scope, $state, moduleService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.getModules();
    });

    $scope.getModules = function () {
        moduleService.getModules().then(function (response) {
            $scope.Modules = response.Data;
        }, function (err) {
            console.log(err);
        });
    };
}]);

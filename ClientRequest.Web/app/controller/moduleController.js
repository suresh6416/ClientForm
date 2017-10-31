angular.module('ClientRequestApp').controller('moduleController', ['$rootScope', '$scope', '$state', 'moduleService', function ($rootScope, $scope, $state, moduleService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Module = "";
        $scope.IsDuplicateNumber = false;
        $scope.getModules();
    });

    $scope.getModules = function () {
        moduleService.getModules().then(function (response) {
            $scope.Modules = response.Data;
        }, function (err) {
            console.log(err);
        });
    };    

    $scope.save = function () {
        debugger;
        if (!$scope.IsDuplicateNumber && $scope.frmModule.$valid) {
            moduleService.saveModules($scope.Module).then(function (response) {
                $scope.Module = "";
                $scope.getModules();
            }, function (err) {
                console.log(err);
            });
        }        
    };

    $scope.isNumberExists = function (number) {
        moduleService.isNumberExists(number).then(function (response) {
            $scope.IsDuplicateNumber = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getById = function (module) {
        moduleService.getById(module.ID).then(function (response) {
            $scope.Module = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.deleteModule = function (module) {
        moduleService.deleteModule(module.ID).then(function (response) {
            $scope.getModules();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.showAddModulePopup = function () {
        $scope.Module = "";
        $scope.IsDuplicateNumber = false;
    };
}]);

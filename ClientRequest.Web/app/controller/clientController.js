angular.module('ClientRequestApp').controller('clientController', ['$rootScope', '$scope', '$state', 'clientService', 'dataLookupService', function ($rootScope, $scope, $state, clientService, dataLookupService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Client = "";
        $scope.IsDuplicateNumber = false;
        $scope.getClients();
        $scope.getModuleLookup();
        $scope.SelectedModule = "";
        $scope.SelectedModuleList = [];
        $scope.ModuleLookup = [];
    });

    /*BEGIN: Get Module Lookup*/
    $scope.getModuleLookup = function () {
        dataLookupService.getModuleLookup().then(function (response) {
            $scope.ModuleLookup = response.Data;
            _.map($scope.ModuleLookup, function (data) {
                data.ModuleID = data.ID;
            });
        }, function (err) {
            console.log(err);
        });
    };
    /*END: Get Module Lookup*/

    $scope.getClients = function () {
        clientService.getClients().then(function (response) {
            $scope.Clients = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {       
        if (!$scope.IsDuplicateNumber && $scope.frmClient.$valid) {
            $scope.Client.ClientModules = $scope.SelectedModuleList;
            clientService.saveClients($scope.Client).then(function (response) {
                $scope.Client = "";
                $scope.SelectedModuleList = [];
                $scope.getModuleLookup();
                $scope.getClients();
                $('#addClientModel').modal('hide')
            }, function (err) {
                console.log(err);
            });
        }
    };

    $scope.isNumberExists = function (number) {
        clientService.isNumberExists(number).then(function (response) {
            $scope.IsDuplicateNumber = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getById = function (client) {
        clientService.getById(client.ID).then(function (response) {
            $scope.Client = response.Data;
            $scope.getModuleLookup();
            $scope.loadClientModules();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.loadClientModules = function () {
        $scope.SelectedModuleList = _.filter($scope.ModuleLookup, function (a) {
            return _.find($scope.Client.ClientModules, function (b) {
                return b.ModuleID === a.ID;
            });
        });
        $scope.ModuleLookup = $scope.ModuleLookup.filter(function (el) {
            return !$scope.SelectedModuleList.includes(el);
        });
    }   

    $scope.deleteClient = function (client) {
        clientService.deleteClient(client.ID).then(function (response) {
            $scope.getClients();
        }, function (err) {
            console.log(err);
        });
    };
       
    $scope.addModule = function (module) {
        if (module !== null) {
            $scope.ModuleLookup = _.without($scope.ModuleLookup, _.findWhere($scope.ModuleLookup, {
                ID: module.ID
            }));
            $scope.SelectedModuleList.push(module);
        }        
    };

    $scope.clearClient = function (module) {
        if (module !== null) {
            $scope.SelectedModuleList = _.without($scope.SelectedModuleList, _.findWhere($scope.SelectedModuleList, {
                ID: module.ID
            }));
            $scope.ModuleLookup.push(module);
        }
    };

    $scope.showAddClientPopup = function () {
        $scope.Client = "";
        $scope.IsDuplicateNumber = false;
        $scope.SelectedModuleList = [];
    };
}]);

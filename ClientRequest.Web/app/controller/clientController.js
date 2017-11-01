angular.module('ClientRequestApp').controller('clientController', ['$rootScope', '$scope', '$state', 'clientService', function ($rootScope, $scope, $state, clientService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Client = "";
        $scope.IsDuplicateNumber = false;
        $scope.getClients();
    });

    $scope.getClients = function () {
        clientService.getClients().then(function (response) {
            $scope.Clients = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        if (!$scope.IsDuplicateNumber && $scope.frmClient.$valid) {
            clientService.saveClients($scope.Client).then(function (response) {
                $scope.Client = "";
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
        }, function (err) {
            console.log(err);
        });
    };

    $scope.deleteClient = function (client) {
        clientService.deleteClient(client.ID).then(function (response) {
            $scope.getClients();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.showAddClientPopup = function () {
        $scope.Client = "";
        $scope.IsDuplicateNumber = false;
    };
}]);

angular.module('ClientRequestApp').controller('requestController', ['$rootScope', '$scope', '$state', 'requestService', 'dataLookupService', function ($rootScope, $scope, $state, requestService, dataLookupService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Request = "";
        $scope.IsDuplicateNumber = false;
        $scope.getRequests();
        $scope.SelectedModule = "";
        $scope.SelectedJobNature = "";
        $scope.SelectedClient =
        $scope.SelectedWorkAssigned = "";
        $scope.SelectedCRW = "";
        $scope.getClientLookup();
        $scope.getModuleLookup();
        $scope.getJobNatureLookup();
        $scope.RequestDate = (new Date()).toDateString();
        $scope.RequestBy = "suresh@gmail.com";

        $scope.WorkAssignedToLookup = [
               { ID: 1, Number: 'WA-101', Name: 'suresh@gmail.com' },
               { ID: 2, Number: 'WA-102', Name: 'indra.217@gmail.com' },
               { ID: 3, Number: 'WA-103', Name: 'tulasi@gmail.com' },
               { ID: 4, Number: 'WA-104', Name: 'ruthvika@gmail.com' }
        ];

        $scope.CRWToLookup = [
               { ID: 1, Number: 'WA-101', Name: 'mahesh@gmail.com' },
               { ID: 2, Number: 'WA-102', Name: 'phani@gmail.com' },
               { ID: 3, Number: 'WA-103', Name: 'suresh@gmail.com' },
               { ID: 4, Number: 'WA-104', Name: 'ruthvika@gmail.com' }
        ];
    });

    /*BEGIN: Get Module Lookup*/
    $scope.getClientLookup = function () {
        dataLookupService.getClientLookup().then(function (response) {
            $scope.ClientLookup = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getModuleLookup = function () {
        dataLookupService.getModuleLookup().then(function (response) {
            $scope.ModuleLookup = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getJobNatureLookup = function () {
        dataLookupService.getJobNatureLookup().then(function (response) {
            $scope.JobNatureLookup = response.Data;
        }, function (err) {
            console.log(err);
        });
    };
    /*END: Get Module Lookup*/

    $scope.getRequests = function () {
        requestService.getRequests().then(function (response) {
            $scope.Requests = response.Data; 
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        if (!$scope.IsDuplicateNumber && $scope.frmRequest.$valid) {

            $scope.Request.RequestedOn = $scope.RequestDate;
            $scope.Request.RequestedBy = $scope.RequestBy;
            $scope.Request.AssignedTo = $scope.SelectedWorkAssigned.Name;
            $scope.Request.CRW = $scope.SelectedCRW.Name;
            $scope.Request.ClientID = $scope.SelectedClient.ID;
            $scope.Request.ModuleID = $scope.SelectedModule.ID;
            $scope.Request.JobNatureID = $scope.SelectedJobNature.ID;

            requestService.saveRequests($scope.Request).then(function (response) {
                $scope.Request = "";
                $scope.getRequests();
                $('#addRequestModel').modal('hide')
            }, function (err) {
                console.log(err);
            });
        }
    };

    $scope.isNumberExists = function (number) {
        requestService.isNumberExists(number).then(function (response) {
            $scope.IsDuplicateNumber = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getById = function (request) {
        requestService.getById(request.ID).then(function (response) {
            $scope.Request = response.Data;

            $scope.SelectedWorkAssigned = $scope.WorkAssignedToLookup.find(function (d) { return d.Name === $scope.Request.AssignedTo; })
            $scope.SelectedCRW = $scope.CRWToLookup.find(function (d) { return d.Name === $scope.Request.CRW; })
            $scope.SelectedClient = $scope.ClientLookup.find(function (d) { return d.ID === $scope.Request.ClientID; })
            $scope.SelectedModule = $scope.ModuleLookup.find(function (d) { return d.ID === $scope.Request.ModuleID; })
            $scope.SelectedJobNature = $scope.JobNatureLookup.find(function (d) { return d.ID === $scope.Request.JobNatureID; })

        }, function (err) {
            console.log(err);
        });
    };

    $scope.deleteRequest = function (request) {
        requestService.deleteRequest(request.ID).then(function (response) {
            $scope.getRequests();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.showAddRequestPopup = function () {
        $scope.Request = "";
        $scope.IsDuplicateNumber = false;

        $scope.SelectedModule = "";
        $scope.SelectedJobNature = "";
        $scope.SelectedClient =
        $scope.SelectedWorkAssigned = "";
        $scope.SelectedCRW = "";
    };
}]);

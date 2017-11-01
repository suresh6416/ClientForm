angular.module('ClientRequestApp').controller('jobNatureController', ['$rootScope', '$scope', '$state', 'jobNatureService', function ($rootScope, $scope, $state, jobNatureService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.JobNature = "";
        $scope.IsDuplicateNumber = false;
        $scope.getJobNatures();
    });

    $scope.getJobNatures = function () {
        jobNatureService.getJobNatures().then(function (response) {
            $scope.JobNatures = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.save = function () {
        if (!$scope.IsDuplicateNumber && $scope.frmJobNature.$valid) {
            jobNatureService.saveJobNatures($scope.JobNature).then(function (response) {
                $scope.JobNature = "";
                $scope.getJobNatures();
                $('#addJobNatureModel').modal('hide')
            }, function (err) {
                console.log(err);
            });
        }
    };

    $scope.isNumberExists = function (number) {
        jobNatureService.isNumberExists(number).then(function (response) {
            $scope.IsDuplicateNumber = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.getById = function (jobNature) {
        jobNatureService.getById(jobNature.ID).then(function (response) {
            $scope.JobNature = response.Data;
        }, function (err) {
            console.log(err);
        });
    };

    $scope.deleteJobNature = function (jobNature) {
        jobNatureService.deleteJobNature(jobNature.ID).then(function (response) {
            $scope.getJobNatures();
        }, function (err) {
            console.log(err);
        });
    };

    $scope.showAddJobNaturePopup = function () {
        $scope.JobNature = "";
        $scope.IsDuplicateNumber = false;
    };
}]);

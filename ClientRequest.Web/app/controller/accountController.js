angular.module('ClientRequestApp').controller('accountController', ['$rootScope', '$scope', '$state', 'authenticationService', function ($rootScope, $scope, $state, authenticationService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Login = "";
    });

    $scope.login = function () {
        authenticationService.login($scope.Login).then(function (response) {
            if (response.Data === 0) {
                $state.go('welcome.dashboard', {
                    email: $scope.Login.Email
                });
            }
        }, function (err) {
            console.log(err);
        });
    };

    $scope.clear = function () {
        $scope.Login.Email = "";
        $scope.Login.Password = "";
    };
}]);

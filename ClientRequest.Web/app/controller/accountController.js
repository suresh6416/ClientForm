angular.module('ClientRequestApp').controller('accountController', ['$rootScope', '$scope', '$state', 'authenticationService', function ($rootScope, $scope, $state, authenticationService) {
    $scope.$on('$viewContentLoaded', function () {
        $scope.Login = "";
        $scope.Register = "";
        $scope.IsInvalid = false;
    });

    $scope.login = function () {
        authenticationService.login($scope.Login).then(function (response) {
            if (response.Data === 0) {
                $state.go('welcome.dashboard', {
                    email: $scope.Login.Email
                });
            }
            else {
                $scope.IsInvalid = true;
            }
        }, function (err) {
            console.log(err);
        });
    };

    $scope.register = function () {
        authenticationService.register($scope.Register).then(function (response) {
            $state.go('login');
        }, function (err) {
            console.log(err);
        });
    };

    $scope.cancelRegister = function () {
        $state.go('login');
    };

    $scope.clearLogin = function () {
        $scope.Login.Email = "";
        $scope.Login.Password = "";
    };
}]);

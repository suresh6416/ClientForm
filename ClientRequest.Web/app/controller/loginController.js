angular.module('ClientRequestApp').controller('loginController', ['$rootScope', '$scope', '$state', function ($rootScope, $scope, $state) {
    $scope.$on('$viewContentLoaded', function () {

        $scope.pageMode = "login";

        $scope.switchPageMode(pageMode)
        {
            $scope.pageMode = pageMode;
        }

        $scope.login = function () {

        };

        $scope.register = function () {

        };
    });
}]);

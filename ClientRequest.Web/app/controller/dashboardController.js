angular.module('ClientRequestApp').controller('dashboardController', ['$rootScope', '$scope', '$state', '$localStorage', '$sessionStorage', function ($rootScope, $scope, $state, $localStorage, $sessionStorage) {
    $scope.$on('$viewContentLoaded', function () {
        if ($state.params.email !== '') {
            $localStorage.loggedInUser = $state.params.email;
            $rootScope.loggedInUser = $localStorage.loggedInUser;
        }        
    });
}]);

var ClientRequestApp = angular.module('ClientRequestApp', ['ui.router', 'oc.lazyLoad', 'ui.bootstrap']);

ClientRequestApp.controller('appController', ['$rootScope', '$scope', function ($rootScope, $scope) {
    $scope.$on('$viewContentLoaded', function () {

    });
}]);

ClientRequestApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', function ($stateProvider, $urlRouterProvider, $httpProvider) {

    $urlRouterProvider.otherwise("/welcome/dashboard");
    var WEB_APP_NAME = "ClientRequestApp";

    $stateProvider
        .state('welcome', {
            url: '/welcome',
            abtract: true,
            templateUrl: 'app/views/layout/layout.html'
        })        
        .state('welcome.dashboard', {
            url: '/dashboard',
            templateUrl: 'app/views/dashboard.html',
            data: { pageTitle: 'Dashboard' }           
        })
        .state('welcome.requests', {
            url: '/requests',
            templateUrl: 'app/views/requests.html',
            data: { pageTitle: 'Requests' },
            controller: "requestController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controller/requestController.js'
                        ]
                    });
                }]
            }
        })
        .state('welcome.clients', {
            url: '/clients',
            templateUrl: 'app/views/clients.html',
            data: { pageTitle: 'Clients' },
            controller: "clientController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controller/clientController.js'
                        ]
                    });
                }]
            }
        })
        .state('welcome.module', {
            url: '/module',
            templateUrl: 'app/views/module.html',
            data: { pageTitle: 'Modules' },
            controller: "moduleController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controller/moduleController.js'
                        ]
                    });
                }]
            }
        })
        .state('welcome.jobNature', {
            url: '/jobNature',
            templateUrl: 'app/views/jobNature.html',
            data: { pageTitle: 'Job Nature' },
            controller: "jobNatureController",
            resolve: {
                deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: WEB_APP_NAME,
                        files: [
                            'app/controller/jobNatureController.js'
                        ]
                    });
                }]
            }
        });
}]);

/*Setup Client Request Constants*/
ClientRequestApp.constant('clientRequestConstants', {
    apiServiceBaseUri: 'http://clientrequest-api/'
});

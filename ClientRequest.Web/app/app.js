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
            templateUrl: 'app/views/layout/layout.html'
        })
        //.state('welcome.login', {
        //    url: '/home',
        //    templateUrl: 'app/views/login.html',
        //    data: { pageTitle: 'Login' },
        //    controller: "loginController",
        //    resolve: {
        //        deps: ['$ocLazyLoad', function ($ocLazyLoad) {
        //            return $ocLazyLoad.load({
        //                name: WEB_APP_NAME,
        //                files: [
        //                    'app/controller/loginController.js'
        //                ]
        //            });
        //        }]
        //    }
        //})
        .state('welcome.dashboard', {
            url: '/dashboard',
            templateUrl: 'app/views/dashboard.html',
            data: { pageTitle: 'Dashboard' }           
        })
        //.state('welcome.home', {
        //    url: '/home',
        //    templateUrl: 'app/views/home.html',
        //    data: { pageTitle: 'Home' },
        //    controller: "homeController",
        //    resolve: {
        //        deps: ['$ocLazyLoad', function ($ocLazyLoad) {
        //            return $ocLazyLoad.load({
        //                name: WEB_APP_NAME,
        //                files: [
        //                    'app/controller/homeController.js'
        //                ]
        //            });
        //        }]
        //    }
        //})
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
    });
}]);

/*Setup Client Request Constants*/
ClientRequestApp.constant('clientRequestConstants', {
    apiServiceBaseUri: 'http://clientrequest-api/'
});

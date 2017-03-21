var myApp = angular.module('myApp', ['ui.router', 'ui.bootstrap']);

myApp.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider.state('index', {
        url: "/",
        templateUrl: "../Scripts/app/templates/home.html",
        controller: "homeCtrl",
        controllerAs: "hm"
    })
    .state('pizza', {
        url: '/pizza',
        params: {
            pid: 0
        },
        templateUrl: '../Scripts/app/templates/pizza.html',
        controller: "pizzaCtrl",
        controllerAs: "piz"
    })
    .state('detail', {
        url: '/pizza/detail/:pid',
        templateUrl: '../Scripts/app/templates/ingredient.html',
        controller: 'ingredientCtrl',
        controllerAs: 'ig'
    });
    //$locationProvider.html5Mode(true);
    //$locationProvider.hashPrefix('!');
}]);

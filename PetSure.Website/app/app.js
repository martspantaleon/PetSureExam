var app = angular.module("PetSure", ["ngRoute", "ngResource"]).constant("appSettings", { serverPath: "http://localhost/Pet.Sure1/api/" });
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
    .when("/index.html", {
        templateUrl: "index.html"
    }).otherwise({
        redirectTo: '/index.html'
    });

    $locationProvider.html5Mode(true);
});


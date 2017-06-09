var app = angular.module("app", ["ngRoute", "ngSanitize"]);

app.config(function ($routeProvider) {
    $routeProvider.
        when("/candidate", {
            templateUrl: "app/views/candidate/index.html",
            controller: "candidateCtrl"
        }).
      otherwise({
          redirectTo: "/candidate"
      });
});
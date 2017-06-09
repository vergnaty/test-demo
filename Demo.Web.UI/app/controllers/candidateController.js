(function () {
    'use strict';
    angular
        .module('app')
        .controller("candidateCtrl", ['$scope', '$http', '$rootScope', '$location', candidateCtrl]);

    /***********************************
    *       this Controller
    *    Manage Candidates Page
    ************************************/
    function candidateCtrl($scope, $http, $rootScope, $location) {
        var url = "http://localhost:50138/api/v1/candidate/";

        $scope.candidates = null;
        $scope.selectedCandidate = null;

        $scope.loadCandidates = loadCandidates;
        $scope.selectCandidate = selectCandidate;

        function loadCandidates() {
            $http.get(url + "items").then(function (response) {
                console.log(response);
                $scope.candidates = response.data;
            }, function (error) {
            });
        }

       
        function selectCandidate(id) {
            $http.get(url + id).then(function (response) {
                $scope.selectedCandidate = response.data;
            }, function (error) {
            });
        }
    }
})();
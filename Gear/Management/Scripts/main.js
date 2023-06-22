var myApp = angular.module('gearCMS', []);

myApp.controller('main', ['$scope','$http','$sce', function ($scope, $http, $sce) {

    $scope.getPages = function () {
        $http.post('/gearcms/api/getpages').then(function (response) {
           $scope.pages = response.data;
        }, function (response) {
            console.log("error");
        });
    }

    $scope.getPage = function (id) {
        console.log({ pageid: id });
        $http.post('/gearcms/api/getpage', {pageid : id}, ).then(function (response) {
            console.log(response.data);
        }, function (response) {
            console.log("error");
        });
    }

    $scope.getPages();
}]);

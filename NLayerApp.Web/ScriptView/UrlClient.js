var app = angular.module('urlApp',[]);

app.service('DataLoaderService', ['$http', function ($http) {

    this.saveUrlRequest = function (callback, url) { 
        $http.post("/HOME/Create?url=" + url)
          .then(callback)
            .catch(function () {
                console.log(Object.data);
                alert("Ошибка при обработке запроса");
            });
    };
}]);

app.controller('FormUrlCtrl', ['$scope', '$http', 'DataLoaderService', function ($scope, $http, DataLoaderService) {
 
    $scope.url = '';
    $scope.shortUrl = '';
 
    $scope.Create = function () {
     
        DataLoaderService.saveUrlRequest($scope.onRequestSaved, $scope.url);
    };

    $scope.onRequestSaved = function (url) {
        $scope.shortUrl = url.data;
       
        
      
    };
  
}]);
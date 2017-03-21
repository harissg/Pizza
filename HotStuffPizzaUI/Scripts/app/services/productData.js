myApp.factory('productData', ['$http', function ($http) {
    return homeFactory = {
        getProducts: getProducts,
        getProductIngredients: getProductIngredients
    }

    function getProducts(id) {
        return $http.get('http://localhost:62530/' + 'api/Product/GetProducts?type=' + id)
            .then(function (data) {
                return data;
            }, function (error) {
                console.log(error);
            });
    }

    function getProductIngredients(id) {
        return $http.get('http://localhost:62530/' + 'api/Product/getProductIngredients?productId=' + id)
           .then(function (data) {
               return data;
           }, function (error) {
               console.log(error);
           });
    }
}]);
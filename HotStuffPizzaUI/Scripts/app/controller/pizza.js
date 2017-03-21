myApp.controller("pizzaCtrl", ['$scope', '$state', 'productData', function ($scope, $state, productData) {
    var piz = this;
    piz.load = load;
    piz.products = [];
    piz.ingredients = ingredients;
    piz.filter = filter;

    load();

    function filter(search) {
        if (search.length >= 3) {
            //then do something
        }
    }

    function load() {
        productData.getProducts(1).then(function (success) {
            piz.products = success.data;
        });
    }

    function ingredients(id) {
        $state.go('detail', { pid: id });
    }
}]);

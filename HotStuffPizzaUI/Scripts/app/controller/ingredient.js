myApp.controller("ingredientCtrl", ['$scope', '$state', 'productData', '$stateParams', function ($scope, $state, productData, $stateParams) {
    var ig = this;
    ig.load = load;
    ig.ingredients = [];


    load();

    function load() {
        productData.getProductIngredients($stateParams.pid).then(function (success) {
            ig.ingredients = success.data;
        });
    }
}]);

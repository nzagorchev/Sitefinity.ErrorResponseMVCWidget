var designerModule = angular.module('designer');

designerModule.controller("DefaultCtrl", ['$scope', 'propertyService', function ($scope, propertyService) {

    $scope.properties = null;
    $scope.feedback.showLoadingIndicator = true;

    propertyService.get()
        .then(function (data) {
            $scope.properties = propertyService.toAssociativeArray(data.Items);
            $scope.options = JSON.parse($scope.properties.Options.PropertyValue);
            
            $scope.selectedOption = {
                Status: $scope.properties.Status.PropertyValue,
                StatusCode: $scope.properties.StatusCode.PropertyValue
            };
        })
        .catch(function (data) {
            $scope.feedback.showError = true;
            if (data)
                $scope.feedback.errorMessage = data.Detail;
        })
        .finally(function () {
            $scope.feedback.showLoadingIndicator = false;
        });

    $scope.selectOption = function (val) {
    };

    $scope.$watch('selectedOption', function (newValue, oldValue) {
        if (newValue) {
            $scope.properties.Status.PropertyValue = newValue.Status;
            $scope.properties.StatusCode.PropertyValue = newValue.StatusCode;
        }
    });
}]);
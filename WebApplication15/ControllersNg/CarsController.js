angular.module('myFormApp', ['ngMaterial','ngMessages']).
    controller('CarsController', function ($scope, $http, $location, $window, $mdDialog ) {
        $scope.message = '';
        $scope.isViewLoading = true;
        $scope.loaded = false;
        $scope.result = "color-default";
        load();

        $scope.showModalDialog = function (ev, model = null) {
            $mdDialog.show({
                locals: { model: model },
                templateUrl: 'Home/CreateDialog',
                controller: dialogController,
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true,
                onRemoving: function (event) {
                    $window.location.reload();
                }
            });
        };

        $scope.remove = function (id) {
            $scope.isViewLoading = true;
            $http.delete('api/cars/' + id).
                then(function success() {
                    $scope.cars = $scope.cars.filter(item => item.Id !== id);
                    $scope.isViewLoading = false;
                }, function error(response) {
                        console.log("Возникла ошибка");
                        console.log("код ответа: " + response.status);
                }
            );
        };

        function load() {
            $http.get('api/cars').then(function success(response) {
                $scope.cars = response.data;
                $scope.loaded = true;
                    $scope.isViewLoading = false;
                }, function error(response) {
                    console.log("Возникла ошибка");
                    console.log("код ответа: " + response.status);
                    $scope.message = 'Cant load data';
                }
            );
        }

        function dialogController($scope, $mdDialog, model) {
            $scope.model = model;
            load();
            $scope.backup = Object.assign({}, model);
            $scope.submitEdit = function () {
                $scope.isViewLoading = true;
                $scope.model.Mark = $scope.model.SelectedMark.MarkId;
                $scope.model.Model = $scope.model.SelectedModel;

                $http({
                    method: 'PUT',
                    url: 'api/cars/' + $scope.model.Id,
                    data: $scope.model
                }).then(function success(response) {
                    $scope.isViewLoading = false;
                    close(response.status === 200);
                });
            }
            $scope.submitCreate = function () {
                $scope.isViewLoading = true;
                $scope.model.Mark = $scope.model.SelectedMark.MarkId;
                $scope.model.Model = $scope.model.SelectedModel;

                $http({
                    method: 'POST',
                    url: 'api/cars',
                    data: $scope.model
                }).then(function success(response) {
                    $scope.isViewLoading = false;
                    close(response.status === 200);
                });
            }
            $mdDialog.cancel = function () {
                close(false);
            }

            function close(success) {
                if (!success) {
                    $scope.model = $scope.backup;
                }
                $mdDialog.hide();
            }

            function load() {
                $http.get('api/cars/attributes').
                    then(function success(response) {
                        $scope.attributes = response.data;
                        if ($scope.model != null) {
                            $scope.model.SelectedMark = response.data.find(e => e.MarkName === model.Mark);
                            $scope.model.SelectedModel = ($scope.model.SelectedMark.Models.find(e => e.Name === model.Model)).Id;
                        }
                    }, function error(response) {
                        console.log("Возникла ошибка код ответа:" + response.status);
                        close(false);
                    }
                );
            }
        }

    })
.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});

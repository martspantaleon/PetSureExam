angular.module('PetSure').controller('PetSureController', ['$scope', 'PetSureService', 'appSettings', function (scope, PetSureService, appSettings) {


    //Getting the list of pets owned dropdown
    scope.getPetNameList = function () {
        PetSureService.getPetList().then(function (result) {
            scope.PetNameList = result;
        });
    };


    scope.uploadFile = function () {

        http({
            method: 'POST',
            url: appSettings.serverPath + 'Index/PostFileWithData',
            headers: { 'Content-Type': undefined },

            transformRequest: function (data) {
                var formData = new FormData();
                for (var i = 0; i < data.files.length; i++) {
                    formData.append("file" + i, data.files[i]);
                }
                return formData;
            },
            data: { files: scope.files }
        }).success(function () {

        });
    };

    //calling the function
    scope.getPetNameList();

}]);
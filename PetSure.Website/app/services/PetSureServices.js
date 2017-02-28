app.factory('PetSureService', ['$resource', '$http', 'appSettings', function (resource, http, appSettings) {

    return {
        getPetList: function () {
            return http.get(appSettings.serverPath + 'Index/PetList').then(function (result) {
                return result.data.Data;
            })
        },
    }
}]);

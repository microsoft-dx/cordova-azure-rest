(function () {
	'use strict';

	angular.module('xPlat.services').service('azureStorage', ['$http', '$resource', 'guidGenerator', AzureStorage]);

	/**
	 * Azure Application URL.
	 * TODO: Add your Azure App URL.
	 *
	 * @type {string}
	 * @const
	 */
	//var AZURE_API_ADDRESS = 'http://youraddress.azurewebsites.net';
	var AZURE_API_ADDRESS = 'http://localhost:11591';

	/**
	 * Use Azure to store todo items in the cloud.
	 *
	 * @param {angular.Service} $resource
	 * @param {angular.Service} guidGenerator
	 * @constructor
	 */
	function AzureStorage($http, $resource, guidGenerator) {
	    this.isAvailable = true;
	    this.httpClient = $http;
	    this.guidGenerator = guidGenerator;
	}

    AzureStorage.prototype.getAll = function () {

        return this.httpClient.get(AZURE_API_ADDRESS + '/api/todo')
            .then(function (response) {
                var items = response.data;
                console.log("items:");
                console.log(items);
                return items;
            }, handleError);
    };

    function refreshList(thisArg) {

        return this.httpClient.get(AZURE_API_ADDRESS + '/api/todo' + id)
            .then(function (items) {
                var items = response.data;
                console.log("refresh items:");
                console.log(items);
                return items;
            }, handleError);
    }

    function createTodoItemList(items) {
        return items;
    }

	/**
	 * Create a new todo to Azure storage.
	 *
	 * @param {string} text Text of the todo item.
	 * @param {string} address Address of the todo item.
	 */
    AzureStorage.prototype.create = function (itemText, itemAddress) {

	    console.log("creating..." + itemText);
	    return this.httpClient.post(AZURE_API_ADDRESS + '/api/todo', {
            id: this.guidGenerator.get(),
	        text: itemText,
            address: itemAddress,
	        complete: false
	    }).then(success, handleError);
	};

	/**
	 * Update an existing todo in Azure storage.
	 *
	 * @param {Object} item Todo item to modify.
	 */
	AzureStorage.prototype.update = function (item) {

	    return this.httpClient.put(AZURE_API_ADDRESS + '/api/todo', item).then(success, handleError);
	};

	/**
	 * Remove a todo from Azure storage.
	 *
	 * @param {Object} item Todo item to remove from local storage.
	 */
	AzureStorage.prototype.del = function (item) {

	    return this.httpClient.delete(AZURE_API_ADDRESS + '/api/todo/' + item.id).then(success, handleError);
	};

	function handleError(error) {
	    var text = error + (error.request ? ' - ' + error.request.status : '');
	    console.error(text);
	    console.log('error', error.request.status);
	    if (error.request.status == '0' || error.request.status == '404') {
	        alert({
	            title: 'Connection Failure',
	            template: 'Connection with backend can not be established.'
	        });
	    }
	}

	function success(retVal) {
	    console.log("successful operation");
	    return retVal.data;
	}

})();
Creating the ASP.NET Backend
============================

Introduction
------------

> ASP.NET Web API is a framework that makes it easy to build HTTP services that reach a broad range of clients, including browsers and mobile devices. ASP.NET Web API is an ideal platform for building RESTful applications on the .NET Framework.

> More on [the Official ASP .NET WebApi Documentation](https://www.asp.net/web-api)


Creating an empty ASP .NET WebApi application
----------------------------------------------

First of all, let’s see how we create a WebApi solution from Visual Studio. We click New Project, then from Web we select ASP.NET Web Application, choose a name and then click Ok.

![](https://media-www-asp.azureedge.net/media/4410043/getstarted01.png)

Next, choose an Empty template from ASP.NET 4.6 Templates, with WebApi folders included, with No Authentication and not Hosted in the Cloud. 

![](https://media-www-asp.azureedge.net/media/4410055/getstarted02.png)

Now we have a basic structure for implementing a web service that will help us Create, Read, Update and Delete ToDo items in our mobile applications.

Cloning the GitHub repository
-----------------------------

In this repository there are 2 braches: `master`, which contains the completed application and solution and `development`, which we will use for this workshop.

Go to [the development branch of this repository](https://github.com/microsoft-dx/cordova-azure-rest/tree/development) and either clone it locally (if you are familiar with GitHub) or just download it as a ZIP file.

> If you have [git-scm](https://git-scm.com/) installed or other source control management tools, you can use the following command: `git clone -b development https://github.com/microsoft-dx/cordova-azure-rest`.

Then navigate to the `src/AspNetToDoApi/` folder and open `AspNetToDoApi.sln` file with Visual Studio 2015. This will open two projects, the .NET backend and the mobile application.

![](../media/solution-projects.png)

Examining the .NET backend
--------------------------

Looking at what was created, we can see a few classes:

- `ToDoItem` - this class represents our to do object we will pass between the mobile application and the backend and has an id, some text, geographical coordinates of the place it was created from and a true/false value that marks if the item has been done. It also has two constructors (why?) and a method for updating the properties.

A model is an object that represents data in your application. It should contain all validation needed and all business logic.  ASP.NET WebApi can automatically serialize the models to JSON or XML, all you have to do is make sure the client (mobile application in our case) knows how to interpret the data it receives.

- `ToDoRepository` – almost all non-trivial applications have to retrieve  data from a data store – SQL database, NoSQL database, a cache or any other data store. Directly accessing the data can result in duplicated code, higher potential for errors, the inability to centralize the database access and the possibility to interchange components. 

> [For more information on the repository pattern, see this article](https://msdn.microsoft.com/en-us/library/ff649690.aspx)

The best practice when working with a data store is to separate the logic of accessing and modifying the database as a separate component. This separate component, along with the model, should contain all business logic and validation.

![](../media/repository.png)

For our web service, we keep the items in-memory. So, the place where we keep the data will be a list of items that we will query for getting all items, getting an item by id, adding, removing and updating an item. 
 
Then, wherever we want to access our stored to do items, we just have a ToDoRepository property and call the appropriate method. 

- `ToDoController` - in WebApi, a controller is an object that handles HTTP requests. Each request is mapped to a particular controller, and based on the parameters of the request, to a specific action (method) on the controller. 

Before the implementation of a controller method (action), we can specify the HTTP verb that this controller action will use: [HttpGet], [HttpPost], [HttpDelete], etc. 

> An important thing to remember when working with controllers is that the framework always creates a new instance on every request. This is the reason why in this case (remember this is a mock project) – our repository is created as static – so only a single instance of it exists, regardless of how many objects are instantiated.  

Creating the controller methods
-------------------------------

Your task is to create the appropriate controller methods required in order to Create, Read, Update and Delete to do items in the application. Remember to follow the REST standard and specify the HTTP method you want to use.

This is how the ToDoController should look like

```
using AspNetToDoApi.DAL;
using AspNetToDoApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AspNetToDoApi.Controllers
{
    public class ToDoController : ApiController
    {
        private static ToDoRepository _toDoRepository = new ToDoRepository();
        
         [HttpGet]
         public List<ToDoItem> GetAll()
        {
            return _toDoRepository.GetToDoItems();
        }

        [HttpGet]
        public ToDoItem GetById(Guid id)
        {
            return _toDoRepository.GetById(id);
        }

        [HttpPost]
        public ToDoItem Create(ToDoItem item)
        {
            _toDoRepository.CreateToDo(item);
            return item;
        }

        [HttpPut]
        public ToDoItem Update(ToDoItem item)
        {
            _toDoRepository.Update(item);
            return item;
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            _toDoRepository.Delete(id);
            return Ok();
        }
    }
}
```

Testing the application locally
-------------------------------

Now that you created the controller methods, it is time to test the application, and we will do this in several ways:

- using the browser: start the project from Visual Studio, open a new browser tab and navigate to `http://localhost:port-number/api/todo`  - because from accessing a URL from the browser you can only execute a `GET` request in order to test the other controller methods we will need an additional tool.

- using [PostMan](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop) - a Google Chrome extension that makes it easy to make HTTP requests.

![](../media/postman-local.png)

We can also get just one item from the backend using the id:

![](../media/postman-id.png)

You can also execute POST, PUT or DELETE requests with the appropriate method and parameters.

- using the ToDo mobile application - in the same Visual Studio solution there is another project called `AngularJSTodoApp` that contains the Cordova mobile application. Executing right click --> Debug --> Start new instance should trigger the build process that will start a new browser tab with the Android mobile emulator with the application. If everything works well, you should see something similar to:

![](../media/cordova-local.png)

The application is fully functional, you can add items, mark them as completed or delete them.
You can see that the changes are persistant - you can modify with PostMan and check in the application or the other way around.

Publishing the application to the Cloud - Azure
------------------------------------------------

Assuming you created a Microsoft Azure account, we will deploy the backend we just created to the Cloud so our backend is public and not bound to `localhost`. To do this, right click the project and click publish.

![](../media/publish-right-click.png)

Choose a name, resource group and service plan for your application and then publish your application.

> [You can follow the steps in this article to better understand all the things involved in creating a new cloud resource.](https://docs.microsoft.com/en-us/azure/app-service-web/web-sites-dotnet-get-started#configure-azure-resources-for-a-new-web-app)

> Note that if you chose `application-name` as the name of your application, you will be able to access it at `application-name.azurewebsites.net`.

- In the Create App Service dialog, click Add an account, and then sign in to Azure with the ID and password of the account that you use to manage your Azure subscription.

![](https://docs.microsoft.com/en-us/azure/app-service-web/media/web-sites-dotnet-get-started/configuresitesettings.png)

- Enter a Web App Name that is unique in the azurewebsites.net domain. For example, you can name it MyExample with numbers to the right to make it unique, such as MyExample810. If a default web name is created for you, it will be unique and you can use that.

- If someone else has already used the name that you enter, you see a red exclamation mark to the right instead of a green check mark, and you have to enter a different name.

- Click the New button next to the Resource Group box, and then enter "MyExample" or another name if you prefer.

![](https://docs.microsoft.com/en-us/azure/app-service-web/media/web-sites-dotnet-get-started/rgcreate.png)

> A resource group is a collection of Azure resources such as web apps, databases, and VMs. For a tutorial, it's generally best to create a new resource group because that makes it easy to delete in one step any Azure resources that you create for the tutorial. For more information, [see Azure Resource Manager overview](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview).

- Click the New button next to the App Service Plan drop-down.

![](https://docs.microsoft.com/en-us/azure/app-service-web/media/web-sites-dotnet-get-started/createasplan.png)

- The Configure App Service Plan dialog appears.

![](https://docs.microsoft.com/en-us/azure/app-service-web/media/web-sites-dotnet-get-started/configasp.png)

- In the Configure App Service Plan dialog, enter "MyExamplePlan" or another name if you prefer.
- In the Location drop-down list, choose the location that is closest to you.

- In the Size drop-down, click Free.

- In the Configure App Service Plan dialog, click OK.
- In the Create App Service dialog box, click Create.

At this point you can test the application in the same way with the browser and with PostMan, just by changing the URL from `localhost` to `application-name.azurewebsites.net`

In order to test the mobile application, we need to make a change in the code: in `AngularJsTodoApp/www/scripts/services`, open the `azureStorage.js` file and locate:

```
	//var AZURE_API_ADDRESS = 'http://youraddress.azurewebsites.net';
	var AZURE_API_ADDRESS = 'http://localhost:11591';
```

Comment the line with `localhost`,  uncomment and add your own application url that you just created, save and run the project again.

> If you want to test a public and functional backend, you can use this URL - `http://aspnet-todo-api.azurewebsites.net/`

The application should run in the same way, just that now it makes requests to a public endpoint and not to `localhost`.

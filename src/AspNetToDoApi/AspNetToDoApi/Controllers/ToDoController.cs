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
        

    }
}

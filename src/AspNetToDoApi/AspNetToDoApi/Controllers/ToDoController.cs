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

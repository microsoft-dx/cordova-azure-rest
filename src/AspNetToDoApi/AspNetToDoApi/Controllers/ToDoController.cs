using AspNetToDoApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace AspNetToDoApi.Controllers
{
    public class ToDoController : ApiController
    {
        private static ToDoRepository _toDoRepository = new ToDoRepository();
        
         [HttpGet]
         public List<ToDoItem> GetToDoItems()
        {
            return _toDoRepository.GetToDoItems();
        }

        [HttpGet]
        public ToDoItem GetToDoItemById(int id)
        {
            return _toDoRepository.GetById(id);
        }

        [HttpPost]
        public void CreateToDoItem(ToDoItem toDo)
        {
            _toDoRepository.CreateToDo(toDo);
        }

        [HttpPost]
        public void UpdateToDoItem(ToDoItem toDo)
        {
            _toDoRepository.Update(toDo);
        }

        [HttpDelete]
        public void DeleteToDoItem(int id)
        {
            _toDoRepository.Delete(id);
        }
    }
}

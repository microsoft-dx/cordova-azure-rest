using AspNetToDoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetToDoApi
{
    public class ToDoRepository
    {
        private List<ToDoItem> _toDoList { get; set; }

        public ToDoRepository()
        {
            _toDoList = new List<ToDoItem>()
            {
                new ToDoItem(1, "Feed the dog", "Remember to feed the dog", false),
                new ToDoItem(2, "Watch Star Wars", "Remember to watch the new Star Wars movie", true)
            };
        }

        public List<ToDoItem> GetToDoItems()
        {
            return _toDoList;
        }

        public void CreateToDo(ToDoItem toDo)
        {
            _toDoList.Add(toDo);
        }

        public void Delete(int id)
        {
            var toDo = _toDoList.FirstOrDefault(t => t.Id == id);

            if (toDo != null)
                _toDoList.Remove(toDo);
        }

        public void Update(ToDoItem toDo)
        {
            var toDoToUpdate = _toDoList.FirstOrDefault(t => t.Id == toDo.Id);

            if (toDoToUpdate != null)
                toDoToUpdate.UpdateToDo(toDo);
        }

        public ToDoItem GetById(int id)
        {
            return _toDoList.FirstOrDefault(t => t.Id == id);
        }
    }
}

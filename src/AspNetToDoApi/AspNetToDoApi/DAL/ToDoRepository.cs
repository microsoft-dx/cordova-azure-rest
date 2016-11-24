using AspNetToDoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetToDoApi.DAL
{
    public class ToDoRepository
    {
        private List<ToDoItem> _toDoList { get; set; }

        public ToDoRepository()
        {
            _toDoList = new List<ToDoItem>()
            {
                new ToDoItem("Get groceries", "43.465187,-80.522372", false),
                new ToDoItem("Walk the dog", "43.465187,-80.522372", false),
                new ToDoItem("Take the car to the shop", "43.465187,-80.522372", false)
            };
        }

        public List<ToDoItem> GetToDoItems()
        {
            return _toDoList;
        }

        public void CreateToDo(ToDoItem item)
        {
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();
            _toDoList.Add(item);
        }

        public void Delete(Guid id)
        {
            var toDo = _toDoList.FirstOrDefault(t => t.Id == id);

            if (toDo != null)
                _toDoList.Remove(toDo);
        }

        public void Update(ToDoItem item)
        {
            var toDoToUpdate = _toDoList.FirstOrDefault(t => t.Id == item.Id);

            if (toDoToUpdate != null)
                toDoToUpdate.UpdateToDo(item);
        }

        public ToDoItem GetById(Guid id)
        {
            return _toDoList.FirstOrDefault(t => t.Id == id);
        }
    }
}

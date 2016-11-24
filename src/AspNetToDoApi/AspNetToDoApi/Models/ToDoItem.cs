using Newtonsoft.Json;
using System;

namespace AspNetToDoApi.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Address { get; set; }

        public bool Done { get; set; }

        public ToDoItem()
        {
        }

        public ToDoItem(string name, string address, bool done)
        {
            Id = Guid.NewGuid();
            Text = name;
            Address = address;
            Done = done;
        }

        public void UpdateToDo(ToDoItem item)
        {
            Id = item.Id;
            Text = item.Text;
            Address = item.Address;
            Done = item.Done;
        }
    }
}

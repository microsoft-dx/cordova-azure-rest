using Newtonsoft.Json;
using System;

namespace AspNetToDoApi.Models
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("done")]
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

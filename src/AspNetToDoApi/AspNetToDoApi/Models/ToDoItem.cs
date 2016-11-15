namespace AspNetToDoApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

        public ToDoItem()
        {
        }

        public ToDoItem(int id, string name, string notes, bool done)
        {
            Id = id;
            Name = name;
            Notes = notes;
            Done = done;
        }

        public void UpdateToDo(ToDoItem toDo)
        {
            Id = toDo.Id;
            Name = toDo.Name;
            Notes = toDo.Notes;
            Done = toDo.Done;
        }
    }
}

namespace Core.Entity
{
    public class Column
    {
        public Guid Id { get; set; }    
        public required string Name { get; set; }
        public ToDoList? ToDoList { get; set; }


    }
}

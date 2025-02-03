namespace Core.Entity
{
    public class Column
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public List<ToDoList>? Tasks { get; set; }


    }
}

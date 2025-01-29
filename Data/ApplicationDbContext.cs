using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {


        }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Column> Columns { get; set; }
    }
}

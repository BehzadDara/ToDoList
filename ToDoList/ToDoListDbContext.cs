using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList;

public class ToDoListDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoItem>().HasKey(x => x.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.ToDoListDB");
        //optionsBuilder.UseInMemoryDatabase("ToDoListInMemoryDatabase");
    }
}
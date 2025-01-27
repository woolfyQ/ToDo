using Core.Entity;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Service
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ToDoService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ToDoList> Create(ToDoList toDoList)
        {
            var newtoDoList = new ToDoList()
            {
                Id = Guid.NewGuid(),
                Name = toDoList.Name,
                Description = toDoList.Description,
            };

            await _applicationDbContext.ToDoLists.AddAsync(newtoDoList);

            await _applicationDbContext.SaveChangesAsync();

            return newtoDoList;
        }

        public async Task<ToDoList> GetById(Guid id)
        {
            var findList = _applicationDbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            return findList;

        }

        public async Task<ToDoList> Update(ToDoList toDoList)
        {
            var existingToDoList = await GetById(toDoList.Id);

            if (existingToDoList == null)
            {
                throw new Exception("Task not found");
            }

            existingToDoList.Name = toDoList.Name;

            existingToDoList.Description = toDoList.Description;

            await _applicationDbContext.SaveChangesAsync();

            return existingToDoList;


        }

        public async Task<ToDoList>Delete(ToDoList toDoList)
        {
            var existingToDoList = await GetById(toDoList.Id);

            if (existingToDoList == null)
            {
                throw new Exception("Task not found");
            }
            _applicationDbContext.Remove(existingToDoList);

            await _applicationDbContext.SaveChangesAsync();

            return existingToDoList;
        }
        public async Task<IEnumerable<ToDoList>>GetAll(ToDoList toDoList)
        {
            return await _applicationDbContext.ToDoLists.ToListAsync();
        }

       


    }
}

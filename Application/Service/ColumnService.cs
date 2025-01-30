using Core.Entity;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ColumnService
    {
        private readonly ApplicationDbContext _context;

        public ColumnService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Column> Create(Column column)
        {
            column = new Column
            {
                Id = Guid.NewGuid(),
                Name = column.Name,
                Order = column.Order,
                Tasks = column.Tasks,
            };
            _context.Add(column);
            await _context.SaveChangesAsync();
            return column;
        }

        public async Task<Column> GetById(Guid id)
        {
            var columns = _context.Columns.FirstOrDefault(x => x.Id == id);
            return columns;

        }
     
        public async Task<IEnumerable<Column>> GetAll()
        {
            return await _context.Columns.ToListAsync();
        }


        public async Task<Column> Update(Column column)
        {
            column = await GetById(column.Id);
            if (column == null)
            {
                throw new Exception("Column not found");
            }

            column.Id = column.Id;
            column.Name = column.Name;
            column.Tasks = column.Tasks;
            column.Order = column.Order;

            _context.Update(column);
            await _context.SaveChangesAsync();
            return column;
        }

        public async Task<Column> Delete(Guid Id)
        {
            var column = await GetById(Id);
            if (column == null)
            {
                throw new Exception("Column not found");
            }
            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();
            return column;

        }
    }
}
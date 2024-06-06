using ASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore
{
    public class CateRepository : IRepository<Category>
    {
        private NewDbContext context;
        public CateRepository(NewDbContext _context)
        {
            this.context = _context;
        }
        public async Task Add(Category entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

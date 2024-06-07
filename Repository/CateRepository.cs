using ASPNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
            Category entity = context.Categories.Find(id);
            if (entity != null) return true;
            return false;
        }

        public async Task<Category> FindById(int id)
        {
            Category entity = await context.Categories.FindAsync(id);
            return entity;
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task Remove(Category entity)
        {
            //Console.WriteLine($"category: {entity.CategoryName}");
            context.Categories.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(Category entity)
        {
            Category newdata = await context.Categories.FindAsync(entity.Id);
            newdata = entity;
            await context.SaveChangesAsync();
        }
    }
}

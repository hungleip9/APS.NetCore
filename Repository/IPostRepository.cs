using ASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore
{
    public interface IPostRepository
    {
        Task Add(Post post);
        bool Exist(int id);
        Task Update(Post post);
        void Remove(int id);
        Task<Post> FindById(int id);
        Task<List<Post>> GetAll();
    }
    public class PostReponsitory : IPostRepository
    {
        private NewDbContext context;
        public PostReponsitory (NewDbContext _context)
        {
            this.context = _context;
        }
        public async Task Add(Post post)
        {
            context.Add(post);
            await context.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            Post post = context.Posts.Find(id);
            if (post != null) return true;
            return false;
        }

        public async Task<Post> FindById(int id)
        {
            Post post = await context.Posts.FindAsync(id);
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await context.Posts.ToListAsync();
        }

        public async void Remove(int id)
        {
            Post post = await context.Posts.FindAsync(id);
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task Update(Post post)
        {
            Post postnew = await context.Posts.FindAsync(post.Id);
            postnew = post;
            await context.SaveChangesAsync();
        }
    }
}

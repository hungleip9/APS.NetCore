using ASPNetCore.Models;

namespace ASPNetCore
{
    public class UnitOfWork
    {
        private NewDbContext db;
        private CateRepository cate;
        private PostReponsitory post;
        public UnitOfWork(NewDbContext context)
        {
            this.db = context;
        }
        public CateRepository CateRepository
        {
            get
            {
                if (cate == null)
                {
                    this.cate = new CateRepository(db);
                }
                return this.cate;
            }
        }
        public PostReponsitory PostReponsitory
        {
            get
            {
                if (post == null)
                {
                    this.post = new PostReponsitory(db);
                }
                return this.post;
            }
        }
        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }
    }
}

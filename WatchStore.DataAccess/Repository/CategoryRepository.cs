using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Data;
using WatchStore.DataAccess.Repository.IRepository;
using WatchStore.Models.Models;

namespace WatchStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}

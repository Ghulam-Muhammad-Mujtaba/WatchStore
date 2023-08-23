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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.ModelNo = product.ModelNo;
                objFromDb.Price = product.Price;
                objFromDb.DiscountedPrice = product.DiscountedPrice;
                objFromDb.Warrenty = product.Warrenty;
                objFromDb.Description = product.Description;
                objFromDb.ImageUrl = product.ImageUrl;
                objFromDb.BrandId = product.BrandId;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.DialId = product.DialId;
                objFromDb.BandId = product.BandId;
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}

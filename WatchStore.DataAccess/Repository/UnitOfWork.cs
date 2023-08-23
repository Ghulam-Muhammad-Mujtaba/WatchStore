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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Brand = new BrandRepository(_db);
            Category = new CategoryRepository(_db);
            Dial = new DialRepository(_db);
            Band = new BandRepository(_db);
            Product= new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderDetail= new OrderDetailRepository(_db);
            OrderHeader= new OrderHeaderRepository(_db);
        }

        public IBrandRepository Brand { get; private set; }
        public ICategoryRepository Category { get;private set; }
        public IDialRepository Dial { get; private set; }
        public IBandRepository Band { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
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
    public class BandRepository : Repository<Band>, IBandRepository
    {
        private readonly ApplicationDbContext _db;
        public BandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Band band)
        {
            _db.Bands.Update(band);
        }
    }
}
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
    public class DialRepository : Repository<Dial>, IDialRepository
    {
        private readonly ApplicationDbContext _db;
        public DialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Dial dial)
        {
            _db.Dials.Update(dial);
        }
    }
}

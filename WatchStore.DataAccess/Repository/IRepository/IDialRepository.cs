using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Models.Models;

namespace WatchStore.DataAccess.Repository.IRepository
{
    public interface IDialRepository : IRepository<Dial>
    {
        void Update(Dial dial);
    }
}

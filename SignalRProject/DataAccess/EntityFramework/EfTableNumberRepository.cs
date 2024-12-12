using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfTableNumberRepository : GenericRepository<TableNumber>, ITableNumberDal
    {
        public EfTableNumberRepository(SignalRContext context) : base(context)
        {

        }

        public int ActiveTableNumber()
        {
            using var context = new SignalRContext();   
            return context.TableNumbers.Where(x=>x.Status==true).Count();
        }

        public void ChangeStatusToFalse(int id)
        {
            var context = new SignalRContext();
            var deger = context.TableNumbers.Find(id);
            deger.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var deger = context.TableNumbers.Find(id);
            deger.Status = true;
            context.SaveChanges();
        }
    }
}

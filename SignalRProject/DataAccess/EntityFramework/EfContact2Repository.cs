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
	public class EfContact2Repository : GenericRepository<Contact2>, IContact2Dal
	{
		public EfContact2Repository(SignalRContext context) : base(context)
		{
		}

        public void ChangeStatusToFalse(int id)
        {
            var context = new SignalRContext();
            var deger = context.Contact2s.Find(id);
            deger.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var deger = context.Contact2s.Find(id);
            deger.Status = true;
            context.SaveChanges();
        }

        public List<Contact2> GetActiveContact2()
        {
            var context = new SignalRContext();
            return context.Contact2s.Where(x => x.Status == true).ToList();
        }
    }
}

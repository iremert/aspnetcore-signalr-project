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
	public class EfContactRepository : GenericRepository<Contact>, IContactDal
	{
		public EfContactRepository(SignalRContext context) : base(context)
		{
		}

        public void ChangeStatusToFalse(int id)
        {
            var context = new SignalRContext();
            var deger = context.Contacts.Find(id);
            deger.Status2 = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var deger = context.Contacts.Find(id);
            deger.Status2 = true;
            context.SaveChanges();
        }

        public Contact GetActiveContact()
        {
            var context = new SignalRContext();
            return context.Contacts.Where(x => x.Status == true).Take(1).SingleOrDefault();
        }
    }
}

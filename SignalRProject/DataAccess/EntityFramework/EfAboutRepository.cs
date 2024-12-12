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
	public class EfAboutRepository:GenericRepository<About>,IAboutDal
	{
        public EfAboutRepository(SignalRContext context):base(context)
        {
           
        }

        public void ChangeStatusToFalse(int id)
        {
           var context=new SignalRContext();
            var deger = context.Abouts.Find(id);
            deger.Status = false;
            context.SaveChanges();  
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var deger = context.Abouts.Find(id);
            deger.Status = true;
            context.SaveChanges();
        }

        public List<About> GetActiveAbout()
        {
            var context = new SignalRContext();
            return context.Abouts.Where(x=>x.Status==true).ToList();
        }
    }
}

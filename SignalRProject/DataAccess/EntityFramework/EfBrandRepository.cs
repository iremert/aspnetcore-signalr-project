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
	public class EfBrandRepository : GenericRepository<Brand>, IBrandDal
	{
        
		public EfBrandRepository(SignalRContext context) : base(context)
		{
        }

        public int ActiveBrandCount()
        {
            using var context = new SignalRContext(); 
            return context.Brands.Where(x=>x.Status==true).Count();
        }

        public int BrandCount()
        {
            using var context = new SignalRContext();
            return context.Brands.Count();
        }

        public void ChangeStatusToFalse(int id)
        {
            var context = new SignalRContext();
            var deger= context.Brands.Find(id);
            deger.Status =false;
            context.SaveChanges();

        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var deger = context.Brands.Find(id);
            deger.Status = true;
            context.SaveChanges();
        }

        public List<Brand> GetActiveBrand()
        {
            var context = new SignalRContext();
            return context.Brands.Where(x => x.Status == true).ToList();
        }

        public int PassiveBrandCount()
        {
            using var context = new SignalRContext();
            return context.Brands.Where(x => x.Status == false).Count();
        }
    }
}

using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.CarDto;

namespace DataAccess.EntityFramework
{
	public class EfCarRepository : GenericRepository<Car>, ICarDal
	{
		public EfCarRepository(SignalRContext context) : base(context)
		{
		}

        public int CarCount()
        {
            using var context = new SignalRContext();
            return context.Cars.Count();
        }

        public int CarCountByBrandNameHyundai()
        {
            using var context=new SignalRContext();
            return context.Cars.Where(x => x.BrandID == (context.Brands.Where(y => y.BrandName == "Hyundai").Select(z=>z.BrandId).FirstOrDefault())).Count();
        }

        public int CarCountByBrandNameRenault()
        {
            using var context = new SignalRContext();
            return context.Cars.Where(x => x.BrandID == (context.Brands.Where(y => y.BrandName == "Renault").Select(z => z.BrandId).FirstOrDefault())).Count();
        }

        public double CarPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Cars.Average(x => x.Price);
        }

        public double CarPriceAvgByHyundai()
        {
            using var context=new SignalRContext();
            return context.Cars.Where(x => x.BrandID == (context.Brands.Where(y => y.BrandName == "Hyundai").Select(z => z.BrandId).FirstOrDefault())).Average(w=>w.Price);
        }

        public void ChangeStatus2ToFalse(int id)
        {
            var context = new SignalRContext();
            var value = context.Cars.Find(id);
            value.Status2 = false;
            context.SaveChanges();
        }

        public void ChangeStatus2ToTrue(int id)
        {
            var context = new SignalRContext();
            var value = context.Cars.Find(id);
            value.Status2 = true;
            context.SaveChanges();
        }

        public void ChangeStatusToFalse(int id)
        {
            var context = new SignalRContext();
            var value=context.Cars.Find(id);
            value.Status = false;
            context.SaveChanges();
            
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new SignalRContext();
            var value = context.Cars.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public List<Car> GetActiveCar()
        {
            using (var context = new SignalRContext())
            {
                return context.Cars
                    .Where(x => x.Status == true).ToList();
                    
            }
        }

        public List<Car> GetActiveFeaturedCars()
        {
            var context = new SignalRContext();
            var values = context.Cars.Where(x => x.Status2 == true).Where(y => y.Status == true).ToList();
            return values;
        }

        public List<Car> GetListCarWithBrand()
		{
			var context = new SignalRContext();
			var values = context.Cars.Include(y => y.Brands).ToList();
			return values;
		}

        public List<Car> GetNewestCar()
        {
            var context = new SignalRContext();
            var values = context.Cars.Include(y => y.Brands).Where(x => x.Status == true).TakeLast(3).ToList();
            return values;
        }

        public string MaxCarPrice()
        {
            var context=new SignalRContext();
            var values = context.Cars.Include(z=>z.Brands).OrderByDescending(y => y.Price).Select(x=>x.Brands.BrandName).FirstOrDefault();
            return values;
        }

        public string MinCarPrice()
        {
            var context = new SignalRContext();
            var values = context.Cars.Include(z=>z.Brands).OrderByDescending(y => y.Price).Select(x => x.Brands.BrandName).LastOrDefault();
            return values;
        }


        





    }
}

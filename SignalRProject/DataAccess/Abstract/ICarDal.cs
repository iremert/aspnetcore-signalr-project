using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface ICarDal:IGenericDal<Car>
	{
		public List<Car> GetListCarWithBrand();
		public int CarCount();
		public int CarCountByBrandNameHyundai();
		public int CarCountByBrandNameRenault();
		public double CarPriceAvg();
		public double CarPriceAvgByHyundai();
		public string MaxCarPrice();
		public string MinCarPrice();

		public List<Car> GetActiveCar();
		public List<Car> GetActiveFeaturedCars();
		public List<Car> GetNewestCar();



        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
        public void ChangeStatus2ToTrue(int id);
        public void ChangeStatus2ToFalse(int id);
    }
}

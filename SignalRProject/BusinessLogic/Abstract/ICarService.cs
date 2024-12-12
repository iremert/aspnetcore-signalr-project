using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface ICarService:IGenericService<Car>
	{
		public List<Car> GetListCarWithBrand();
        public int TCarCount();
        public int TCarCountByBrandNameHyundai();
        public int TCarCountByBrandNameRenault();
        public double TCarPriceAvg();
        public double TCarPriceAvgByHyundai();
        public string TMaxCarPrice();
        public string TMinCarPrice();

        public List<Car> TGetActiveCar();
        public List<Car> TGetActiveFeaturedCars();
        public List<Car> TGetNewestCar();

        public void TChangeStatusToTrue(int id);
        public void TChangeStatusToFalse(int id);
        public void TChangeStatus2ToTrue(int id);
        public void TChangeStatus2ToFalse(int id);
    }
}

using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
	public class CarManager : ICarService
	{
		private readonly ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public List<Car> GetListCarWithBrand()
		{
			return _carDal.GetListCarWithBrand();
		}

        public int TCarCount()
        {
            return _carDal.CarCount();
        }

        public int TCarCountByBrandNameHyundai()
        {
            return _carDal.CarCountByBrandNameHyundai();
        }

        public int TCarCountByBrandNameRenault()
        {
            return _carDal.CarCountByBrandNameRenault();
        }

        public double TCarPriceAvg()
        {
            return _carDal.CarPriceAvg();
        }

        public double TCarPriceAvgByHyundai()
        {
            return _carDal.CarPriceAvgByHyundai();
        }

        public void TChangeStatus2ToFalse(int id)
        {
            _carDal.ChangeStatus2ToFalse(id);
        }

        public void TChangeStatus2ToTrue(int id)
        {
            _carDal.ChangeStatus2ToTrue(id);
        }

        public void TChangeStatusToFalse(int id)
        {
            _carDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _carDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Car t)
		{
			_carDal.Delete(t);
		}

        public List<Car> TGetActiveCar()
        {
            return _carDal.GetActiveCar();	
        }

        public List<Car> TGetActiveFeaturedCars()
        {
            return _carDal.GetActiveFeaturedCars();
        }

        public List<Car> TGetAll()
		{
			var liste=_carDal.GetAll();
			return liste;
		}

		public List<Car> TGetAllWithFilter(Expression<Func<Car, bool>> filter)
		{
			var liste=_carDal.GetAllWithFilter(filter);
			return liste;
		}

		public Car TGetById(int id)
		{
		     var deger=_carDal.GetById(id);	
			return deger;
		}

        public List<Car> TGetNewestCar()
        {
            return _carDal.GetNewestCar();
        }

        public void TInsert(Car t)
		{
			_carDal.Insert(t);

		}

        public string TMaxCarPrice()
        {
            return _carDal.MaxCarPrice();
        }

        public string TMinCarPrice()
        {
            return _carDal.MinCarPrice();
        }

        public void TUpdate(Car t)
		{
			_carDal.Update(t);
		}
	}
}

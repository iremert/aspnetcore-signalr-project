using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IBrandDal:IGenericDal<Brand>
	{
        public int BrandCount();
        public int ActiveBrandCount();
        public int PassiveBrandCount();
        public List<Brand> GetActiveBrand();


        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
    }
}

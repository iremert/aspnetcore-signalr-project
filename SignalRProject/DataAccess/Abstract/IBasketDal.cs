using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        public List<Basket> GetBasketWithCarWithTable(int id);
    }
}

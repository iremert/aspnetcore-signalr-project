using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITableNumberDal:IGenericDal<TableNumber>
    {
        public int ActiveTableNumber();


        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
    }
}

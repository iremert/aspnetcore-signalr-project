using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ITableNumberService:IGenericService<TableNumber>
    {
        public int TActiveTableNumber();

        public void TChangeStatusToTrue(int id);
        public void TChangeStatusToFalse(int id);
    }
}

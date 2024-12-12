using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IMoneyCaseService:IGenericService<MoneyCase>
    {
        public double TotalMoneyCaseAmount();
    }
}

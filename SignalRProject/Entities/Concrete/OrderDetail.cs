using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int CarId { get; set; }
        public Car Cars { get; set; }
        public int Count {  get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int OrderId {  get; set; }
        public Order Orders { get; set; }
    }
}

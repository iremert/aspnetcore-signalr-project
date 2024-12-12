using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Basket
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int TableNumberId {  get; set; }   
        public TableNumber TableNumber { get; set; }
    }
}

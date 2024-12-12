using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.BasketDto
{
    public class CreateBasketDto
    {
        public decimal Price { get; set; }
        public int Counte { get; set; }
        public decimal TotalPrice { get; set; }
        public int CarId { get; set; }
        public int TableNumberId { get; set; }
    }
}

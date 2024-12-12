using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableNumberId { get; set; }
        public TableNumber tableNumbers { get; set; }
        public string State { get; set; }

        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }
        public double TotalPrice {  get; set; } 
    }
}

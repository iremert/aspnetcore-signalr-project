using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TableNumber
    {
        public int TableNumberId { get; set; }
        public string Table { get; set; } 
        public bool Status { get; set; }    
        public ICollection<TableNumber> tableNumbers { get; set; }
    }
}

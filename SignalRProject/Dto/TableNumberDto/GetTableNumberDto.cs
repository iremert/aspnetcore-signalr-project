using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.TableNumberDto
{
    public class GetTableNumberDto
    {
        public int TableNumberId { get; set; }
        public string Table { get; set; }
        public bool Status { get; set; }
    }
}

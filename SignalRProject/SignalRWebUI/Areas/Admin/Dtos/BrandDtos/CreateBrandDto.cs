using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Areas.Admin.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
        public string Url { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

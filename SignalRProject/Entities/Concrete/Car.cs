using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Car
	{
        public int CarID { get; set; }
		public int BrandID { get; set; }
        public string Model { get; set; }
		public string ImageUrl { get; set; }
		public string ImageUrl2 { get; set; }
		public string ImageUrl3 { get; set; }
		public string ImageUrl4 { get; set; }
		public string Description { get; set; }
		public int ModelDate { get; set; }
		public double MileageStatus { get; set; } //km
        public string Gearbox { get; set; } //şanzıman:otomatik vs
        public string EnginType { get; set; } //benzinli vs
        public string MotorPower { get; set; }
        public string Color { get; set; }
        public string DamageStatus { get; set; }
        public string MaintenanceHistory { get; set; } //hasar durumu
        public string TireCondition { get; set; } //lastik durumu
        public string VehicleEquipment { get; set; }
        public string InVehicleStatus { get; set; } //araç içi durumu
        public string Documents { get; set; }
        public string Insurance { get; set; }
        public int Price { get; set; }
        public string Bargain { get; set; }
        public bool Status { get; set; } 
        public bool Status2 { get; set; } //featured
        public Brand Brands { get; set; }    
        public ICollection<Basket> Baskets { get; set; }
    }
}

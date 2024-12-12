using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.CarDto
{
	public class ResultCarDto
	{
		public int CarID { get; set; }
		public string ImageUrl { get; set; }
		public string ImageUrl2 { get; set; }
		public string ImageUrl3 { get; set; }
		public string ImageUrl4 { get; set; }
		public string Description { get; set; }
		
		public string BrandName { get; set; }

		public string Model { get; set; }
		public int ModelDate { get; set; }
		public double MileageStatus { get; set; }
		public string Gearbox { get; set; }
		public string EnginType { get; set; }
		public string MotorPower { get; set; }
		public string Color { get; set; }
		public string DamageStatus { get; set; }
		public string MaintenanceHistory { get; set; }
		public string TireCondition { get; set; }
		public string VehicleEquipment { get; set; }
		public string InVehicleStatus { get; set; }
		public string Documents { get; set; }
		public string Insurance { get; set; }
		public int Price { get; set; }
		public string Bargain { get; set; }
		public bool Status { get; set; }
		public bool Status2 { get; set; } //featured
	}
}

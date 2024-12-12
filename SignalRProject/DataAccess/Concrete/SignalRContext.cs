using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SignalRContext:IdentityDbContext<AppUser,AppRole,int>
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=IREMERTURK\\SQLEXPRESS02;DataBase=OtoPiyasa;integrated security=true;TrustServerCertificate=true");
		}

		public DbSet<About> Abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Contact2> Contact2s { get; set; }
		public DbSet<Service> Services { get; set; }	
		public DbSet<Order> Orders { get; set; }	
		public DbSet<OrderDetail> OrderDetails { get; set; }	
		public DbSet<MoneyCase> MoneyCases { get; set; }	
		public DbSet<TableNumber> TableNumbers { get; set; }	
		public DbSet<Basket> Baskets { get; set; }	
		public DbSet<Notification> Notifications { get; set; }	
	}
}

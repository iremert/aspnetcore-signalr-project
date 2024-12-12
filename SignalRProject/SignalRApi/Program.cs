using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SignalRApi.Hubs;
using System.Text.Json.Serialization;
using Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().
        AllowAnyMethod().
        SetIsOriginAllowed((host) => true) //gelen herhangi kaynaða izin
        .AllowCredentials();//herhangi kimlik izin ver
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<SignalRContext>(); //hangisi olduðu belirtilmeli.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutRepository>();

builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBrandDal, EfBrandRepository>();

builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<ICarDal, EfCarRepository>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactRepository>();

builder.Services.AddScoped<IContact2Service, Contact2Manager>();
builder.Services.AddScoped<IContact2Dal, EfContact2Repository>();

builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceRepository>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderRepository>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailRepository>();

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseRepository>();

builder.Services.AddScoped<ITableNumberService, TableNumberManager>();
builder.Services.AddScoped<ITableNumberDal, EfTableNumberRepository>();

builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDal, EfBasketRepository>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationRepository>();

builder.Services.AddControllersWithViews().AddJsonOptions(options=>options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles); //json un iþlenmesini kontrol edermiþ







// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub"); //localhost://1234/signalrhub yerine gitmesi için endpoint atadýk yani

app.Run();

using BusinessLogic.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs //DENEME
{
    public class SignalRHub : Hub //burası uygulamanın server kısmı
    {
        private readonly IBrandService _brandService;
        private readonly ICarService _carService;
        private readonly IOrderService _orderService;
        private readonly ITableNumberService _tableNumberService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly INotificationService _notificationService;

        public SignalRHub(IBrandService brandService, ICarService carService, IOrderService orderService, ITableNumberService tableNumberService, IMoneyCaseService moneyCaseService, INotificationService notificationService)
        {
            _brandService = brandService;
            _carService = carService;
            _orderService = orderService;
            _tableNumberService = tableNumberService;
            _moneyCaseService = moneyCaseService;
            _notificationService = notificationService;
        }

        public async Task SendBrandCount() //bu metota abone olcam içindeki yapıyı kullancam gibi
        {
            var values = _brandService.TBrandCount();
            await Clients.All.SendAsync("ReceiveBrandCount", values); //clienta gönderiyoruz
        }
        public async Task SendCarCount()
        {
            var value=_carService.TCarCount();
            await Clients.All.SendAsync("ReceiveCarCount",value);
        }
        public async Task ActivePassiveBrandCount()
        {
            var values=_brandService.TActiveBrandCount();
            await Clients.All.SendAsync("ReceiveActiveBrandCount",values);
            var values2= _brandService.TPassiveBrandCount();
            await Clients.All.SendAsync("ReceivePassiveBrandCount", values2);



        }
        public async Task GetStatistic()
        {
            var values=_carService.TCarCountByBrandNameHyundai();
            var values2=_carService.TCarCountByBrandNameRenault();
            var values4 = _carService.TCarPriceAvg();
            var values5 = _carService.TCarPriceAvgByHyundai();
            await Clients.All.SendAsync("ReceiveHyundaiCount",values);
            await Clients.All.SendAsync("ReceiveRenaultCount",values2);
            await Clients.All.SendAsync("ReceiveCarPriceAvg",values4.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveHyundaiPriceAvg",values5.ToString("0.00") + "₺");


            var value6=_carService.TMaxCarPrice();
            var value7=_carService.TMinCarPrice();
            await Clients.All.SendAsync("ReceiveMaxCarPrice", value6);
            await Clients.All.SendAsync("ReceiveMinCarPrice", value7);



            var value8 = _orderService.TTotalOrderCount();
            var value9 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("TotalOrderCount", value8);
            await Clients.All.SendAsync("LastOrderPrice", value9.ToString("0.00") + "₺");

            var value13 = _moneyCaseService.TotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount", value13.ToString("0.00") + "₺");
        }
        public async Task GetStatistic2()
        {

            var value10 = _tableNumberService.TActiveTableNumber();
            var value11 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveTableNumber", value10);
            await Clients.All.SendAsync("ActiveOrderCount", value11);


            var value12 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("TodayTotalPrice", value12.ToString("0.00") + "₺");

        }
        public async Task SendProgress()
        {
            var value1=_moneyCaseService.TotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount2", value1.ToString("0.00") + "₺");

            var value2 = _tableNumberService.TActiveTableNumber();
            var value3 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveTableNumber2", value2);
            await Clients.All.SendAsync("ActiveOrderCount2", value3);
        }
        public async Task ListWithSignalR()
        {
            var deger = _brandService.TGetAll();
            await Clients.All.SendAsync("BrandCount", deger);
        }
        public async Task NotificationIssues()
        {
            var deger=_notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("NotificationCountByStatusFalse", deger);


            var deger2 = _notificationService.GetAllNotificationsByFalse();
            await Clients.All.SendAsync("GetAllNotificationsByFalse", deger2);
        }
        public async Task TableListWithSignalR()
        {
            var deger2=_tableNumberService.TGetAll();
            await Clients.All.SendAsync("GetAllTableNumber",deger2);

           
        }

        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }


        public async Task ProgressBar()
        {
            var deger2 = _tableNumberService.TGetAll().ToList().Count();
            await Clients.All.SendAsync("GetAllTableNumberCount", deger2);
        }

    }
}

using BusinessLogic.Abstract;
using Dto.NotificationDto;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("NotificationStatusChangeToFalse/{id:int}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.NotificationStatusChangeToFalse(id);           
            return Ok("Güncelleme Yapıldı.");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id:int}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.NotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı.");    
        }



        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var value=_notificationService.NotificationCountByStatusFalse();
            return Ok(value);
        }


        [HttpGet("GetAllNotificationByStatusFalse")]
        public IActionResult GetAllNotificationByStatusFalse()
        {
            var values=_notificationService.GetAllNotificationsByFalse();
            return Ok(values);
        }


        [HttpGet]
        public IActionResult NotificationList()
        {
            var liste = _notificationService.TGetAll();
            return Ok(liste);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = new Notification()
            {
                Date=Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description=createNotificationDto.Description,
                Icon=createNotificationDto.Icon,
                Type = createNotificationDto.Type,
            };
            notification.Status = false;
            _notificationService.TInsert(notification);
            return Ok("Bildirim başarıyla eklendi.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silme işlemi gerçekleşti.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = new Notification()
            {
                Description =updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Type = updateNotificationDto.Type,
                NotificationId= updateNotificationDto.NotificationId
            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim güncelleme işlemi tamamlandı.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetNotification(int id)
        {
            var deger = _notificationService.TGetById(id);
            return Ok(deger);
        }
    }
}

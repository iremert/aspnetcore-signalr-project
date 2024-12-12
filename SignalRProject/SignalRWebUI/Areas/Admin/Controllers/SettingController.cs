using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using SignalRWebUI.Areas.Admin.Dtos.LoginDtos;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto=new UserEditDto();
            userEditDto.Surname = values.Surname;
            userEditDto.Name = values.Name;
            userEditDto.Username = values.UserName;
            userEditDto.Mail = values.Email;
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if(userEditDto.Password==userEditDto.ConfirmPassword)
            {
                var values = await userManager.FindByNameAsync(User.Identity.Name);
                values.Surname = userEditDto.Surname;
                values.Name = userEditDto.Name;
                values.UserName = userEditDto.Username;
                values.Email = userEditDto.Mail;
                values.PasswordHash = userManager.PasswordHasher.HashPassword(values, userEditDto.Password);
                await userManager.UpdateAsync(values);
                return RedirectToAction("Index","Statistic",new  {area="Admin" });
            }
            return View();
           
        }
    }
}

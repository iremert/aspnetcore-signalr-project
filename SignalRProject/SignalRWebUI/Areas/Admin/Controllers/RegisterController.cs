using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Areas.Admin.Dtos.LoginDtos;
using SignalRWebUI.Areas.Admin.Dtos.RegisterDtos;

namespace SignalRWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager; //burada refernce aldık entityi
        private readonly SignInManager<AppUser> signInManager;

        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto registerDto)
        {
            var appuser = new AppUser()
            {
                Name= registerDto.Name,
                Surname= registerDto.Surname,
                Email=registerDto.Mail,
                UserName=registerDto.Username,
            };

            var result=await userManager.CreateAsync(appuser,registerDto.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("SignIn");
            }
            return View();
        }







        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("CarList","Car", new { area = "Admin" });
            }
            return View();
        }





        public  async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}

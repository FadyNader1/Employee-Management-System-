using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Entities.identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System_Management.Models;

namespace System_Management.Controllers
{
    public class Accountcontroller : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailServic emailServic;

        public Accountcontroller(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager  ,IEmailServic emailServic)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailServic = emailServic;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkuser = await userManager.FindByEmailAsync(model.Email);
                if (checkuser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email already found ");
                    return View(model);
                }

                var user = new AppUser()
                {
                    FName = model.FName,
                    LName=model.LNmae,
                    UserName=$"{model.FName}_{model.LNmae}",
                    PhoneNumber=model.PhoneNumber,
                    Email=model.Email,
                    
                };


                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Admin:fady3082003@gmail.com
                    //password:fady102030
                    //HR:fady.nader.developer@gmail.com
                    //password:fady102030

                    //var check = await roleManager.RoleExistsAsync("Admin");
                    //if (!check)
                    //    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    //await userManager.AddToRoleAsync(user, "Admin");

                    //var check = await roleManager.RoleExistsAsync("HR");
                    //if (!check)
                    //    await roleManager.CreateAsync(new IdentityRole("HR"));
                    //await userManager.AddToRoleAsync(user, "HR");
                    var check = await roleManager.RoleExistsAsync("User");
                    if (!check)
                        await roleManager.CreateAsync(new IdentityRole("User"));
                    await userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction(nameof(Login));

                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        /// Register HR
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult RegisterHR()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterHR(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkuser = await userManager.FindByEmailAsync(model.Email);
                if (checkuser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email already found ");
                    return View(model);
                }

                var user = new AppUser()
                {
                    FName = model.FName,
                    LName = model.LNmae,
                    UserName = $"{model.FName}_{model.LNmae}_HR",
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,

                };


                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Admin:fady3082003@gmail.com
                    //password:fady102030
                    //HR:fady.nader.developer@gmail.com
                    //password:fady102030

                    var check = await roleManager.RoleExistsAsync("HR");
                    if (!check)
                        await roleManager.CreateAsync(new IdentityRole("HR"));
                    await userManager.AddToRoleAsync(user, "HR");
                   

                    return RedirectToAction(nameof(Login));

                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        /// 
        ///Register Admin
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkuser = await userManager.FindByEmailAsync(model.Email);
                if (checkuser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email already found ");
                    return View(model);
                }

                var user = new AppUser()
                {
                    FName = model.FName,
                    LName = model.LNmae,
                    UserName = $"{model.FName}_{model.LNmae}_Admin",
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,

                };


                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Admin:fady3082003@gmail.com
                    //password:fady102030
                    //HR:fady.nader.developer@gmail.com
                    //password:fady102030

                    var check = await roleManager.RoleExistsAsync("Admin");
                    if (!check)
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await userManager.AddToRoleAsync(user, "Admin");

                   

                    return RedirectToAction(nameof(Login));

                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        ///
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
               
                if(user != null)
                {
                    var checkpassword = await userManager.CheckPasswordAsync(user,model.Password);
                    if (checkpassword)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, true, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid password");
                }
                ModelState.AddModelError(string.Empty, "Email not found pleace go to register");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public  IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var urlresetpassword = Url.Action("ResetPassword", "Account", new { Email = user.Email, Token = token }, Request.Scheme);
                    try
                    {
                        await emailServic.SendEmailAsync(model.Email, "Reset Password", urlresetpassword);
                        return RedirectToAction(nameof(CheckInbox));
                    }catch(Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, " Failure sending mail.");
                    }
                    
                }
                ModelState.AddModelError(string.Empty, "Email not fount pleace go to register");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CheckInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email,string token)
        {
            var model = new ResetPasswordViewModel()
            {
                Email = email,
                Token = token
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "email not found");
                    return View(model);
                }

                var result = await userManager.ResetPasswordAsync(user, model.Token, model.New_Password);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var x in result.Errors)
                    ModelState.AddModelError(string.Empty, x.Description);
            }
            return View(model);
        }
    }
}

using Company.DAL.Entities.identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System_Management.Models;

namespace System_Management.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Usercontroller : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public Usercontroller(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string value)
        {

            if (string.IsNullOrEmpty(value))
            {
                var user = userManager.Users.Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FName,
                    LastName = x.LName,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Roles = userManager.GetRolesAsync(x).Result
                }).ToList();
                return View(user);
            }
            else
            {
                var user = await userManager.FindByEmailAsync(value);
                if (user == null)
                    return View(new List<UserViewModel>() {  });
           
                var usermapp = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FName,
                    LastName = user.LName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = userManager.GetRolesAsync(user).Result,
                };
                return View(new List<UserViewModel>() { usermapp });
            }

        }
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            var usermapp = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FName,
                LastName = user.LName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = userManager.GetRolesAsync(user).Result
            };
            return View(usermapp);

        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] string id)
        {
            return await Details(id);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                    return NotFound();
                
                user.FName = model.FirstName;
                user.LName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                
             var result=   await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await Details(id);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id,UserViewModel model)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
               var result= await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);

        }

    }
}

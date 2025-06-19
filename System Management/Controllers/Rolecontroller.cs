using AutoMapper;
using Company.BLL.Repositories;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System_Management.Models;

namespace System_Management.Controllers
{
    [Authorize(Roles ="Admin")]

    public class Rolecontroller : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public Rolecontroller(RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                var rolename = await roleManager.FindByNameAsync(model.Name);
                var check = await roleManager.RoleExistsAsync(model.Name);
                if (check)
                {
                    ModelState.AddModelError(string.Empty, "Role already exist");
                    return View(model);
                }
                var mapp = mapper.Map<RoleVM, IdentityRole>(model);
                var result = await roleManager.CreateAsync(mapp);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "faild in created");
                return View(model);


            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                var roles =await roleManager.Roles.Select(x => new RoleVM()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                return View(roles);
            }
            else
            {

                var role = await roleManager.FindByNameAsync(value);
                if (role is not null)
                {
                    var rolemapp = new RoleVM()
                    {
                        Id = role.Id,
                        Name = role.Name
                    };
                    return View(new List<RoleVM>() { rolemapp });
                }
                return View(new List<RoleVM>() { });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            if (id == null)
                return BadRequest();

            var dept = await roleManager.FindByIdAsync(id);
            if (dept is null)
                return NotFound();
            var deptmapp = mapper.Map<IdentityRole, RoleVM>(dept);
            return View(deptmapp);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] string id)
        {

            return await Details(id);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleVM model,string id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(id);
                    role.Name = model.Name;
                    await roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoleVM model, [FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(id);
                    await roleManager.DeleteAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(model);
                }

            }
            return View(model);
        }

    }
}

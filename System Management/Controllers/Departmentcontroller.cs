using AutoMapper;
using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System_Management.Models;

namespace System_Management.Controllers
{
    public class Departmentcontroller : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public Departmentcontroller(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [Authorize(Roles = "HR,Admin,User")]

        [HttpGet]
        public async Task<IActionResult> Index(string value)
        {
            var spec = new DepartmentSpecification(value);
            var department = await unitOfWork.Repository<Department>().GetAllSpecAsync(spec);
            if (department is null)
                return NotFound();
            var deptmap = mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentViewModel>>(department);
            return View(deptmap);
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var deptmapp = mapper.Map<DepartmentViewModel, Department>(model);
                var dept =  unitOfWork.Repository<Department>().AddAsync(deptmapp);
                await unitOfWork.Complete();
                TempData["res"] = "An department has been added successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            if (id == null)
                return BadRequest();

            var dept = await unitOfWork.Repository<Department>().GetByIdAsync(id);
            if (dept is null)
                return NotFound();
            var deptmapp = mapper.Map<Department, DepartmentViewModel>(dept);
            return View(deptmapp);
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {

            return await Details(id);

        }
        [Authorize(Roles = "HR,Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit( DepartmentViewModel model)
        {

            if (ModelState.IsValid)
            {
                var deptmapp = mapper.Map<DepartmentViewModel, Department>(model);
                unitOfWork.Repository<Department>().Update(deptmapp);
                await unitOfWork.Complete();
                TempData["res"] = "An department has been edited successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await Details(id);
        }
        [Authorize(Roles = "HR,Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var deptmapp = mapper.Map<DepartmentViewModel, Department>(model);
                    unitOfWork.Repository<Department>().Delete(deptmapp);
                    await unitOfWork.Complete();
                    TempData["res"] = "An department has been deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
               
            }
            return View(model);
        }


    }
}

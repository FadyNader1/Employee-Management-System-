using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System_Management.Models;

namespace System_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapp;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork,IMapper mapp)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapp = mapp;
        }

        public async Task<IActionResult> Index()
        {
            var spec = new EmployeeSpecification();
            var employees =await unitOfWork.Repository<Employee>().GetAllSpecAsync(spec);
            if (employees == null)
                return View();
            else
                return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

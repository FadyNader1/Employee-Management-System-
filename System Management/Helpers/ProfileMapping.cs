using AutoMapper;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System_Management.Models;

namespace System_Management.Helpers
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleVM>().ReverseMap();

        }
    }
}

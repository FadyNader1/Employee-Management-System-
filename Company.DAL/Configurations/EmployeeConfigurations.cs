using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);;
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Salary).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.HireDate).IsRequired();

            builder.HasOne(x => x.department).WithMany(x=>x.employees).OnDelete(DeleteBehavior.SetNull);


        }
    }
}

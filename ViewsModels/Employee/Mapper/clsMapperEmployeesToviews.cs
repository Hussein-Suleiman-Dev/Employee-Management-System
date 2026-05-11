
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Employee_Business_Layer;
namespace Presentation.ViewModels
{
    public class clsMapperEmployeesToviews
    {
        public enum enGender {Male=1,Female=2 }


        //public static EmployeeViewModel ToView(clsEmployee emp)
        //{
        //    if (emp == null)
        //        return null;

        //    return new EmployeeViewModel
        //    {
        //        ID = emp.ID,
        //        FullName = $"{emp.FirstName} {emp.LastName}",

        //        Gender = Enum.IsDefined(typeof(enGender), emp.Gender)
        //            ? ((enGender)emp.Gender).ToString()
        //            : "Unknown",

        //        PhoneNumber = emp.PhoneNumber,
        //        Country = emp.Country,
        //        Job = emp.Job,
        //        Status = emp.EmployeeStatus,
        //        Age = emp.Age,
        //        HireDate = emp.HireDate,

        //        Salary = emp.Salary.HasValue
        //            ? $"{emp.Salary.Value:0.00} $"
        //            : "No Salary",

        //        Departments = (emp.DepartmentsName == null || emp.DepartmentsName.Count == 0)
        //            ? "No Department work"
        //            : string.Join(", ", emp.DepartmentsName),

        //        Projects = (emp.ProjectsName == null || emp.ProjectsName.Count == 0)
        //            ? "No Project work"
        //            : string.Join(", ", emp.ProjectsName)
        //    };
        //}
        public static EmployeeViewModel ToView(clsEmployee emp)
        {

           

            if (emp == null)
                return null;

            EmployeeViewModel vm = new EmployeeViewModel();

            vm.ID = emp.ID;

            vm.FullName = emp.FirstName + " " + emp.LastName;

            vm.Gender = Enum.IsDefined(typeof(enGender), emp.Gender)
      ? ((enGender)emp.Gender).ToString()
      : "Unknown";

            vm.PhoneNumber = emp.PhoneNumber;

            vm.Country = emp.Country;

            vm.Job = emp.Job;

            vm.Status = emp.EmployeeStatus;

            vm.Age = emp.Age;

            vm.HireDate = emp.HireDate;

            vm.Salary = emp.Salary.HasValue
                ? emp.Salary.Value.ToString("0.00") + " $"
                : "No Salary";

            vm.Departments =(emp.DepartmentsName ==null || emp.DepartmentsName.Count==0)?"No Departemnt work":
                string.Join(", ", emp.DepartmentsName);

            vm.Projects =(emp.ProjectsName == null || emp.ProjectsName.Count == 0 )? "No Project work ": 
                
                string.Join(", ",emp.ProjectsName);

            return vm;

        }//تهيئة كل موظف في كلاس العرض


        public static List<EmployeeViewModel> ToViewList(List<clsEmployee> list)
        {
            return list.Select(ToView).ToList();
        }

        public static clsEmployeeDetailsViewModel ViewDetailsModel(clsEmployee employee)
        {
            if (employee == null)
            {
                return new clsEmployeeDetailsViewModel{ FullName = "Not Found " };
            }

        clsEmployeeDetailsViewModel vm = new clsEmployeeDetailsViewModel();
            vm.ID = employee.ID;
            vm.FirstName= employee.FirstName;
            vm.LastName= employee.LastName;
            vm.FullName = employee.FirstName + " " + employee.LastName;
            vm.GenderText = ((enGender)(employee.Gender)).ToString();
            vm.DateOfBirthText=employee.DateOfBirth.ToString("yyyy-MM-dd"); 
            vm.AgeText=employee.Age.ToString();
            vm.PhoneNumber=employee.PhoneNumber;
            vm.Country=employee.Country;
            vm.Job=employee.Job;
            vm.EmployeeStatus=employee.EmployeeStatus;
            vm.HireDateText = employee.HireDate.ToString();
            vm.SalaryText = employee.Salary.HasValue ? employee.Salary.Value.ToString("0,00") : "No Salary";
            vm.SalaryFromDateText=employee.SalaryFromDate.ToString();
            vm.SalaryEndDateText=employee.SalaryEndDate.ToString();
            vm.DepartmentsText = string.Join(",", employee.Departments);
            vm.Projects = employee.Projects.Select(p => new ProjectDetailsViewModel
            {
                ProjectID = p.ProjectID,
                ProjectName = p.ProjectName,
                RoleProjectName = p.RoleProjectName,
                StartDateWorkText = p.StartDateWork.ToString("yyyy-MM-dd")
            }).ToList();
            return vm;
        
        }

        public static clsEmployee ToBLL(EmployeeViewModel vm)
        {
            if (vm == null)
                return null;

            var emp = new clsEmployee();


            emp.ID = vm.ID;

            if (!string.IsNullOrWhiteSpace(vm.FullName))
            {
                var parts = vm.FullName.Split(' ');

                emp.FirstName = parts.Length > 0 ? parts[0] : "";
                emp.LastName = parts.Length > 1 ? parts[1] : "";
            }

            emp.PhoneNumber = vm.PhoneNumber;
            emp.Country = vm.Country;
            emp.Job = vm.Job;
            emp.EmployeeStatus = vm.Status;

            emp.Age = vm.Age;


            enGender gender = (enGender)emp.Gender;


            if (!string.IsNullOrWhiteSpace(vm.Salary))
            {
                var clean = vm.Salary.Replace("$", "").Trim();
                if (decimal.TryParse(clean, out decimal salary))
                    emp.Salary = salary;
            }


            emp.DepartmentsName = string.IsNullOrWhiteSpace(vm.Departments)
                ? new List<string>()
                : vm.Departments.Split(',').Select(x => x.Trim()).ToList();

            emp.ProjectsName = string.IsNullOrWhiteSpace(vm.Projects)
                ? new List<string>()
                : vm.Projects.Split(',').Select(x => x.Trim()).ToList();

            return emp;
        }
    }
}

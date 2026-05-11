using Employee_Business_Layer.Mapping;

using Employee_Data_Access_Layer;
using EmployeeDTO;
using System;
using System.Collections.Generic;
namespace Employee_Business_Layer
{
    public class EmployeeProject
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string RoleProjectName { get; set; }

        public int RoleProjectID { get; set; }

        public DateTime StartDateWork { get; set; }
    }
    public class EmployeeProjectViewModel
    {
        public int ProjectID { get; set; }
        public int RoleProjectID { get; set; }
        public DateTime StartDateWork { get; set; }
    }
    public class clsEmployee
    {
 

        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }

        public string Country { get; set; }
        public string Job { get; set; }

        public decimal? Salary { get; set; }
        public DateTime? SalaryFromDate { get; set; }
        public DateTime? SalaryEndDate { get; set; }

        public int Age { get; set; }

        public List<string> DepartmentsName { get; set; } = new List<string>();
        public List<EmployeeProject> Projects { get; set; } = new List<EmployeeProject>();
        public List<int> Departments { get; set; }=new List<int>();
        public List<string> ProjectsName { get; set; }
        public string EmployeeStatus { get; set; }

        public bool DepartmentIsActive { get; set; }


    }
}

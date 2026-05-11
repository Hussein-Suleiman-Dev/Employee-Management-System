using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDTO
{
    public class DepartmentDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }//معلومات القسم 
    public class clsProjectDTOEmp 
    {

        public  int ProjectID;
        public int RoleProjectID;
        public DateTime StartDateWork;
        public string ProjectName { get; set; }
        public string RoleProjectName { get; set; }
    }//تفاصيل مشروع

    public class SalaryDto
    {
        public decimal? Salary { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }//تفاصيل راتب
    public class EmployeeFullDto
    {
        public EmployeeDto Employee { get; set; }

       // public List<DepartmentDto> Departments { get; set; }

        public List<clsProjectDTOEmp> Projects { get; set; }

        public SalaryDto CurrentSalary { get; set; }

        public int Age { get; set; }

        public string StatusName { get; set; }

        public List<int> DepartmentsIDs { get; set; }

    }//تفاصيل كاملة عن الموظف 
    public class EmployeeDto
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }

        public int CountryID { get; set; }
        public int JobID { get; set; }

        public int EmployeeStatusID { get; set; }
    }
    public class EmployeeListDto
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string DepartmentsNames { get; set; }

        public decimal? Salary { get; set; }

        public string StatusName { get; set; }
        public int Gender { get; set; }
        public string Job { get; set; }
        public string Projects { get; set; } 
        public int Country { get; set; } 
        public DateTime? HireDate { get; set; }
        public bool IsDepartmentActive { get; set; }
    }
}

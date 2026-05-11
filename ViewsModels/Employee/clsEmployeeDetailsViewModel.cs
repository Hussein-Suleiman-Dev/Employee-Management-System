using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Presentation.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public int RoleProjectID { get; set; }
        public string RoleProjectName { get; set; }

        public string StartDateWorkText { get; set; }
    }
    public class clsEmployeeDetailsViewModel
    {
        public int ID { get; set; }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string GenderText { get; set; }
        public string DateOfBirthText { get; set; }
        public string AgeText { get; set; }

        public string PhoneNumber { get; set; }
        public string Country { get; set; }

    
        public string Job { get; set; }
        public string EmployeeStatus { get; set; }
        public string HireDateText { get; set; }

       
        public string SalaryText { get; set; }
        public string SalaryFromDateText { get; set; }
        public string SalaryEndDateText { get; set; }

       
        public string DepartmentsText { get; set; }

        public List<ProjectDetailsViewModel> Projects { get; set; }
    }
}


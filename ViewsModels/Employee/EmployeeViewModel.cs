using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class EmployeeViewModel
    {
        
            public int ID { get; set; }

            public string FullName { get; set; }

            public string Gender { get; set; }

            public int Age { get; set; }

            public string PhoneNumber { get; set; }

            public string Country { get; set; }

            public string Job { get; set; }

            public string Salary { get; set; }

            public string Departments{ get; set; }

         public DateTime? HireDate { get; set; }
            public string Status { get; set; }
        public string Projects { get; set; }
        }


    }


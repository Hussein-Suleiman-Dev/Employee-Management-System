using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Windows_Form1.ViewsModels.Department
{
    public class Department_view_Model
    {

        
            public int DepartmentID { get; set; }
            public string DepartmentName { get; set; }

            public bool IsActive { get; set; }

            // للعرض فقط (اختياري)
            public int EmployeesCount { get; set; }
        }

    }


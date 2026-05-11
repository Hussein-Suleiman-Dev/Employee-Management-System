using DepartmentBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Windows_Form1.ViewsModels.Department.Mapper
{
    public class clsDepartmentMapper
    {
        public static Department_view_Model ToViewModel(clsDepartment dept)
        {
            if (dept == null)
                return null;

            return new Department_view_Model
            {
                DepartmentID = dept.DepartmentId,
                DepartmentName = dept.DepartmentName,
                IsActive = dept.StatusDepartment,
            };
        }

        public static clsDepartment ToBLL(Department_view_Model vm)
        {
            if (vm == null)
                return null;

            return new clsDepartment
            {
                DepartmentId = vm.DepartmentID,
                DepartmentName = vm.DepartmentName,
              StatusDepartment = vm.IsActive
            };
        }

    
        public static List<Department_view_Model> ToViewModelList(List<clsDepartment> list)
        {
            return list?.Select(ToViewModel).ToList()
                   ?? new List<Department_view_Model>();
        }
    }
}


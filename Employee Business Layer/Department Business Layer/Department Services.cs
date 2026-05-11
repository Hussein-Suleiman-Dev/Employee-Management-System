using DepartmentBll;
using Employee_Data_Access_Layer.Department_Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Business_Layer.Department_Business_Layer
{
    public class Department_Services
    {
        public class clsDepartmentServices
        {
            public static DataTable GetAllDepartments()
            {
                return clsDepartmentDataAccess.GetAllDepartments();
            }

            public static int AddDepartment(string departmentName)
            {
                if (string.IsNullOrWhiteSpace(departmentName))
                    return -1;

                return clsDepartmentDataAccess.AddDepartment(departmentName);
            }

            public static bool UpdateDepartment
                (int departmentId, string departmentName, byte statusDept)
            {
                if (departmentId <= 0)
                    return false;

                if (string.IsNullOrWhiteSpace(departmentName))
                    return false;

                return clsDepartmentDataAccess.UpdateDepartment
                    (departmentId, departmentName, statusDept);
            }

            public static bool IsDepartmentActive(int departmentId)
            {
                if (departmentId <= 0)
                    return false;

                return clsDepartmentDataAccess.IsDepartmentActive(departmentId);
            }

            public static clsDepartment Find(int DeptID)
            { 
            
                int Id = -1;
                string Name = "";
                bool isActive = true;
                var item = clsDepartmentDataAccess.Find(DeptID, ref Id, ref Name, ref isActive);
                if (item) 
                {
                    return new clsDepartment
                    {
                        DepartmentId = Id,
                        DepartmentName = Name,
                        StatusDepartment = isActive,
                    };

                }
                return null;
            }

        }

    }
}

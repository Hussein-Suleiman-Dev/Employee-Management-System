using Employee_Business_Layer.Mapping;

using Employee_Data_Access_Layer;
using EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Business_Layer
{
    public static class clsEmployeeService
    {
        public static List<clsEmployee> GetAll()
        {
            var dto = clsEmployeeDataAccess.GetAllEmployees();
           
      var Listemployee= clsEmployeeMapper.ToBLLList(dto);
            foreach (var employee in Listemployee)
            {
                employee.Country = clsEmployeeReferenceData.GetCountryNameByID(employee.ID);
            }
            return Listemployee;
        }

        public static clsEmployee GetById(int id)
        {
            var dto = clsEmployeeDataAccess.GetEmployeeByID(id);
            return clsEmployeeMapper.ToBLL(dto);
        }

        public static int Add(clsEmployee emp)
        {
            var dto = clsEmployeeMapper.ToDTO(emp);
            return clsEmployeeDataAccess.AddNewEmployee(dto);
        }

        public static bool Update(clsEmployee emp)
        {
            var dto = clsEmployeeMapper.ToDTO(emp);
            return clsEmployeeDataAccess.UpdateEmployee(dto);
        }

        public static bool Delete(int id)
        {
            return clsEmployeeDataAccess.DeleteEmployee(id);
        }

        public static EmployeeFullDto PrepareDTO(clsEmployee emp)
        {
            var dto = clsEmployeeMapper.ToDTO(emp);

          

            dto.Employee.CountryID =
                clsEmployeeReferenceData.GetIDsCountry(emp.Country);

            dto.Employee.JobID =
                clsEmployeeReferenceData.GetIDsJobs(emp.Job);

            dto.Employee.EmployeeStatusID =
                clsEmployeeReferenceData.GetStatusIDByName(emp.EmployeeStatus);

            dto.DepartmentsIDs = new List<int>();

            foreach (var d in emp.DepartmentsName)
            {
                dto.DepartmentsIDs.Add(
                    clsEmployeeReferenceData.GetIDsDepartment(d));
            }

            return dto;
        }
    }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Employee_Data_Access_Layer;
using EmployeeDTO;

namespace Employee_Business_Layer.Mapping
{

   
        internal class clsEmployeeMapper
        {
            // ================= DTO → BLL =================
            public static clsEmployee ToBLL(EmployeeFullDto dto)
            {
                if (dto == null)
                    return null;

                clsEmployee emp = new clsEmployee();

                emp.ID = dto.Employee.ID;
                emp.FirstName = dto.Employee.FirstName;
                emp.LastName = dto.Employee.LastName;
                emp.DateOfBirth = dto.Employee.DateOfBirth;
                emp.Gender = dto.Employee.Gender;
                emp.PhoneNumber = dto.Employee.PhoneNumber;

                emp.HireDate = dto.Employee.HireDate;

                emp.Salary = dto.CurrentSalary.Salary;
                emp.SalaryFromDate = dto.CurrentSalary.FromDate;
                emp.SalaryEndDate = dto.CurrentSalary.ToDate;

                emp.DepartmentsName = new List<string>();
                emp.Projects = new List<EmployeeProject>();

                if (dto.Projects != null)
                {
                    foreach (var p in dto.Projects)
                    {
                        emp.Projects.Add(new EmployeeProject
                        {
                            ProjectID = p.ProjectID,
                            RoleProjectID = p.RoleProjectID,
                            StartDateWork = p.StartDateWork
                        });
                    }
                }

                emp.EmployeeStatus = dto.StatusName;

                return emp;
            }

            // ================= BLL → DTO =================
            public static EmployeeFullDto ToDTO(clsEmployee emp)
            {
                if (emp == null)
                    return null;

                EmployeeFullDto dto = new EmployeeFullDto();

                dto.Employee = new EmployeeDto();
                dto.CurrentSalary = new SalaryDto();

                dto.Employee.FirstName = emp.FirstName;
                dto.Employee.LastName = emp.LastName;
                dto.Employee.DateOfBirth = emp.DateOfBirth;
                dto.Employee.Gender = emp.Gender;
                dto.Employee.PhoneNumber = emp.PhoneNumber;
                dto.Employee.HireDate = emp.HireDate ?? DateTime.MinValue;

                dto.CurrentSalary.Salary = emp.Salary;
                dto.CurrentSalary.FromDate = emp.SalaryFromDate;
                dto.CurrentSalary.ToDate = emp.SalaryEndDate;

                dto.DepartmentsIDs = new List<int>();
                dto.Projects = new List<clsProjectDTOEmp>();

                if (emp.Projects != null)
                {
                    foreach (var p in emp.Projects)
                    {
                        dto.Projects.Add(new clsProjectDTOEmp
                        {
                            ProjectID = p.ProjectID,
                            RoleProjectID = p.RoleProjectID,
                            StartDateWork = p.StartDateWork
                        });
                    }
                }

                return dto;
            }

        public static clsEmployee MapListDtoToEmployee(EmployeeListDto d)
        {
            if (d == null)
                return null;

            clsEmployee emp = new clsEmployee();

            emp.ID = d.ID;
            emp.PhoneNumber = d.PhoneNumber;
            emp.HireDate = d.HireDate;
            emp.Salary = d.Salary;
            emp.Gender = d.Gender;
            emp.Age = d.Age;

            emp.EmployeeStatus = d.StatusName;
            emp.Job = d.Job;

            emp.DepartmentIsActive = d.IsDepartmentActive;
           
            // تفكيك الاسم الكامل
            if (!string.IsNullOrWhiteSpace(d.FullName))
            {
                var parts = d.FullName.Split(' ');
                emp.FirstName = parts.Length > 0 ? parts[0] : "";
                emp.LastName = parts.Length > 1 ? parts[1] : "";
            }

            // تحويل قوائم نصية
            emp.DepartmentsName = !string.IsNullOrWhiteSpace(d.DepartmentsNames)
                ? d.DepartmentsNames.Split(',').ToList()
                : new List<string>();

            emp.ProjectsName = !string.IsNullOrWhiteSpace(d.Projects)
                ? d.Projects.Split(',').ToList()
                : new List<string>();

            return emp;
        }
        public static List<clsEmployee> ToBLLList(List<EmployeeListDto> dtoList)
        {
            List<clsEmployee> list = new List<clsEmployee>();

            if (dtoList == null)
                return list;

            for (int i = 0; i < dtoList.Count; i++)
            {
                list.Add(MapListDtoToEmployee(dtoList[i]));
            }

            return list;
        }
    }
    }

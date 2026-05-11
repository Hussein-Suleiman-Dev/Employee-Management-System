using EmployeeDTO;
using DTOProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAlProject;
namespace Employee_Business_Layer.Project_BLL
{
    public class clsMappingProject
    {
        public static clsProjectDto ToDTO(clsProject project)
        {
            if (project == null)
                return null;

            return new clsProjectDto
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                StatusID = project.StatusID,
                isActive = project.isActive
            };
        }

        public static clsProject ToBLL(clsProjectDto dto)
        {
            if (dto == null)
                return null;

            return new clsProject
            {
                ProjectID = dto.ProjectID,
                ProjectName = dto.ProjectName,
                StatusID = dto.StatusID,
                isActive = dto.isActive
            };
        }

        public static List<clsProject> ToBLLList(List<clsProjectDto> list)
        {
            if (list == null)
                return new List<clsProject>();

            return list.Select(ToBLL).ToList();
        }
    }
}
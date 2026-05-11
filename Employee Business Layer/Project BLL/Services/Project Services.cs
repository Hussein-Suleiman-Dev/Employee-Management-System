using Employee_Business_Layer.Project_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAlProject;
namespace Employee_Business_Layer.Project_BLL
{
    public class Project_Services
    {
        public static List<clsProject> GetAllProject()
        { 
        var ProjectDto= clsProjectDataAccess.GetAllProjects();
            return clsMappingProject.ToBLLList(ProjectDto);
        
        }
        public static int AddNewProject(clsProject NewProject)
        { 
        var Project=clsMappingProject.ToDTO(NewProject);
            return clsProjectDataAccess.AddProject(Project);


        }

        public static bool UpdateProject(clsProject UpdatedProject)
        {
            var ProjectDtoUpdated = clsMappingProject.ToDTO(UpdatedProject);
            return clsProjectDataAccess.UpdateProject(ProjectDtoUpdated);
        
        }
        public static clsProject Find(int ProjectID)
        { 
            var ProjectDto=clsProjectDataAccess.GetProjectByID(ProjectID);

            return clsMappingProject.ToBLL(ProjectDto);
        
        }
        public static bool DeleteProject(int ProjectID)
        {

            return clsProjectDataAccess.DeleteProject(ProjectID);

        }
        public static string GetStatusName(int ProjectID)
        { 
        return ProjectRefrenceData.GetProjectStatusName(ProjectID);
        }

    }
}

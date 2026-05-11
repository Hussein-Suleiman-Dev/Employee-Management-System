using Employee_Business_Layer;
using Employee_Business_Layer.Project_BLL;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Presentation.ViewModels.clsMapperEmployeesToviews;

namespace Test_Windows_Form1.ViewsModels.Projects
{
       public static class clsProjectMapper
        {
        // ================= BLL -> ViewModel =================
       


        public static clsProject ToBLL(ProjectViewModel vm)
            {
                if (vm == null)
                    return null;

                return new clsProject
                {
                    ProjectID = vm.ProjectID,
                    ProjectName = vm.ProjectName,
                    StatusID = vm.StatusID,
                   
                    isActive = vm.IsActive,

                    
                    RolesIDs = vm.RolesIDs ?? new List<int>(),
                    RolesNames = vm.RolesNames ?? new List<string>()
                };
            }

        public static ProjectViewModel ToView(clsProject Project)
        {
            if (Project == null)
                return null;
          
            return new ProjectViewModel
            {
                ProjectID = Project.ProjectID,
                ProjectName = Project.ProjectName,
                StatusID = Project.StatusID,
                IsActive = Project.isActive,

              
                StatusName = Project_Services.GetStatusName(Project.ProjectID),

                RolesIDs = Project.RolesIDs ?? new List<int>(),
                RolesNames = Project.RolesNames ?? new List<string>()
            };
        }
        public static List<ProjectViewModel> ToViewList(List<clsProject> list)
            {
                if (list == null)
                    return new List<ProjectViewModel>();
                List<ProjectViewModel>lsp= new List<ProjectViewModel>();
            foreach (clsProject item in list)
            { 
            lsp.Add(ToView(item));
            
            }
            return lsp;
            }

         
            public static List<clsProject> ToBLLList(List<ProjectViewModel> list)
            {
                if (list == null)
                    return new List<clsProject>();

                return list.Select(ToBLL).ToList();
            }


     


    }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Business_Layer.Project_BLL
{
    using DAlProject;
    using Employee_Data_Access_Layer.Project_Data_Access;
    using System.Collections.Generic;

    namespace Employee_Business_Layer.Project_BLL
    {
        public class ProjectRolesService
        {
            // ================= ASSIGN ROLE =================
            public static void AssignRoleToProject(int projectID, int roleID)
            {
               
                ProjectRolesDataAccess.AddRoleToProject(projectID, roleID);
            }

            // ================= GET ROLES =================
            public static List<int> GetRoles(int projectID)
            {
                return ProjectRolesDataAccess.GetRolesByProjectID(projectID);
            }

            // ================= RESET ROLES =================
            public static void SetProjectRoles(int projectID, List<int> roleIDs)
            {
                // 1. امسح القديم
                ProjectRolesDataAccess.DeleteRolesByProject(projectID);

                // 2. أضف الجديد
                foreach (int roleID in roleIDs)
                {
                    ProjectRolesDataAccess.AddRoleToProject(projectID, roleID);
                }
            }
        }
    }
}

using DAlProject;
using Employee_Business_Layer.Project_BLL.Mapping_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOProject.clsRoleProjectDtoSYSTEM;
using static Employee_Business_Layer.Project_BLL.clsProjectRole;

namespace Employee_Business_Layer.Project_BLL
{
    internal class clsRoolProjectServices
    {
        public class RoleProjectsService
        {
            // ================= GET ALL =================
            public static List<clsProjectRole> GetAll()
            {
                var dtoList = RoleProjectsDataAccess.GetAllRoles();
                return clsRoleProjectMapper.ToBLLListPrjectRole(dtoList);
            }

            // ================= FIND =================
            public static clsProjectRole Find(int id)
            {
                var dto = RoleProjectsDataAccess.GetByID(id);
                return clsRoleProjectMapper.ToBLLProjectRole(dto);
            }

            // ================= ADD =================
            public static int Add(clsProjectRole role)
            {
                var dto = clsRoleProjectMapper.ToDTOProjectRole(role);
                return RoleProjectsDataAccess.Add(dto);
            }

            // ================= UPDATE =================
            public static bool Update(clsProjectRole role)
            {
                var dto = clsRoleProjectMapper.ToDTOProjectRole(role);
                return RoleProjectsDataAccess.Update(dto);
            }

            // ================= DELETE =================
            public static bool Delete(int id)
            {
                return RoleProjectsDataAccess.Delete(id);
            }
        }
    }
}

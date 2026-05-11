using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOProject.clsRoleProjectDtoSYSTEM;
using static Employee_Business_Layer.Project_BLL.clsProjectRole;

namespace Employee_Business_Layer.Project_BLL.Mapping_Project
{
    public class clsRoleProjectMapper
    {
        public static RoleProjectDto ToDTOProjectRole(clsProjectRole role)
        {
            if (role == null) return null;

            return new RoleProjectDto
            {
                RoleProjectID = role.RoleProjectID,
                RoleProjectsName = role.RoleProjectsName
            };
        }

      
        public static clsProjectRole ToBLLProjectRole(RoleProjectDto dto)
        {
            if (dto == null) return null;

            return new clsProjectRole
            {
                RoleProjectID = dto.RoleProjectID,
                RoleProjectsName = dto.RoleProjectsName
            };
        }

        // ================= LIST =================
        public static List<clsProjectRole> ToBLLListPrjectRole(List<RoleProjectDto> list)
        {
            return list?.Select(ToBLLProjectRole).ToList() ?? new List<clsProjectRole>();
        }
    }
}


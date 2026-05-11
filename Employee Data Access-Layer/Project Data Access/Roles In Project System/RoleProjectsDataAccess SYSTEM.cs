using Employee_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOProject.clsRoleProjectDtoSYSTEM;

namespace DAlProject
{
    public class RoleProjectsDataAccess
    {
        // ================= GET ALL =================
        public static List<RoleProjectDto> GetAllRoles()
        {
            List<RoleProjectDto> list = new List<RoleProjectDto>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT RoleProjectID, RoleProjectsName FROM RoleProjects";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new RoleProjectDto
                    {
                        RoleProjectID = (int)reader["RoleProjectID"],
                        RoleProjectsName = reader["RoleProjectsName"].ToString()
                    });
                }
            }

            return list;
        }

    
        public static RoleProjectDto GetByID(int id)
        {
            RoleProjectDto role = null;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM RoleProjects WHERE RoleProjectID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    role = new RoleProjectDto
                    {
                        RoleProjectID = (int)reader["RoleProjectID"],
                        RoleProjectsName = reader["RoleProjectsName"].ToString()
                    };
                }
            }

            return role;
        }

      
        public static int Add(RoleProjectDto dto)
        {
            int id = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
                INSERT INTO RoleProjects (RoleProjectsName)
                VALUES (@Name);
                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", dto.RoleProjectsName);

                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Convert.ToInt32(result);
            }

            return id;
        }
 
        public static bool Update(RoleProjectDto dto)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
                UPDATE RoleProjects
                SET RoleProjectsName = @Name
                WHERE RoleProjectID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", dto.RoleProjectID);
                cmd.Parameters.AddWithValue("@Name", dto.RoleProjectsName);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "DELETE FROM RoleProjects WHERE RoleProjectID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

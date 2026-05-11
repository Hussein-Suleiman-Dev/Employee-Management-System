using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//===================Assign Rols for project only===================
namespace Employee_Data_Access_Layer.Project_Data_Access
{
    public class ProjectRolesDataAccess
    {
        // ================= ADD ROLE TO PROJECT =================
        public static void AddRoleToProject(int projectID, int roleID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            INSERT INTO ProjectRoles (ProjectID, RoleID)
            VALUES (@ProjectID, @RoleID)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProjectID", projectID);
                cmd.Parameters.AddWithValue("@RoleID", roleID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ================= GET ROLES BY PROJECT =================
        public static List<int> GetRolesByProjectID(int projectID)
        {
            List<int> roles = new List<int>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT RoleID
            FROM ProjectRoles
            WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add((int)reader["RoleID"]);
                }
            }

            return roles;
        }

        // ================= DELETE ROLES =================
        public static void DeleteRolesByProject(int projectID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            DELETE FROM ProjectRoles
            WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

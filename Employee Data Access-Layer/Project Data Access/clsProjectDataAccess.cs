using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAlProject;
using DTOProject;
using Employee_Data_Access_Layer;
namespace DAlProject
{
    public class ProjectRefrenceData
    {
        public static string GetProjectStatusName(int projectId)
        {
            string statusName = null;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT ps.StatusName
            FROM Project p
            INNER JOIN ProjectStatus ps ON ps.StatusID = p.StatusID
            WHERE p.ProjectID = @ProjectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        statusName = result.ToString();
                    }
                }
            }

            return statusName;
        }

    }

    public class clsProjectDataAccess
    {
        // ================= GET ALL PROJECTS =================
        public static List<clsProjectDto> GetAllProjects()
        {
            List<clsProjectDto> projects = new List<clsProjectDto>();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT ProjectID, ProjectName, StatusID, IsActive
            FROM Project
            WHERE IsActive = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    projects.Add(new clsProjectDto
                    {
                        ProjectID = (int)reader["ProjectID"],
                        ProjectName = reader["ProjectName"].ToString(),
                        StatusID = (int)reader["StatusID"],
                        isActive = (bool)reader["IsActive"]
                    });
                }
            }

            return projects;
        }

        // ================= GET BY ID =================
        public static clsProjectDto GetProjectByID(int projectId)
        {
            clsProjectDto project = null;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT ProjectID, ProjectName, StatusID, IsActive
            FROM Project
            WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    project = new clsProjectDto
                    {
                        ProjectID = (int)reader["ProjectID"],
                        ProjectName = reader["ProjectName"].ToString(),
                        StatusID = (int)reader["StatusID"],
                        isActive = (bool)reader["IsActive"]
                    };
                }
            }

            return project;
        }

        // ================= ADD PROJECT =================
        public static int AddProject(clsProjectDto project)
        {
            int id = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            INSERT INTO Project (ProjectName, StatusID, IsActive)
            VALUES (@ProjectName, @StatusID, @IsActive);
            SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@StatusID", project.StatusID);
                cmd.Parameters.AddWithValue("@IsActive", project.isActive);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    id = Convert.ToInt32(result);
            }

            return id;
        }

        // ================= UPDATE PROJECT =================
        public static bool UpdateProject(clsProjectDto dto)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            UPDATE Project
            SET ProjectName = @ProjectName,
                StatusID = @StatusID,
                IsActive = @IsActive
            WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProjectID", dto.ProjectID);
                cmd.Parameters.AddWithValue("@ProjectName", dto.ProjectName);
                cmd.Parameters.AddWithValue("@StatusID", dto.StatusID);
                cmd.Parameters.AddWithValue("@IsActive", dto.isActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ================= SOFT DELETE =================
        public static bool DeleteProject(int projectID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            UPDATE Project
            SET IsActive = 0
            WHERE ProjectID = @ProjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
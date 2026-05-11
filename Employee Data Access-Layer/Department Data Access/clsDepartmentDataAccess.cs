using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Employee_Data_Access_Layer.Department_Data_Access
{
    public class clsDepartmentDataAccess
    {
        public static DataTable GetAllDepartments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT 
                DepartmentID,
                DepartmentName,
                StatusDepartment
            FROM Department";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception)
                    {
                        return new DataTable();
                    }
                }
            }

            return dt;
        }
        public static int AddDepartment(string DepartmentName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            INSERT INTO Department(DepartmentName)
            VALUES(@DepartmentName);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentName", DepartmentName);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int deptId))
                            return deptId;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            return -1;
        }
        public static bool UpdateDepartment(int IdDepartment, string DepartmentName, byte StatusDept)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string queryUpdate = @"
            UPDATE Department
            SET DepartmentName = @DepartmentName,
                StatusDepartment = @StatusDept
            WHERE DepartmentID = @IdDepartment";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    cmd.Parameters.AddWithValue("@StatusDept", StatusDept);
                    cmd.Parameters.AddWithValue("@IdDepartment", IdDepartment);

                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();

                        return rows > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public static bool IsDepartmentActive(int DepartmentID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT 1
            FROM Department
            WHERE DepartmentID = @DeptID
              AND IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@DeptID", DepartmentID);

                    try
                    {
                        conn.Open();
                        return command.ExecuteScalar() != null;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Find (int FindID,ref int ID,ref string DeptName,ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
            SELECT
                DepartmentID,
                DepartmentName,
                IsActive
            FROM Department
            WHERE DepartmentID = @DepartmentID";

                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue
                        ("@DepartmentID", FindID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader =
                               command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ID = Convert.ToInt32
                                    (reader["DepartmentID"]);

                                DeptName =
                                    reader["DepartmentName"].ToString();

                                IsActive = Convert.ToBoolean
                                    (reader["IsActive"]);

                                isFound = true;
                            }
                        }
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

    }
}

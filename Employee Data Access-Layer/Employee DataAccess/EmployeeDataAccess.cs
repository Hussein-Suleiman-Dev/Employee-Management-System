using EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Employee_Data_Access_Layer
{


    public class clsEmployeeReferenceData
    {

        public static string GetJobNameByID(int jobID)
        {
            string JobName = "";

            SqlConnection connection =
                new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT JobName 
                     FROM Jobs
                     WHERE JobID = @JobID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", jobID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    JobName = result.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return JobName;
        }

        public static string GetCountryNameByID(int countryID)
        {
            string countryName = "";

            SqlConnection connection =
                new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT CountryName
                     FROM Countries
                     WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", countryID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    countryName = result.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return countryName;
        }

        public static string GetStatusNameByID(int statusID)
        {
            string statusName = "";

            SqlConnection connection =
                new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT StatusName
                     FROM Status
                     WHERE IDStatus = @StatusID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StatusID", statusID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    statusName = result.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return statusName;
        }

        public static List<string> GetDepartmentNamesByIDs(List<int> departmentIDs)
        {
            List<string> names = new List<string>();

            foreach (int id in departmentIDs)
            {
                SqlConnection connection =
                    new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT DepartmentName
                         FROM Department
                         WHERE DepartmentID = @DepartmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DepartmentID", id);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                        names.Add(result.ToString());
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return names;
        }

        public static List<string> GetProjectNamesByIDs(List<int> projectIDs)
        {
            List<string> names = new List<string>();

            foreach (int id in projectIDs)
            {
                SqlConnection connection =
                    new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT ProjectName
                         FROM Project
                         WHERE ProjectID = @ProjectID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectID", id);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                        names.Add(result.ToString());
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return names;
        }

        public static int GetIDsCountry(string Country)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @" select C.CountryID from Countries C
	 where C.CountryName=@Country";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@Country", Country);
            int ID = 0;
            try
            {
                connection.Open();
                // int CountryID = 0;
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int CountryID))
                {
                    ID = CountryID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return ID;




        }


        public static int GetIDsJobs(string JobName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"select J.JobID from Jobs J
	where J.JobName=@JobName";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@JobName", JobName);
            int ID = 0;
            try
            {
                connection.Open();
                // int CountryID = 0;
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int CountryID))
                {
                    ID = CountryID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return ID;




        }

        public static int GetIDsDepartment(string DepartmentName)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"select D.DepartmentID from Department D
	where D.DepartmentName=@DepartemntName";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@DepartemntName", DepartmentName);
            int ID = 0;
            try
            {
                connection.Open();
                // int CountryID = 0;
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int CountryID))
                {
                    ID = CountryID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return ID;

        }


        public static int GetStatusIDByName(string statusName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"select S.IDStatus from Status S
	where S.StatusName=@StatusName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StatusName", statusName);

            int ID = 0;
            try
            {
                connection.Open();
                // int CountryID = 0;
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int CountryID))
                {
                    ID = CountryID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return ID;



        }


        public static List<int> GetDepartmentIDsByEmployeeID(int EmployeeID)
        {
            List<int> DepartmentsIDs = new List<int>();

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"select ED.DepartmentID from EmployeeDepartment ED
INNER JOIN Department D on D.DepartmentID=ED.DepartmentID
where Ed.EmployeeID=@EmployeeID";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    DepartmentsIDs.Add((int)Reader["DepartmentID"]);

                }
                Reader.Close();

            }
            catch (Exception)
            {


            }
            finally { Connection.Close(); }
            return DepartmentsIDs;


        }

        public static List<clsProjectDTOEmp> GetProjectsByID(int EmployeeID)
        {
            List<clsProjectDTOEmp> _Project = new List<clsProjectDTOEmp>();//قائمة تحتوي عل تفصيل كل مشروع

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"select ej.ProjectId,ej.RoleProjectID,ej.StartDateWork from EmployeeProjects ej
inner join Project  P on P.ProjectID=ej.ProjectId
where ej.EmployeeID=@EmployeeID;
";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {

                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _Project.Add(new clsProjectDTOEmp
                    {
                        ProjectID = (int)reader["ProjectId"],
                        RoleProjectID = (int)reader["RoleProjectID"],
                        StartDateWork = (DateTime)reader["StartDateWork"]


                    });


                }

                return _Project;


            }
            catch (Exception)
            {

                throw;
            }

            finally { Connection.Close(); }



        }

        public static List<clsProjectDTOEmp> GetProjectsByEmployeeID(int employeeID)
        {
            List<clsProjectDTOEmp> list = new List<clsProjectDTOEmp>();

            string query = @"
    select 
        ep.ProjectId,
        p.ProjectName,
        ep.RoleProjectID,
        rp.RoleProjectsName,
        ep.StartDateWork
    from EmployeeProjects ep
    inner join Project p
        on p.ProjectID = ep.ProjectId
    inner join RoleProjects rp
        on rp.RoleProjectID = ep.RoleProjectID
    where ep.EmployeeID = @EmployeeID";

            SqlConnection conn =
                new SqlConnection(clsDataAccessSetting.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new clsProjectDTOEmp
                    {
                        ProjectID = (int)reader["ProjectId"],
                        ProjectName = reader["ProjectName"].ToString(),

                        RoleProjectID = (int)reader["RoleProjectID"],
                        RoleProjectName = reader["RoleProjectsName"].ToString(),

                        StartDateWork = (DateTime)reader["StartDateWork"]
                    });
                }

                reader.Close();
            }
            finally
            {
                conn.Close();
            }

            return list;
        }


    }







    public class clsEmployeeDataAccess
    {




       

        public static List<EmployeeListDto> GetAllEmployees()
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            List<EmployeeListDto> employeesdto = new List<EmployeeListDto>();
            string query = @"SELECT
    p.PersonID,
    p.FirstName,
    p.LastName,
    e.HireDate,
    p.PhoneNumber,
    S.Salary,
    p.CountryID,
    p.Gender,
    j.JobName AS Jobs,
    DATEDIFF(YEAR, p.DateOfBirth, GETDATE()) AS Age,

  CASE 
    WHEN EXISTS (
        SELECT 1
        FROM EmployeeDepartment ED
        INNER JOIN Department DP 
            ON DP.DepartmentID = ED.DepartmentID
        WHERE ED.EmployeeID = e.PersonID
          AND DP.IsActive = 1
    )
    THEN CAST(1 AS bit)
    ELSE CAST(0 AS bit)
END AS StatusDepartment,

    (SELECT STRING_AGG(DP.DepartmentName, ',')
     FROM EmployeeDepartment ED
     INNER JOIN Department DP ON DP.DepartmentID = ED.DepartmentID
     WHERE ED.EmployeeID = e.PersonID and DP.IsActive=1
    ) AS Departments,

    (SELECT STRING_AGG(pr.ProjectName, ',')
     FROM EmployeeProjects ej
     INNER JOIN Project pr ON pr.ProjectID = ej.ProjectId
     WHERE ej.EmployeeID = e.PersonID
    ) AS Projects,

    ST.StatusName

FROM Employee e
INNER JOIN Person p ON p.PersonID = e.PersonID
LEFT JOIN SalaryHistory S ON S.EmployeeID = e.PersonID AND S.ToDate IS NULL
INNER JOIN Jobs j ON j.JobID = e.JobID

INNER JOIN Status ST ON ST.IDStatus = e.StatusID

WHERE ST.StatusName = 'Active'
  AND e.IsDeleted = 0

";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employeesdto.Add(new EmployeeListDto
                    {
                        FullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString(),
                        ID = (int)reader["PersonID"],
                        Country = (int)reader["CountryID"],
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        HireDate = (DateTime)reader["HireDate"],
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        DepartmentsNames = reader["Departments"].ToString(),
                        StatusName = reader["StatusName"].ToString(),
                        Gender = (int)reader["Gender"],
                      Projects=  (reader["Projects"] != DBNull.Value)?  (string)reader["Projects"]:"",
                        Job = reader["Jobs"].ToString().Trim(),
                        IsDepartmentActive = (bool)reader["StatusDepartment"]
                        
                            
                           
                    });


                }


            }
            catch (Exception)
            {

                throw;
            }
            return employeesdto;

        }

        public static EmployeeFullDto GetEmployeeByID(int employeeID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
SELECT 
    e.PersonID,
    p.FirstName,
    p.LastName,
    p.DateOfBirth,
    p.Gender,
    p.PhoneNumber,
    e.HireDate,

    p.CountryID,
    e.JobID,
    e.StatusID AS EmployeeStatusID,

    s.Salary,
    s.FromDate AS SalaryFromDate,
    s.ToDate AS SalaryEndDate,

    DATEDIFF(YEAR, p.DateOfBirth, GETDATE()) AS Age

FROM Employee e
INNER JOIN Person p ON p.PersonID = e.PersonID
LEFT JOIN SalaryHistory s 
    ON s.EmployeeID = e.PersonID AND s.ToDate IS NULL
WHERE e.PersonID =@EmployeeID and e.IsDeleted=0; 
";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                // ===== Employee DTO =====
                EmployeeDto dto = new EmployeeDto();

                dto.ID = Convert.ToInt32(reader["PersonID"]);
                dto.FirstName = reader["FirstName"].ToString();
                dto.LastName = reader["LastName"].ToString();
                dto.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                dto.Gender = Convert.ToInt32(reader["Gender"]);
                dto.PhoneNumber = reader["PhoneNumber"].ToString();
                dto.HireDate = Convert.ToDateTime(reader["HireDate"]);
                dto.CountryID = Convert.ToInt32(reader["CountryID"]);
                dto.JobID = Convert.ToInt32(reader["JobID"]);
                dto.EmployeeStatusID = Convert.ToInt32(reader["EmployeeStatusID"]);


                SalaryDto salary = new SalaryDto();

                if (reader["Salary"] != DBNull.Value)
                    salary.Salary = Convert.ToDecimal(reader["Salary"]);

                if (reader["SalaryFromDate"] != DBNull.Value)
                    salary.FromDate = Convert.ToDateTime(reader["SalaryFromDate"]);

                if (reader["SalaryEndDate"] != DBNull.Value)
                    salary.ToDate = Convert.ToDateTime(reader["SalaryEndDate"]);


                EmployeeFullDto fdto = new EmployeeFullDto();

                fdto.Employee = dto;
                fdto.CurrentSalary = salary;
                fdto.Age = Convert.ToInt32(reader["Age"]);

                // ===== Relations =====
                fdto.DepartmentsIDs = clsEmployeeReferenceData.GetDepartmentIDsByEmployeeID(employeeID);

                fdto.Projects = clsEmployeeReferenceData
                    .GetProjectsByEmployeeID(employeeID);

                reader.Close();

                return fdto;
            }
            finally
            {
                conn.Close();
            }
        }



        public static int AddNewEmployee(EmployeeFullDto dto)
        {
            string queryPerson = @"
INSERT INTO Person
(FirstName, LastName, Gender, DateOfBirth, PhoneNumber, CountryID)
VALUES
(@FirstName, @LastName, @Gender, @DateOfBirth, @PhoneNumber, @CountryID);

SELECT SCOPE_IDENTITY();";

            string queryEmployee = @"
INSERT INTO Employee
(PersonID, JobID, HireDate, StatusID)
OUTPUT INSERTED.EmployeeID
VALUES
(@PersonID, @JobID, @HireDate, @StatusID);";

            string querySalary = @"
INSERT INTO SalaryHistory
(EmployeeID, Salary, FromDate, ToDate)
VALUES
(@EmployeeID, @Salary, @FromDate, NULL);";

            string queryDept = @"
INSERT INTO EmployeeDepartment
(EmployeeID, DepartmentID)
VALUES
(@EmployeeID, @DepartmentID);";

            string queryProj = @"
INSERT INTO EmployeeProjects
(EmployeeID, ProjectId, RoleProjectID, StartDateWork)
VALUES
(@EmployeeID, @ProjectId, @RoleProjectID, @StartDateWork);";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                SqlTransaction tr = null;

                try
                {
                    conn.Open();
                    tr = conn.BeginTransaction();

                    // 🔹 1. Insert Person
                    SqlCommand cmd1 = new SqlCommand(queryPerson, conn, tr);
                    cmd1.Parameters.AddWithValue("@FirstName", dto.Employee.FirstName);
                    cmd1.Parameters.AddWithValue("@LastName", dto.Employee.LastName);
                    cmd1.Parameters.AddWithValue("@Gender", dto.Employee.Gender);
                    cmd1.Parameters.AddWithValue("@DateOfBirth", dto.Employee.DateOfBirth);
                    cmd1.Parameters.AddWithValue("@PhoneNumber", dto.Employee.PhoneNumber);
                    cmd1.Parameters.AddWithValue("@CountryID", dto.Employee.CountryID);

                    int personID = Convert.ToInt32(cmd1.ExecuteScalar());

                    // 🔹 2. Insert Employee + get EmployeeID
                    SqlCommand cmd2 = new SqlCommand(queryEmployee, conn, tr);
                    cmd2.Parameters.AddWithValue("@PersonID", personID);
                    cmd2.Parameters.AddWithValue("@JobID", dto.Employee.JobID);
                    cmd2.Parameters.AddWithValue("@HireDate", (object?)dto.Employee.HireDate ?? DBNull.Value);
                    cmd2.Parameters.AddWithValue("@StatusID", dto.Employee.EmployeeStatusID);

                    int employeeID = Convert.ToInt32(cmd2.ExecuteScalar());

                    // 🔹 3. Salary
                    SqlCommand cmd3 = new SqlCommand(querySalary, conn, tr);
                    cmd3.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd3.Parameters.AddWithValue("@Salary", dto.CurrentSalary.Salary ?? (object)DBNull.Value);
                    cmd3.Parameters.AddWithValue("@FromDate", dto.CurrentSalary.FromDate ?? DateTime.Now);

                    cmd3.ExecuteNonQuery();

                    // 🔹 4. Departments
                    if (dto.DepartmentsIDs != null)
                    {
                        foreach (int depID in dto.DepartmentsIDs)
                        {
                            SqlCommand cmd4 = new SqlCommand(queryDept, conn, tr);
                            cmd4.Parameters.AddWithValue("@EmployeeID", employeeID);
                            cmd4.Parameters.AddWithValue("@DepartmentID", depID);

                            cmd4.ExecuteNonQuery();
                        }
                    }

                    // 🔹 5. Projects
                    if (dto.Projects != null)
                    {
                        foreach (var proj in dto.Projects)
                        {
                            SqlCommand cmd5 = new SqlCommand(queryProj, conn, tr);
                            cmd5.Parameters.AddWithValue("@EmployeeID", employeeID);
                            cmd5.Parameters.AddWithValue("@ProjectId", proj.ProjectID);
                            cmd5.Parameters.AddWithValue("@RoleProjectID", proj.RoleProjectID);
                            cmd5.Parameters.AddWithValue("@StartDateWork", proj.StartDateWork);

                            cmd5.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();

                    return employeeID;
                }
                catch (Exception)
                {
                    if (tr != null)
                        tr.Rollback();

                    return -1;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static bool UpdateEmployee(EmployeeFullDto dto)
        {



            string queryPerson = @"
UPDATE Person
SET 
    FirstName = @FirstName,
    LastName = @LastName,
    Gender = @Gender,
    DateOfBirth = @DateOfBirth,
    PhoneNumber = @PhoneNumber,
    CountryID = @CountryID
WHERE PersonID = @PersonID";

            string queryEmployee = @"
UPDATE Employee
SET 
    JobID = @JobID,
    HireDate = @HireDate,
    StatusID = @StatusID
WHERE PersonID = @PersonID";
            string querySalary = @"
UPDATE SalaryHistory
SET 
    Salary = @Salary,
    FromDate = @FromDate
WHERE EmployeeID = @EmployeeID
AND ToDate IS NULL";




            string queryDeleteDept = @"
DELETE FROM EmployeeDepartment
WHERE EmployeeID = @EmployeeID";

            string queryDept = @"
INSERT INTO EmployeeDepartment
(EmployeeID, DepartmentID)
VALUES
(@EmployeeID, @DepartmentID)";
            string queryDeleteProj = @"
DELETE FROM EmployeeProjects
WHERE EmployeeID = @EmployeeID";

            string queryProj = @"
INSERT INTO EmployeeProjects
(EmployeeID, ProjectId, RoleProjectID, StartDateWork)
VALUES
(@EmployeeID, @ProjectId, @RoleProjectID, @StartDateWork)";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                SqlTransaction tr = null;
                {
                    try
                    {
                        conn.Open();
                        tr = conn.BeginTransaction();
                        SqlCommand cmd1 = new SqlCommand(queryPerson, conn, tr);
                        cmd1.Parameters.AddWithValue("@FirstName", dto.Employee.FirstName);
                        cmd1.Parameters.AddWithValue("@LastName", dto.Employee.LastName);
                        cmd1.Parameters.AddWithValue("@Gender", dto.Employee.Gender);
                        cmd1.Parameters.AddWithValue("@DateOfBirth", dto.Employee.DateOfBirth);
                        cmd1.Parameters.AddWithValue("@PhoneNumber", dto.Employee.PhoneNumber);
                        cmd1.Parameters.AddWithValue("@CountryID", dto.Employee.CountryID);

                        int personID = dto.Employee.ID;


                        SqlCommand cmd2 = new SqlCommand(queryEmployee, conn, tr);
                        cmd2.Parameters.AddWithValue("@PersonID", personID);
                        cmd2.Parameters.AddWithValue("@JobID", dto.Employee.JobID);
                        cmd2.Parameters.AddWithValue("@HireDate", dto.Employee.HireDate);
                        cmd2.Parameters.AddWithValue("@StatusID", dto.Employee.EmployeeStatusID);

                        cmd2.ExecuteNonQuery();


                        SqlCommand cmd3 = new SqlCommand(querySalary, conn, tr);
                        cmd3.Parameters.AddWithValue("@EmployeeID", personID);
                        cmd3.Parameters.AddWithValue("@Salary", dto.CurrentSalary.Salary.HasValue ? dto.CurrentSalary.Salary.Value : (object)DBNull.Value);
                        cmd3.Parameters.AddWithValue("@FromDate", dto.CurrentSalary.FromDate ?? DateTime.Now);

                        cmd3.ExecuteNonQuery();


                        foreach (int depID in dto.DepartmentsIDs)
                        {
                            SqlCommand cmd4 = new SqlCommand(queryDept, conn, tr);
                            cmd4.Parameters.AddWithValue("@EmployeeID", personID);
                            cmd4.Parameters.AddWithValue("@DepartmentID", depID);


                            cmd4.ExecuteNonQuery();

                        }


                        if (dto.Projects != null)
                        {
                            foreach (clsProjectDTOEmp proj in dto.Projects)
                            {
                                SqlCommand cmd5 = new SqlCommand(queryProj, conn, tr);
                                cmd5.Parameters.AddWithValue("@EmployeeID", personID);
                                cmd5.Parameters.AddWithValue("@ProjectId", proj.ProjectID);
                                cmd5.Parameters.AddWithValue("@RoleProjectID", proj.RoleProjectID);
                                cmd5.Parameters.AddWithValue("@StartDateWork", proj.StartDateWork);

                                cmd5.ExecuteNonQuery();
                            }
                        }

                        tr.Commit();
                        return true;


                    }
                    catch (Exception)
                    {

                        if (tr != null)
                            tr.Rollback();

                        return false;
                    }
                }



            }


        }

        public static bool DeleteEmployee(int employeeID)
        {
            string query = @"
UPDATE Employee
SET IsDeleted = 1
WHERE PersonID = @PersonID";

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PersonID", employeeID);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
                catch
                {
                    return false;
                }
            }
        }



    }
}

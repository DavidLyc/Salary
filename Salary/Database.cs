using System.Data.SqlClient;
using Salary.model;

namespace Salary
{
    public class Database
    {
        private static Database _dbInstance;
        private const string Connsql = "server=.;database=salary;integrated security=SSPI";
        private readonly SqlConnection _sqlConnection = new SqlConnection();
        private const string Comma = ",";
        private const string LoginSql = "SELECT COUNT(*) FROM [salary].[dbo].[user] WHERE ";
        private const string AddUserSql = "INSERT INTO [salary].[dbo].[user] (employeeID,employeeName,employeeSex" +
                    ",education,jobTitle,hiredDate,postID,departmentID, password) VALUES (";
        private const string UpdateUserSql = "UPDATE ";

        private Database()
        {
            _sqlConnection.ConnectionString = Connsql;
        }

        public static Database GetDbInstance()
        {
            return _dbInstance ?? (_dbInstance = new Database());
        }

        //验证登录
        public bool ValidateLogin(string id, string password)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(LoginSql + "employeeID=" + id + " AND password=" + password, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var ret = !reader[""].ToString().Equals("0");
            _sqlConnection.Close();
            return ret;
        }

        //添加员工
        public void AddUser(User user)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(AddUserSql
                                            + user.Id + Comma
                                            + user.Name + Comma
                                            + user.Sex + Comma
                                            + user.Education + Comma
                                            + user.JobTitle + Comma
                                            + user.HireDate + Comma
                                            + user.PostId + Comma
                                            + user.DepartmentId + Comma
                                            + user.Password + ");", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //修改用户
        public void UpdateUser(User user)
        {

        }

    }

}
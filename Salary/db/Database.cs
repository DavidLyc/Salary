using System.Collections.Generic;
using System.Data.SqlClient;
using Salary.model;

namespace Salary.db
{
    public class Database
    {
        private static Database _dbInstance;
        private const string Connsql = "server=.;database=salary;integrated security=SSPI";
        private readonly SqlConnection _sqlConnection = new SqlConnection();
        private const string Comma = ",";
        private const string Sem = "'";
        private const string LoginSql = "SELECT COUNT(*) FROM [salary].[dbo].[user] WHERE ";
        private const string AddUserSql = "INSERT INTO [salary].[dbo].[user] (employeeID,employeeName,employeeSex" +
                                          ",education,jobTitle,hiredDate,postName,departmentName, password) VALUES (";
        private const string IsUserIdExistSql = "SELECT COUNT(*) FROM [salary].[dbo].[user] WHERE employeeID=";
        private const string GetPostsInDepartmentSql = "SELECT postName FROM [salary].[dbo].[post] WHERE departmentName=";
        private const string UpdateUserSql = "UPDATE [salary].[dbo].[user] SET ";
        private const string AddChargebackSql = "INSERT INTO [salary].[dbo].[chargeback] (chargebackEmployeeID," +
                                                "chargebackMoney,chargebackContent) VALUES (";


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
            var sqlCommand = new SqlCommand(LoginSql + "employeeID='" + id + "' AND password='" + password + Sem, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var ret = !reader[""].ToString().Equals("0");
            _sqlConnection.Close();
            return ret;
        }

        //获取某个部门下的所有岗位
        public List<string> GetAllPostInDepartment(string departmentName)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(GetPostsInDepartmentSql + Sem + departmentName + Sem, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            var posList = new List<string>();
            while (reader.Read())
            {
                posList.Add(reader["postName"].ToString());
            }
            _sqlConnection.Close();
            return posList;
        }

        //添加员工
        public void AddUser(User user)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(AddUserSql + user.Id + Comma
                                            + Sem + user.Name + Sem + Comma
                                            + Sem + user.Sex + Sem + Comma
                                            + Sem + user.Education + Sem + Comma
                                            + Sem + user.JobTitle + Sem + Comma
                                            + Sem + user.HireDate + Sem + Comma
                                            + Sem + user.PostName + Sem + Comma
                                            + Sem + user.DepartmentName + Sem + Comma
                                            + Sem + user.Password + "');", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //修改用户
        public void UpdateUser(User user)
        {
            _sqlConnection.Open();
            //            var sqlCommand = new SqlCommand(IsUserIdExistSql + userId, _sqlConnection);
            _sqlConnection.Close();
        }

        //判断员工号是否已存在
        public bool IsUserIdExist(string userId)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(IsUserIdExistSql + userId, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var ret = !reader[""].ToString().Equals("0");
            _sqlConnection.Close();
            return ret;
        }

        public void AddChargeback(Chargeback chargeback)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(IsUserIdExistSql +
                                            Sem + chargeback.ChargebackEmployeeId + Sem + Comma
                                            + chargeback.ChargebackMoney + Comma
                                            + Sem + chargeback.ChargebackContent + "')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

    }

}
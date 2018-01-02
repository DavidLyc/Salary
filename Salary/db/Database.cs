using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
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
                                          ",education,jobTitle,hiredDate,postName,departmentName,password,salary) VALUES (";
        private const string IsUserIdExistSql = "SELECT COUNT(*) FROM [salary].[dbo].[user] WHERE employeeID=";
        private const string GetPostsInDepartmentSql = "SELECT postName FROM [salary].[dbo].[post] WHERE departmentName=";
        private const string UpdateUserSql = "UPDATE [salary].[dbo].[user] SET ";
        private const string GetUserSql = "SELECT employeeID,employeeName,employeeSex,education,jobTitle,hiredDate,postName"
                                          + ",departmentName,password,salary FROM [salary].[dbo].[user] WHERE employeeID=";
        private const string AddChargebackSql = "INSERT INTO [salary].[dbo].[chargeback] (chargebackEmployeeID," +
                                                "chargebackMoney,chargebackContent) VALUES (";
        private const string GetAllowanceByPostNameSql = "SELECT postAllowance FROM [salary].[dbo].[post] WHERE postName=";
        private const string GetCharbackSql = "SELECT chargebackContent,chargebackMoney FROM [salary].[dbo].[chargeback]"
                                              + "WHERE chargebackEmployeeID=";

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
                                            + Sem + user.Password + Sem + Comma
                                            + Sem + user.BasicSalary + "');", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //得到员工信息
        public User GetUser(string userId)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(GetUserSql + Sem + userId + Sem, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var user = new User
            {
                Id = reader["employeeID"].ToString(),
                Name = reader["employeeName"].ToString(),
                Sex = reader["employeeSex"].ToString(),
                Education = reader["education"].ToString(),
                JobTitle = reader["jobTitle"].ToString(),
                HireDate = reader["hiredDate"].ToString(),
                PostName = reader["postName"].ToString(),
                DepartmentName = reader["departmentName"].ToString(),
                Password = reader["password"].ToString(),
                BasicSalary = Convert.ToSingle(reader["salary"].ToString())
            };
            _sqlConnection.Close();
            return user;
        }

        //修改用户
        public void UpdateUser(User user)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(UpdateUserSql
                                  + "employeeName=" + Sem + user.Name + Sem + Comma
                                  + "employeeSex=" + Sem + user.Sex + Sem + Comma
                                  + "education=" + Sem + user.Education + Sem + Comma
                                  + "jobTitle=" + Sem + user.JobTitle + Sem + Comma
                                  + "hiredDate=" + Sem + user.HireDate + Sem + Comma
                                  + "postName=" + Sem + user.PostName + Sem + Comma
                                  + "departmentName=" + Sem + user.DepartmentName + Sem + Comma
                                  + "password=" + Sem + user.Password + Sem + Comma
                                  + "salary=" + user.BasicSalary
                                  + " WHERE employeeID=" + Sem + user.Id + Sem, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //判断员工号是否已存在
        public bool IsUserIdExist(string userId)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(IsUserIdExistSql + Sem + userId + Sem, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var ret = !reader[""].ToString().Equals("0");
            _sqlConnection.Close();
            return ret;
        }

        //添加扣款
        public void AddChargeback(Chargeback chargeback)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(AddChargebackSql +
                                            Sem + chargeback.ChargebackEmployeeId + Sem + Comma
                                            + chargeback.ChargebackMoney + Comma
                                            + Sem + chargeback.ChargebackContent + "')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //根据岗位得到岗位津贴
        public float GetAllowanceByPostName(string postName)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(GetAllowanceByPostNameSql + Sem + postName.Trim() + Sem, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            var allowance = Convert.ToSingle(reader["postAllowance"]);
            _sqlConnection.Close();
            return allowance;
        }

        //根据员工ID获得扣款
        public List<Chargeback> GetChargebacksById(string userId)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(GetCharbackSql + userId, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            var chargbackList = new List<Chargeback>();
            while (reader.Read())
            {
                var chargeback = new Chargeback(reader["chargebackMoney"].ToString()
                    , reader["chargebackContent"].ToString().Trim());
                chargbackList.Add(chargeback);
            }
            _sqlConnection.Close();
            return chargbackList;
        }

    }

}
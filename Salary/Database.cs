using System.Data.SqlClient;
using System.Diagnostics;

namespace Salary
{
    public class Database
    {
        private static Database _dbInstance;
        private const string Connsql = "server=.;database=salary;integrated security=SSPI";
        private readonly SqlConnection _sqlConnection = new SqlConnection();
        private const string LoginSql = "SELECT COUNT(*) FROM [salary].[dbo].[user] WHERE ";

        private Database()
        {
            _sqlConnection.ConnectionString = Connsql;
        }

        public static Database GetDbInstance()
        {
            return _dbInstance ?? (_dbInstance = new Database());
        }

        //验证登录
        public void ValidateLogin(string id, string password)
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand(LoginSql + "employeeID=" + id + " AND password=" + password, _sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            Debug.WriteLine(reader[""].ToString().Equals("0") ? "登录失败" : "登录成功");
            _sqlConnection.Close();
        }

    }

}
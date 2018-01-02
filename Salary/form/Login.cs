using System;
using System.Windows.Forms;
using Salary.db;

namespace Salary.form
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            var userId = textBox1.Text;
            var password = textBox2.Text;
            if (userId.Trim().Length == 0 || password.Trim().Length == 0)
            {
                MessageBox.Show(@"员工号或密码不能为空！");
            }
            else if (userId.Trim().Equals("admin") && password.Trim().Equals("123"))
            {
                this.Hide();
                new Manage().Show();
            }
            else
            {
                if (Database.GetDbInstance().ValidateLogin(userId, password))
                {
                    this.Hide();
                    new WatchSalary(userId).Show();
                }
                else
                {
                    MessageBox.Show(@"员工号或密码错误!");
                }
            }
        }

    }
}

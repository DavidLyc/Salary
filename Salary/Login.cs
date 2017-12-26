using System;
using System.Windows.Forms;

namespace Salary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void UserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
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
            else
            {
                Database.GetDbInstance().ValidateLogin(userId, password);
            }
        }

    }
}

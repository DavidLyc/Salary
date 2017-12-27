using System;
using System.Windows.Forms;
using Salary.model;

namespace Salary
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, EventArgs e)
        {
            var id = userIdBox.Text;
            var name = nameBox.Text;
            var sex = sexBox.Text;
            var education = educationBox.Text;
            var jobTitle = jobTitleBox.Text;
            var hireDate = hireDatePicker.Text;
            var postId = postBox.Text;     //!!!
            var password = passwordBox.Text;
            var departmentId = departmentBox.Text;
            if (name.Trim().Length == 0)
            {
                MessageBox.Show(@"姓名不能为空！");
            }
            else if (id.Trim().Length == 0)
            {
                MessageBox.Show(@"员工号不能为空！");
            }
            else if (password.Trim().Length == 0)
            {
                MessageBox.Show(@"密码不能为空！");
            }
            else
            {
                var user = new User(id, name, sex, education, jobTitle, hireDate, postId, password, departmentId);
                Database.GetDbInstance().AddUser(user);
                if (MessageBox.Show(@"添加成功") == DialogResult.None)
                {
                    Hide();
                }
            }
        }

    }
}

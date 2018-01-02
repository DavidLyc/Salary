using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Salary.db;
using Salary.model;

namespace Salary.form
{
    public partial class ModifyUser : Form
    {
        public ModifyUser()
        {
            InitializeComponent();
        }

        private void Button_Confirm(object sender, EventArgs e)
        {
            var id = userIdBox.Text.Trim();
            var name = nameBox.Text.Trim();
            var sex = sexBox.Text.Trim();
            var education = educationBox.Text.Trim();
            var jobTitle = jobTitleBox.Text.Trim();
            var hireDate = hireDatePicker.Value.ToShortDateString();
            var postName = postBox.Text.Trim();
            var password = passwordBox.Text.Trim();
            var departmentName = departmentBox.Text.Trim();
            var salary = salaryBox.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show(@"姓名不能为空！");
            }
            else if (id.Length == 0)
            {
                MessageBox.Show(@"员工号不能为空！");
            }
            else if (password.Length == 0)
            {
                MessageBox.Show(@"密码不能为空！");
            }
            else if (salary.Length == 0)
            {
                MessageBox.Show(@"基本工资不能为空！");
            }
            else
            {
                var user = new User(id, name, sex, education, jobTitle, hireDate, postName, password, departmentName,
                      Convert.ToSingle(salary));
                Database.GetDbInstance().UpdateUser(user);
                MessageBox.Show(@"修改成功！");
            }

        }

        private void UserIdBox_TextChanged(object sender, EventArgs e)
        {
            var id = userIdBox.Text;
            if (id.Trim().Length != 0 && Database.GetDbInstance().IsUserIdExist(id))
            {
                userIdBox.ForeColor = Color.Black;
                var user = Database.GetDbInstance().GetUser(id);
                nameBox.Text = user.Name.Trim();
                sexBox.SelectedItem = user.Sex;
                educationBox.SelectedItem = user.Education.Trim();
                jobTitleBox.SelectedItem = user.JobTitle.Trim();
                hireDatePicker.Text = user.HireDate;
                passwordBox.Text = user.Password.Trim();
                departmentBox.SelectedItem = user.DepartmentName.Trim();
                salaryBox.Text = user.BasicSalary.ToString(CultureInfo.InvariantCulture);
                //将部门对应的岗位填入postbox
                postBox.Items.Clear();
                var postList = Database.GetDbInstance().GetAllPostInDepartment(departmentBox.Text);
                foreach (var post in postList)
                {
                    postBox.Items.Add(post);
                }
                postBox.SelectedItem = user.PostName;
            }
            else
            {
                userIdBox.ForeColor = Color.Red;
                nameBox.Clear();
                sexBox.ResetText();
                educationBox.ResetText();
                jobTitleBox.ResetText();
                hireDatePicker.ResetText();
                passwordBox.Clear();
                departmentBox.ResetText();
                salaryBox.Clear();
                postBox.Items.Clear();
            }
        }

    }
}

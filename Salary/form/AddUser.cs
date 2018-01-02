using System;
using System.Windows.Forms;
using Salary.db;
using Salary.model;

namespace Salary.form
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {
            educationBox.SelectedIndex = 0;
            sexBox.SelectedIndex = 0;
            jobTitleBox.SelectedIndex = 0;
            departmentBox.SelectedIndex = 0;
        }

        private void ConfirmClick(object sender, EventArgs e)
        {
            var id = userIdBox.Text;
            var name = nameBox.Text;
            var sex = sexBox.Text;
            var education = educationBox.Text;
            var jobTitle = jobTitleBox.Text;
            var hireDate = hireDatePicker.Value.ToShortDateString();
            var postName = postBox.Text.Trim();
            var password = passwordBox.Text;
            var departmentName = departmentBox.Text;
            var salary = salaryBox.Text;
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
            else if (salary.Trim().Length == 0)
            {
                MessageBox.Show(@"基本工资不能为空！");
            }
            else if (Database.GetDbInstance().IsUserIdExist(id))
            {
                MessageBox.Show(@"该员工号已存在！");
            }
            else
            {
                var user = new User(id, name, sex, education, jobTitle, hireDate, postName, password, departmentName
                    , Convert.ToSingle(salary));
                Database.GetDbInstance().AddUser(user);
                if (MessageBox.Show(@"添加成功") == DialogResult.None)
                {
                    Hide();
                }
            }
        }

        private void DepartmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            postBox.Items.Clear();
            //将部门对应的岗位填入postbox
            var postList = Database.GetDbInstance().GetAllPostInDepartment(departmentBox.Text);
            foreach (var post in postList)
            {
                postBox.Items.Add(post);
            }
            postBox.SelectedIndex = 0;
        }

    }
}

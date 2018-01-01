using System;
using System.Windows.Forms;

namespace Salary.form
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        //添加员工
        private void AddUserClick(object sender, EventArgs e)
        {
            new AddUser().Show();
        }

        //修改用户信息
        private void ModifyUserClick(object sender, EventArgs e)
        {
            new ModifyUser().Show();
        }

        //上报扣款表
        private void UploadChargebackClick(object sender, EventArgs e)
        {
            new Chargeback().Show();
        }

    }
}

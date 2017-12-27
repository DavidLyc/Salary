using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary
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

        }

        //上报扣款表
        private void UploadChargebackClick(object sender, EventArgs e)
        {

        }

    }
}

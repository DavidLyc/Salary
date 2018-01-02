using System;
using System.Windows.Forms;
using Salary.db;

namespace Salary.form
{
    public partial class Chargeback : Form
    {
        public Chargeback()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var employeeId = textBox1.Text;
            var reason = textBox2.Text;
            var money = textBox3.Text;
            if (employeeId.Trim().Equals("") || reason.Trim().Equals("") || money.Trim().Equals(""))
            {
                MessageBox.Show(@"请将内容填写完整！");
            }
            else if (!Database.GetDbInstance().IsUserIdExist(employeeId))
            {
                MessageBox.Show(@"该员工号不存在！");
            }
            else
            {
                Database.GetDbInstance().AddChargeback(new model.Chargeback(employeeId, money, reason));
                MessageBox.Show(@"操作成功！");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Salary.db;

namespace Salary.form
{
    public partial class WatchSalary : Form
    {
        private readonly string _userId;
        private float _totalSalary = 0;

        public WatchSalary(string userId)
        {
            this._userId = userId;
            InitializeComponent();
            LoadSalary();
            LoadChargeback();
            totalSalaryLabel.Text = _totalSalary.ToString(CultureInfo.InvariantCulture);
        }

        private void LoadSalary()
        {
            var user = Database.GetDbInstance().GetUser(_userId);
            nameLabel.Text = user.Name;
            basicSalaryLabel.Text = user.BasicSalary.ToString(CultureInfo.InvariantCulture);
            allowanceLabel.Text = Database.GetDbInstance().GetAllowanceByPostName(user.PostName).ToString(CultureInfo.InvariantCulture);
            _totalSalary += (Convert.ToSingle(basicSalaryLabel.Text) + Convert.ToSingle(allowanceLabel.Text));
        }

        private void LoadChargeback()
        {
            var chargebacks = Database.GetDbInstance().GetChargebacksById(_userId);
            if (chargebacks == null) return;
            foreach (var chargeback in chargebacks)
            {
                var index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells[0].Value = chargeback.ChargebackContent;
                dataGridView.Rows[index].Cells[1].Value = chargeback.ChargebackMoney;
                _totalSalary -= Convert.ToSingle(chargeback.ChargebackMoney);
            }
        }

        private void Button_Confirm(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

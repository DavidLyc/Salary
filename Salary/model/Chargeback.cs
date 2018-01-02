using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.model
{
    public class Chargeback
    {
        public string ChargebackEmployeeId { get; set; }
        public string ChargebackMoney { get; set; }
        public string ChargebackContent { get; set; }

        public Chargeback(string chargebackEmployeeId, string chargebackMoney, string chargebackContent)
        {
            ChargebackEmployeeId = chargebackEmployeeId;
            ChargebackMoney = chargebackMoney;
            ChargebackContent = chargebackContent;
        }

        public Chargeback(string chargebackMoney, string chargebackContent)
        {
            ChargebackMoney = chargebackMoney;
            ChargebackContent = chargebackContent;
        }

    }
}

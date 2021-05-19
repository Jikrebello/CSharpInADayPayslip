using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInADayPayslip
{
    class Manager : Staff
    {
        // Fields
        private const float managerHourlyRate = 50;

        // Properties
        public int Allowance { get; private set; }

        // Constructor
        public Manager(string _name) : base(_name, managerHourlyRate)
        {

        }

        // Methods
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + "Manager Hourly Rate = " + managerHourlyRate + "\n" + " Allowance = " + Allowance;
        }

    }
}

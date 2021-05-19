using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInADayPayslip
{
    class Admin : Staff
    {
        // Fields
        private const float overTimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        // Properties
        public float Overtime { get; private set; }

        // Constructor
        public Admin(string _name) : base(_name, adminHourlyRate)
        {

        }

        // Methods
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overTimeRate * (HoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + "Admin Hourly Rate = " + adminHourlyRate + "\n" + " Overtime = " + Overtime + "\n" + " overTimeRate = " + overTimeRate;
        }

    }
}

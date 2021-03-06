using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInADayPayslip
{
    class Staff
    {
        // Fields
        private float hourlyRate;
        private int hWorked;

        // Properties
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get { return hWorked; }
            set
            {
                if (value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        // Constructor
        public Staff(string _name, float _rate)
        {
            NameOfStaff = _name;
            hourlyRate = _rate;
        }

        // Methods
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Name of Staff = " + NameOfStaff + "\n" + "hourlyRate = " + hourlyRate + "\n" + "hWorked = " + hWorked;
        }


    }
}

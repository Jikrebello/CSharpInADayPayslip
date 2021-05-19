using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInADayPayslip
{
    class PaySlip
    {
        // Fields
        private int month;
        private int year;
        // Enum
        enum MonthsOfTheYear
        {
            JAN = 1,
            FEB,
            MAR,
            APR,
            MAY,
            JUN,
            JUL,
            AUG,
            SEP,
            OCT,
            NOV,
            DEC
        }

        // Construtor
        public PaySlip(int _payMonth, int _payYear)
        {
            month = _payMonth;
            year = _payYear;
        }

        // Methods
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff staff in myStaff)
            {
                path = staff.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfTheYear)month ,year);
                    sw.WriteLine("==========================");
                    sw.WriteLine("Name of Staff: " + staff.NameOfStaff);
                    sw.WriteLine("Hours Worked: " + staff.HoursWorked);
                    sw.WriteLine();
                    sw.WriteLine("Basic Pay: {0:C}",staff.BasicPay);
                    if (staff.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: {0:C}", ((Manager)staff).Allowance);
                    }
                    else if (staff.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Overtime: {0:C}", ((Admin)staff).Overtime);
                    }
                    sw.WriteLine();
                    sw.WriteLine("==========================");
                    sw.WriteLine("Total Pay: {0:C}", staff.TotalPay);
                    sw.WriteLine("==========================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummery(List<Staff> myStaff)
        {
            List<Staff> staffList = myStaff;

            var results = from Staff in staffList 
                          where Staff.HoursWorked < 10 
                          orderby Staff.NameOfStaff ascending
                          select new { Staff.NameOfStaff, Staff.HoursWorked };

            string path = "summary.txt";
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine("Staff with less than 10 working hours.");
            sw.WriteLine();

            foreach (var staff in results)
            {
                sw.WriteLine("Name of Staff: " + staff.NameOfStaff + " Hours Worked: " + staff.HoursWorked);
            }

            sw.Close();
        }

        public override string ToString()
        {
            return "month  = " + month + "\n" + " year = " + year;
        }


    }
}

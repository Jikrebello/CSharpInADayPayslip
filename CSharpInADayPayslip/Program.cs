using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInADayPayslip
{
    class Program
    {

        
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("Please enter the year: ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    year = input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (month == 0)
            {
                Console.WriteLine("Please enter the month: ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 12)
                    {
                        Console.WriteLine("Please enter a valid month between 1 and 12.");
                        input = 0;
                    }
                    else
                    {
                        month = input;
                    }


                    month = input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter the hour worked for " + myStaff[i].NameOfStaff + ": ");
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    myStaff[i].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummery(myStaff);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpInADayPayslip
{
    class FileReader
    {
        List<Staff> myStaff = new List<Staff>();
        string[] result = new string[2];
        string path = "staff.txt";
        string[] seperator = { ", " };
        
        public List<Staff> ReadFile()
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        // Read and display lines from the file until the end the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            result = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                            if (result[1] == "Manager")
                            {
                                Manager manager = new Manager(result[0]);
                                myStaff.Add(manager);
                            }
                            else if (result[1] == "Admin")
                            {
                                Admin admin = new Admin(result[0]);
                                myStaff.Add(admin);
                            }
                        }
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Could not find file, exiting...");
                return null;
            }

            // returns the List to the caller
            return myStaff;
        }
    }
}

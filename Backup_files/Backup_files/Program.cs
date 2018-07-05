using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backup_files
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = @"C:\Users\Sergei.Ermolaev\source\repos\Backup_files\List";
            List<string> files_name = Directory.GetFiles(file_path).ToList<string>();

            DateTime dateNow = DateTime.Today;

            Console.WriteLine(dateNow);
            foreach(string fn in files_name)
            {
                string name = Path.GetFileName(fn);
                if(name.LastIndexOf("ru-") != -1)
                {
                    int i = name.IndexOf("ru-") + 3;
                    Console.WriteLine();
                    string date = name.Substring(i, 8);
                    int year = Convert.ToInt16(date.Substring(0, 4));
                    int month =Convert.ToInt16( date.Substring(4, 2));
                    int day = Convert.ToInt16(date.Substring(6, 2));

                    DateTime dateFile = new DateTime(year, month, day);

                    TimeSpan dateDiff = dateNow.Subtract(dateFile);


                    //Console.WriteLine(year + month + day);
                    int days = Convert.ToInt16(dateDiff.Days);
                    Console.WriteLine(days.ToString());

                    if (days >3)
                    {
                        Console.WriteLine("Yes");
                    }
                }
                
            }
            Console.ReadKey();
        }
    }
}

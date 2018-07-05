using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backup_files
{
    class info_file
    {
        public string full_name { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }

        public info_file(string full_name, string name, DateTime date)
        {
            this.full_name = full_name;
            this.name = name;
            this.date = date;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = @"C:\Users\Sergei.Ermolaev\source\repos\Backup_files\List";
            List<string> files_name = Directory.GetFiles(file_path).ToList<string>();
            List<info_file> infoFile = new List<info_file>();

            DateTime dateNow = DateTime.Today;

            List<string> file_week = new List<string>();

            Console.WriteLine(dateNow);
            Console.WriteLine();

            for (int n = 0; n < files_name.Count; n++)
            {
                string nameFull = Path.GetFileName(files_name[n]);
                if (nameFull.LastIndexOf("ru-") != -1)
                {
                    int i = nameFull.IndexOf("ru-") + 3;
                    string date = nameFull.Substring(i, 8);
                    int year = Convert.ToInt16(date.Substring(0, 4));
                    int month = Convert.ToInt16(date.Substring(4, 2));
                    int day = Convert.ToInt16(date.Substring(6, 2));
                    DateTime dateFile = new DateTime(year, month, day);
                    string name = nameFull.Substring(0, (i-1));
                    infoFile.Add(new info_file(files_name[n], name, dateFile));
                }
            }
            List<info_file> sortFile = infoFile.OrderByDescending(d => d.date).ToList();
            foreach(var elem in sortFile)
            {
                Console.WriteLine();
                Console.WriteLine(elem.name.ToString());
                Console.WriteLine(elem.date.ToShortDateString());
            }

            //foreach(string fn in files_name)
            //{
            //    string name = Path.GetFileName(fn);
            //    if(name.LastIndexOf("ru-") != -1)
            //    {
            //        int i = name.IndexOf("ru-") + 3;
            //        Console.WriteLine();
            //        string date = name.Substring(i, 8);
            //        int year = Convert.ToInt16(date.Substring(0, 4));
            //        int month =Convert.ToInt16( date.Substring(4, 2));
            //        int day = Convert.ToInt16(date.Substring(6, 2));

            //        DateTime dateFile = new DateTime(year, month, day);

            //        TimeSpan dateDiff = dateNow.Subtract(dateFile);


            //        //Console.WriteLine(year + month + day);
            //        int days = Convert.ToInt16(dateDiff.Days);
            //        Console.WriteLine(days.ToString());



            //        if (days > 7)
            //        {
            //            Console.WriteLine("Yes " + fn);
            //            if(days > 14)
            //            {
            //                string name_cl = name.Substring(0, i-1);
                            
            //            }
            //        }
            //    }
                
            //}
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    class ReadFile
    {
        static readonly string rootFolder = @"C:\Temp\Data\";
        static readonly string textFile = @"E:\Rohit Folder\New Learning\0.C# DotNet Learning\SOLID & DesignPattern\DesignPatterns\Data.txt";
        public void ReadDataAndFindUnique()
        {
            try
            {
                if (File.Exists(textFile))
                {
                    List<int> data = new List<int>();
                    List<int> dup = new List<int>();
                    using (StreamReader str = new StreamReader(textFile))
                    {
                        string ln;

                        while ((ln = str.ReadLine()) != null)
                        {
                            //Console.WriteLine(ln);
                            data.Add(Convert.ToInt32(ln));
                        }
                    }



                    foreach (var item in data)
                    {
                        if (data.Count(x => x == item) > 1)
                        {
                            dup.Add(item);
                            Console.WriteLine(item);
                        }

                    }


                } // 12107
            }
            catch (Exception ex)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> lis = new List<Person>();
            Stopwatch w = new Stopwatch();
            w.Start();
            for (int i = 0; i < 1000; i++)
            {

                Person per = new Person
                {
                    Name = "Adi Works " + i.ToString(),
                    Position = "Same" + i.ToString(),
                    Office = "Dubai" + i.ToString(),
                    ChemCost = "44646 IT" + i.ToString(),
                    FMCCost = " Not implemented " + i.ToString(),
                    Phone = "46446" + i.ToString()
                };
                lis.Add( per);
            }
            foreach (var item in lis)
            { Console.WriteLine(item); }
            w.Stop();
            var time = w.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Seq time : " + time);
            w.Start();
            Parallel.For(0, 1000, i =>
            {
                Person per = new Person
                {
                    Name = "Adi Works " + i.ToString(),
                    Position = "Same" + i.ToString(),
                    Office = "Dubai" + i.ToString(),
                    ChemCost = "44646 IT" + i.ToString(),
                    FMCCost = " Not implemented " + i.ToString(),
                    Phone = "46446" + i.ToString()
                };
                lis.Add(per);
            });
            foreach (var item in lis)
            { Console.WriteLine(item); }

            w.Stop();
            time = w.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Par time : " + time);
        }
    }
    public class Person
    {
        // public int ID {get;set;}
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string ChemCost { get; set; }
        public string FMCCost { get; set; }
        public string Phone { get; set; }

    }
}

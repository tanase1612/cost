using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingADConection;

namespace TestSingleton
{
    class Program
    {
       
        static void Main(string[] args)
        {
            SingletonExample sg = SingletonExample.SeInstance;
            Console.WriteLine(sg.GetMessages().SingleOrDefault());
            Console.ReadKey();
            //Connection con = Connection.Instance;
            //Console.WriteLine(con.GetAllUsers().SingleOrDefault(c => c.Key == "TanaseA").Value.Name.ToString());
            //Console.ReadKey();

        }
    }
}

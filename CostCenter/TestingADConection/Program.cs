
using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingADConection
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Connection con = Connection.Instance;

            con.Run();
           
        }

    
    }

 
}


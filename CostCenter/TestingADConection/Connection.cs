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
    public class Connection
    {
       private Dictionary<string, Person> dic = new Dictionary<string, Person>();

        private static Connection instance;

        private Connection() { }

        public static Connection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connection();
                }
                return instance;
            }
        }
        public  Dictionary<string, Person> GetAllUsers()
        {
            return dic;
        }

        public void Run()
        {

            //Person per = new Person {Name ="Adi Works", Position="", Office = "", ChemCost = "", FMCCost ="", Phone ="" };
            string Name = "";
            string Position = "";
            string Office = "";
            string ChemCost = "";
            string FMCCost = "";
            string Phone = "";

            string location = "Ronland";
            string test = null;
            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
            string defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
            DirectoryEntry de = new DirectoryEntry("LDAP://" + defaultNamingContext);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(l=" + location + "))";

            ds.SearchScope = SearchScope.Subtree;
            SearchResultCollection rs = ds.FindAll();
               Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (SearchResult item in rs)
            {

                Name = item.GetDirectoryEntry().Properties["DisplayName"].Value.ToString();
                if (item.GetDirectoryEntry().Properties["Title"].Value != null)
                { Position = item.GetDirectoryEntry().Properties["Title"].Value.ToString(); }
                else { Position = "Not found"; }

                Office = item.GetDirectoryEntry().Properties["l"].Value.ToString();
                if (item.GetDirectoryEntry().Properties["Department"].Value != null)
                { ChemCost = item.GetDirectoryEntry().Properties["Department"].Value.ToString(); }
                else { ChemCost = "Not found"; }
                FMCCost = "NOT YET IMPLEMETED";
                if (item.GetDirectoryEntry().Properties["telephoneNumber"].Value != null)
                { Phone = item.GetDirectoryEntry().Properties["telephoneNumber"].Value.ToString(); }
                else { Phone = "Not found"; }
                Person per = new Person
                {
                    Name = Name,
                    Position = Position,
                    Office = Office,
                    ChemCost = ChemCost,
                    FMCCost = "NOT YET IMPLEMENTED",
                    Phone = Phone
                };
                dic.Add(item.GetDirectoryEntry().Properties["SamAccountName"].Value.ToString(), per);
                //  test = item.GetDirectoryEntry().Properties["SamAccountName"].Value.ToString();
            }
            watch.Stop();
            var time = watch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Waiting..." + "Time: " + time);
            //Console.WriteLine(dic.SingleOrDefault(c => c.Key == "TanaseA").Value.Name.ToString());
            Console.ReadKey();
        }
    }
}

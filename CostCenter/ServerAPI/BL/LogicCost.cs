using ServerAPI.DA;
using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace ServerAPI.BL
{
    public class LogicCost
    {
       private Singleton mgr;
       private DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
       private string defaultNamingContext;
       private DirectoryEntry de;
       private DirectorySearcher ds;

        private string KEY_SAM = "";
        private string NAME = "";
        private string POSITION = "";
        private string OFFICE = "";
        private string CHEM_COST = "";
        private string FMC_COST ="";
        private string PHONE = "";



        public LogicCost()
        {
            this.mgr = Singleton.SeInstance;
           
        }
        public void Run()
        {
           // ExecuteV1(Init());
           // ExecuteV2(Init());
            ExecuteV3();
        }
        private SearchResultCollection Init()
        {
            defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
            de = new DirectoryEntry("LDAP://" + defaultNamingContext);
            ds = new DirectorySearcher(de);
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(l=Ronland))";

            ds.SearchScope = SearchScope.Subtree;
            SearchResultCollection rs = ds.FindAll();

            return rs;

        }
        private void ExecuteV1(SearchResultCollection rs)
        {
         
          
            foreach (SearchResult item in rs)
            {

                NAME = item.GetDirectoryEntry().Properties["DisplayName"].Value.ToString();
                if (item.GetDirectoryEntry().Properties["Title"].Value != null)
                { POSITION = item.GetDirectoryEntry().Properties["Title"].Value.ToString(); }
                else { POSITION = "Not found"; }

                OFFICE = item.GetDirectoryEntry().Properties["l"].Value.ToString();
                if (item.GetDirectoryEntry().Properties["Department"].Value != null)
                { CHEM_COST = item.GetDirectoryEntry().Properties["Department"].Value.ToString(); }
                else { CHEM_COST = "Not found"; }
                FMC_COST = "NOT YET IMPLEMETED";
                if (item.GetDirectoryEntry().Properties["telephoneNumber"].Value != null)
                { PHONE = item.GetDirectoryEntry().Properties["telephoneNumber"].Value.ToString(); }
                else { PHONE = "Not found"; }
                Person per = new Person
                {
                    Name = NAME,
                    Position = POSITION,
                    Office = OFFICE,
                    ChemCost = CHEM_COST,
                    FMCCost = "NOT YET IMPLEMENTED",
                    Phone = PHONE
                };
                mgr.AddUser(item.GetDirectoryEntry().Properties["SamAccountName"].Value.ToString(), per);
                //  test = item.GetDirectoryEntry().Properties["SamAccountName"].Value.ToString();
            }
            
            //Console.WriteLine(dic.SingleOrDefault(c => c.Key == "TanaseA").Value.Name.ToString());       
        }

        public void ExecuteV2(SearchResultCollection rs)
        {
            string[] requiredProperties = new string[] 
            { "SamAccountName", "DisplayName", "Title",
                "l", "Department", "telephoneNumber" };
            ds.PropertiesToLoad.AddRange(requiredProperties);
            List<SearchResult> resultList = rs.Cast<SearchResult>().ToList();
            List<string> myList = new List<string>();
            foreach (SearchResult item in resultList)
            {
                foreach (PropertyValueCollection values in item.Properties)
                {
                    if (values.Value == null)
                    { values.Value = "Not found"; }
                    else
                {
                        if (values.PropertyName == "SamAccountName")
                        {
                            KEY_SAM = values.Value.ToString();
                        }
                        else
                        { myList.Add(values.Value.ToString()); }
                    }
                }         
                mgr.AddUsers(KEY_SAM, myList);
            }
        }

        public void ExecuteV3()
        {
            Repository repo = new Repository();
            for (int i = 0; i < 3000; i++)
            {
             
             UserAD per = new UserAD { KEY_SAM ="key" + i.ToString(),Name = "Adi Works " + i.ToString(),
                 Position = "Same"+ i.ToString(),
                 Office = "Dubai" + i.ToString(),
                 ChemCost = "44646 IT" + i.ToString(),
                 FMCCost = " Not implemented " + i.ToString(),
                 Phone = "46446" + i.ToString() };
                //mgr.AddUser(i.ToString(), per);
                // repo.AdUser(per);
                mgr.addUsers(per);
            }
           
        }

    }
}
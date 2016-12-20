using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace ClientChemInfo.Models
{
    public class ExcelReader
    {

        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        List<Person> firstCol = new List<Person>();
        List<string> secCol = new List<string>();

        public List<Person> RetrieveRecordes( string path)
        {

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;



                var sb = new StringBuilder(); //this is your your data
                for (int rowNum = 2; rowNum < totalRows + 1; rowNum++) //selet starting row here
                {
                    Person per = new Person {Name = myWorksheet.GetValue(rowNum, 1).ToString(),ChemCost = "NOT FOUND"};
                    //var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    // result = sb.AppendLine(string.Join(",", row)).ToString();   
                    firstCol.Add(per);
                    //secCol.Add(myWorksheet.GetValue(rowNum, 2).ToString());

                }
               // dic.Add(myWorksheet.GetValue(1, 1).ToString(), firstCol);
               // dic.Add(myWorksheet.GetValue(1, 2).ToString(), secCol);              
            }
            return firstCol;
        }
    }
}
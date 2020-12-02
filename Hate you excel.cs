using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace L2
{
    public class Hate_you_excel
    { 
        public static List<UBI> ubi = new List<UBI>();     
        public Hate_you_excel(string filepath)
        {


            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open($@"{filepath}");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;


            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //xlRange.Cells[i, j].Value2.ToString()

            for (int i = 3; i <= rowCount; i++)
            { 

                    string ind = "";
                    string name = "";
                    string des="";
                    string sourse="";
                    string obj = "";
                    string bre ="";
                    string inte = "";
                    string acc="";

                for (int j = 1; j <= colCount; j++)
                {

                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {

                        if (j == 1) ind = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 2) name = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 3) des = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 4) sourse = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 5) obj = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 6) bre = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 7) inte = xlRange.Cells[i, j].Value2.ToString();
                        if (j == 8) acc = xlRange.Cells[i, j].Value2.ToString();
                    }

                }

                ubi.Add(new UBI(ind,name,des,sourse,obj,bre,inte,acc));

            }
        }

        public List<UBI> list()
        {
            return ubi;
        }
    }
}

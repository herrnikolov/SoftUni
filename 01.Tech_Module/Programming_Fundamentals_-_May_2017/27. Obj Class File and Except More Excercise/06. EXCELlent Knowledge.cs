using System;
using Microsoft.Office.Interop.Excel;

namespace _06.EXCELlent_Knowledge
{
    class Program
    {
        static void Main()
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\Softuni\0.2 Tech Module - May 2017\Projects\10.ObjectsClassesFilesAndExceptiosMoreExers
                                                        \06. EXCELlent Knowledge\sample_table.xlsx");
            Worksheet xlWorksheet = xlWorksheets.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (j == 1 && i != 1)
                    {
                        Console.WriteLine();
                    }

                    Console.Write(xlRange.Cells[i, j].Value + "|");
                }
            }
        }
    }
}
// Output to paste in judge.softuni.bg

//ZIP|Sales|Name|Year|Value|
//2121|456|Jane|2011|84219|
//2092|789|Ashish|2012|28322|
//2128|456|Jane|2013|81878|
//2073|123|John|2011|44491|
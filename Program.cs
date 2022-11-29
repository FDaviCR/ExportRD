using ClosedXML.Excel;
using System;
using System.IO;

namespace Alfa
{
    internal class Program
    {
        static void GenerateData() { 
        
        }
        static void GenerateHeader(IXLWorksheet worksheet) {
            worksheet.Cell("A1").Value = "Teste";
        }
        static void GenerateFile(string tabName, string fileName){
            string filePathName = "C:\temp\\" + fileName;
            if (File.Exists(filePathName)){ 
                File.Delete(filePathName);
            }

            using (var workbook = new XLWorkbook()) {
                var planilha = workbook.Worksheets.Add(tabName);

                int line = 1;
                GenerateHeader(planilha);
                line++;

                foreach (var item in lista) { 
                    planilha.Cell("A" + line).Value = item.Value;
                    line++;
                }
                workbook.SaveAs(filePathName);
            }

        }
        static void Main(string[] args){
            Console.WriteLine("Hello World!");
            //var data = GenerateData();

        }
    }
}

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Alfa.Model;

namespace Alfa
{
    internal class Program
    {
        static void GenerateHeader(IXLWorksheet worksheet) {
            worksheet.Cell("A1").Value = "CodigoCliente";
            worksheet.Cell("B1").Value = "Empresa";
            worksheet.Cell("C1").Value = "Segmento";
            worksheet.Cell("D1").Value = "URL";
            worksheet.Cell("E1").Value = "Resumo";
            worksheet.Cell("F1").Value = "Contato";
            worksheet.Cell("G1").Value = "Cargo";
            worksheet.Cell("H1").Value = "Telefone";
            worksheet.Cell("I1").Value = "Email1";
            worksheet.Cell("J1").Value = "Email2";
        }
        
        static void GenerateFile(string tabName, string fileName, List<Organizations> lista){
            string filePathName = @"C:\temp\" + fileName;
            if (File.Exists(filePathName)){ 
                File.Delete(filePathName);
            }

            using (var workbook = new XLWorkbook()) {
                var planilha = workbook.Worksheets.Add(tabName);

                int line = 1;
                GenerateHeader(planilha);
                line++;

                foreach (var item in lista) {
                    planilha.Cell("A" + line).Value = item.id;
                    planilha.Cell("B" + line).Value = item.name;
                    planilha.Cell("C" + line).Value = item.organization_segments[0].name;
                    planilha.Cell("D" + line).Value = item.url;
                    planilha.Cell("E" + line).Value = item.resume;
                    planilha.Cell("F" + line).Value = item.contacts[0].name;
                    planilha.Cell("G" + line).Value = item.contacts[0].title;
                    planilha.Cell("H" + line).Value = item.contacts[0].phones[0].phone;
                    planilha.Cell("I" + line).Value = item.contacts[0].emails[0].email;
                    planilha.Cell("J" + line).Value = item.contacts[0].emails[1].email;
                    line++;
                }
                workbook.SaveAs(filePathName);
            }

        }
        
        static void Main(string[] args){
            var requisicaoWeb = WebRequest.CreateHttp("https://crm.rdstation.com/api/v1/organizations?token=6385070f27aa4800158aa020&page=Page");
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                var post = JsonConvert.DeserializeObject<Data>(objResponse.ToString());

                var data = post.organizations;
                GenerateFile("teste", "teste.xlsx", data);

                streamDados.Close();
                resposta.Close();
            }


            Console.WriteLine("Arquivo gerado!");
        }
    }
}

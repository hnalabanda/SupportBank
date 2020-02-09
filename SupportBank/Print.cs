using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using NLog;
namespace SupportBank
{
    public class Print
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public void PrintReport(Bank bank)
        {
            Console.WriteLine(@"Type All to output the names of each person, and the total amount they owe, or are owed.");
            Console.WriteLine(@"Type [Account Name] to print a list of every transaction, with the date and narrative, for that account with that name.");
            var readCommand=Strings.Trim(Console.ReadLine());
            PdfPTable table;
            table = readCommand == "All" ? PrintAll(bank) : PrintAccount(readCommand,bank);
          
            var fileContents= GeneratePDF(table);
            File.WriteAllBytes(@"C:\Training\testreport.pdf", fileContents);
       
        }

        private PdfPTable PrintAll(Bank bank)
        {
            Logger.Info("Print report");
           
           PdfPTable table=new PdfPTable(3);
           table.AddCell("Name");
           table.AddCell("Are Owed");
           table.AddCell("They Owe");

           foreach (Account acc in bank.bankAccounts)
           {
               table.AddCell(acc.owner);
               table.AddCell(Math.Round(acc.amtAreOwed,2).ToString());
               table.AddCell(Math.Round(acc.amtTheyOwe,2).ToString());
           }

           return table;

        }

        private PdfPTable PrintAccount(string command,Bank bank)
        {
            var account = bank.GetAccount(command);
            PdfPTable table=new PdfPTable(5);
            table.AddCell("Date");
            table.AddCell("From");
            table.AddCell("To");
            table.AddCell("Narrative");
            table.AddCell("Amount");
            
         
            foreach (Transaction  transaction in account.transactions)
            {
               
                table.AddCell(transaction.Date.ToString());
                table.AddCell(transaction.fromAccount);
                table.AddCell(transaction.toAccount);
                table.AddCell(transaction.narrative);
                table.AddCell(transaction.amount.ToString());
            }  
            return table;
 
        }
        private byte[] GeneratePDF(PdfPTable table)
        {
            var memoryStream = new System.IO.MemoryStream();
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            Paragraph para = new Paragraph("Support Bank Report ");
            document.Add(para);
                
              
            document.Add(table);

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            return bytes;
        }
        
        
    }
}
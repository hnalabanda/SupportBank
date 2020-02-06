using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
         
            
            var reader = new TransactionReader();
            List<Transaction> transactions = reader.GetTransactionsFromFile();
            
            var bank=new Bank("Softwire Support Bank");
            bank.ProcessTransactions(transactions);
            // int lineCounter = 1;
      
            
            //Print Report
            
            Print print=new Print();
            print.PrintReport(readCommand,bank);
        }
    }
}
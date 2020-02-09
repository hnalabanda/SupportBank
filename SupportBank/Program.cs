using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using NLog.Config;
using NLog.Targets;
using NLog.Attributes;
using NLog;
namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget
                {FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}"};
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            try
            {
                var reader = new TransactionReader();
                List<Transaction> transactions = reader.GetTransactionsFromFile();
                
                var bank = new Bank("Softwire Support Bank");
                bank.ProcessTransactions(transactions);
                
                //Print Report
                Print print = new Print();
                print.PrintReport(bank);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured{e.Message}, please check logs");
            }

        }
    }
}
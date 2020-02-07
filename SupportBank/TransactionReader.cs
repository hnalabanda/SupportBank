using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
namespace SupportBank
{
    public class TransactionReader
    {
        private List<Transaction> transactions;

        public TransactionReader()
        {
            this.transactions=new List<Transaction>();
        }

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        
        public List<Transaction> GetTransactionsFromFile()
        {
            Logger.Info("Reading transactions");
            
          //  var inputFile=new FileImporter();
          // inputFile.GetImportFile();
            
            var inputFile = Console.ReadLine();
            var lines = File.ReadAllLines(inputFile).Skip(1);
            
            var lineCounter = 0;
            try
            {
                foreach (string line in lines)
                {
                    var values = line.Split(",");
                    lineCounter += 1;
                        var newTransaction = new Transaction
                        {
                            transactionDate = Convert.ToDateTime(values[0]),
                            fromIndividual = values[1],
                            toIndividual = values[2],
                            narrative = values[3],
                            amount = Convert.ToDouble(values[4])
                        };
                        transactions.Add(newTransaction);
                }
            }
            catch(System.FormatException exception)
            {
                Logger.Error($"An error occured on line {lineCounter-1}: {exception.Message}");
                throw exception;
            }

            return transactions;
        }
            
    }
}
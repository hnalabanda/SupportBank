using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace SupportBank
{

    public class TransactionReader
    {
        private string inputFile { get; set; }
        private List<Transaction> transactions;

        public TransactionReader()
        {
            this.transactions = new List<Transaction>();
        }

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private string GetImportFile()
        {
            inputFile = Console.ReadLine();
           //inputFile = @"C:\CV\TechSwitch\SupportBank\filejson.json";
            var fileInfo = new FileInfo(inputFile);
            return fileInfo.Extension;

        }

        public List<Transaction> GetTransactionsFromFile()
        {
            Logger.Info("Get file path from user");
            var fileExtension = GetImportFile();
            List<Transaction> transactionList = null;
            switch (fileExtension)
            {
                case ".csv":
                    transactionList=ReadTransactionsFromCSVFile(inputFile);
                    break;
                case ".xml":
                    transactionList=ReadTransactionsFromXMLFile(inputFile);
                    break;
                case ".json":
                    transactionList=ReadTransactionsFromJSONFile(inputFile);
                    break;
                default:
                    Logger.Error($"File type of {fileExtension} is not supported by this program");
                    Console.WriteLine($"File type {fileExtension} is not supported by this program");
                    break;

            }

            return transactionList;
        }

        private List<Transaction> ReadTransactionsFromCSVFile(string fileName)
        {
                Logger.Info("Reading transactions from CSV file");

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
                            Date = Convert.ToDateTime(values[0]),
                            fromAccount = values[1],
                            toAccount = values[2],
                            narrative = values[3],
                            amount = Convert.ToDouble(values[4])
                        };
                        transactions.Add(newTransaction);
                    }
                }
                catch (System.FormatException exception)
                {
                    Logger.Error($"An error occured on line {lineCounter - 1}: {exception.Message}");
                    throw exception;
                }

                return transactions;
        }

        


        private List<Transaction> ReadTransactionsFromXMLFile(string fileName)
        {    Logger.Info("Reading transactions from XML file");
          
            return transactions;
        }

        private List<Transaction> ReadTransactionsFromJSONFile(string fileName)
        {    Logger.Info("Reading transactions from JSON file");


           
            var lines = JsonConvert.DeserializeObject<List<Transaction>>( File.ReadAllText(inputFile));

            var lineCounter = 0;
            try
            {
                foreach (var line in lines)
                {

                    transactions.Add(line);

                }
            }
            catch (System.FormatException exception)
            {
                Logger.Error($"An error occured on line {lineCounter - 1}: {exception.Message}");
                throw exception;
            }

            return transactions;
        }
            
        
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SupportBank
{
    public class TransactionReader
    {
        private List<Transaction> transactions;

        public TransactionReader()
        {
            this.transactions=new List<Transaction>();
        }

        public List<Transaction> GetTransactionsFromFile()
        {
            var lines = File.ReadAllLines(@"C:\Training\file.csv").Skip(1);
            foreach (string line in lines)
            {
                var values = line.Split(",");
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

            return transactions;
        }
            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
namespace SupportBank
{
    public class Print
    {
        public void PrintReport(Bank bank)
        {
            Console.WriteLine(@"Type All to output the names of each person, and the total amount they owe, or are owed.");
            Console.WriteLine(@"Type [Account Name] to print a list of every transaction, with the date and narrative, for that account with that name.");
            var readCommand=Strings.Trim(Console.ReadLine());
            
            if (readCommand == "All")
            {
                PrintAll(bank);
            }
            else
            {
                PrintAccount(readCommand,bank);
 
            }
            
         
            
        }

        private void PrintAll(Bank bank)
        {
            Console.Write("Name");
            Console.Write("      ");
            Console.Write("Are Owed");
            Console.Write("      ");
            Console.WriteLine("They Owe");
            Console.WriteLine("=============================================================");
            foreach (Account acc in bank.bankAccounts)
            {
                Console.Write(acc.owner);
                Console.Write("      ");
                Console.Write(acc.amtAreOwed);
                Console.Write("      ");
                Console.WriteLine(acc.amtTheyOwe);
            }
        }

        private void PrintAccount(string command,Bank bank)
        {
            var account = bank.GetAccount(command);
            Console.Write("Date");
            Console.Write("      ");
            Console.Write("From");
            Console.Write("      ");
            Console.WriteLine("To");
            Console.Write("      ");
            Console.WriteLine("Narrative");
            Console.Write("      ");
            Console.WriteLine("Amount");                   
            Console.WriteLine("=============================================================");
            foreach (Transaction  transaction in account.transactions)
            {
                Console.Write(transaction.transactionDate);
                Console.Write("      ");
                Console.Write(transaction.fromIndividual);
                Console.Write("      ");
                Console.WriteLine(transaction.toIndividual);
                Console.Write("      ");
                Console.WriteLine(transaction.narrative);
                Console.Write("      ");
                Console.WriteLine(transaction.amount);        
            }           
        }
    }
}
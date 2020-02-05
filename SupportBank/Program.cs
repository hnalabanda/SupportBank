using System;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
        
           
            var lines = File.ReadAllLines(@"C:\Training\file.csv");
            foreach (string line in lines)
            {
                var values = line.Split(",");
              


                var newTransaction = new Transaction
                {
                    TransactionDate = Convert.ToDateTime(values[0]),
                    FromName = values[1],
                    ToName = values[2],
                    FromNameAmount = Convert.ToDouble(values[3])
                };
                
                var newPerson= new Person();
                newPerson.Name = values[2];
                
                var bankAccount=new Account();
                bankAccount.
                
            }
                
            
        }
    }
}
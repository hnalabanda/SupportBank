using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    public class Bank
    {
        private string name;
        public List<Account> bankAccounts;

        public Bank()
        {
            this.bankAccounts=new List<Account>();
        }

        public Bank(string bankname)
        {
            this.name=bankname;
            this.bankAccounts=new List<Account>();
        }
        public void CreateAccount(string ind)
        {
            Account account=new Account();
            account.owner = ind;
            bankAccounts.Add(account);
        }
        public Account GetAccount(string ind)
        {
            Account account = bankAccounts.Find(x => x.owner == ind);
            return account;
        }
        public void TransferFunds(Transaction transaction)
        {
            Account fromAccount = GetAccount(transaction.fromIndividual);
            Account toAccount = GetAccount(transaction.toIndividual);
            fromAccount.amtAreOwed += transaction.amount;
            toAccount.amtTheyOwe += transaction.amount;
            fromAccount.AddTransaction(transaction);
            toAccount.AddTransaction(transaction);
        }

        public void ProcessTransactions(List<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
           
                var fromPerson=transaction.fromIndividual;

                if (GetAccount(fromPerson)==null)
                {
                    // bank.GetOrCreateAccount(person)
                    CreateAccount(fromPerson);
                }

                    
                var toPerson=   transaction.toIndividual;
               
                if (GetAccount(toPerson)==null)
                {
                    CreateAccount(toPerson);
                }
                        
   
                TransferFunds(transaction);
     
            }
        }
    }
}
using System.Net.Mime;
using System.Collections.Generic;

namespace SupportBank
{
    public class Account
    {
        public string owner;
        // public string name;
        public double amtTheyOwe;
        public double amtAreOwed;
        public List<Transaction> transactions;

        public Account()
        {
            this.amtAreOwed = 0;
            this.amtTheyOwe = 0;
            this.transactions=new List<Transaction>();
          
        }

        public void AddTransaction(Transaction trans)
        {
            this.transactions.Add(trans);
        }
        public void Transfer(Transaction trans)
        {
            //transactions.add
            //update amounts
        }
    }
}
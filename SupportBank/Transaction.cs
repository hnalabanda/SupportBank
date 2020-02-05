using System;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public double FromNameAmount { get; set; }
    }
}
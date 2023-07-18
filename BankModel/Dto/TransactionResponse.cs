using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Dto
{
    public class TransactionResponse
    {
        private string accountName;
        private string accountType;
        private double transactionAmount;
        private double accountBalance;
        private string note;

        public TransactionResponse()
        {
        }

        public TransactionResponse(string accountName, string accountType, double transactionAmount, 
            double accountBalance, string note)
        {
            this.AccountName = accountName;
            this.AccountType = accountType;
            this.TransactionAmount = transactionAmount;
            this.AccountBalance = accountBalance;
            this.Note = note;
        }

        public string AccountName { get => accountName; set => accountName = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public double TransactionAmount { get => transactionAmount; set => transactionAmount = value; }
        public double AccountBalance { get => accountBalance; set => accountBalance = value; }
        public string Note { get => note; set => note = value; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Account Name: {accountName}, " +
                $"Account Type: {accountType}, " +
                $"Transaction Amount: {transactionAmount}, " +
                $"Account Balance: {accountBalance}, " +
                $"Note: {note}";
        }
    }
}

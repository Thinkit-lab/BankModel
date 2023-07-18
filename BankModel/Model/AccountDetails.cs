using BankModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Model
{
    public class AccountDetails
    {
        public AccountDetails()
        {
        }

        public AccountDetails(int accountId, string accountNumber, AccountType accountType, 
            double accountBalance, User owner)
        {
            this.AccountId = accountId;
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.AccountBalance = accountBalance;
            this.Owner = owner;
        }

        private int accountId;
        private string accountNumber;
        private AccountType accountType;
        private double accountBalance;
        private User owner;

        public int AccountId { get => accountId; set => accountId = value; }
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public AccountType AccountType { get => accountType; set => accountType = value; }
        public double AccountBalance { get => accountBalance; set => accountBalance = value; }
        public User Owner { get => owner; set => owner = value; }

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
            return $"Account ID: {accountId}\n" +
                   $"Account Number: {accountNumber}\n" +
                   $"Account Type: {accountType}\n" +
                   $"Account Balance: {accountBalance}\n" +
                   $"Owner: {owner}\n";
        }
    }
}

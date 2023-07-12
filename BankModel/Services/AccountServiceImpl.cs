using BankModel.Dto;
using BankModel.Enums;
using BankModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Services
{
    class AccountServiceImpl : AccountService
    {
        private const double minimumSavingsBalance = 1000;
        public TransactionResponse Deposit(AccountDetails accountDetails, double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount cannot be zero or less");
            }

            accountDetails.AccountBalance += amount;

            TransactionResponse response = new TransactionResponse();
            response.AccountBalance = accountDetails.AccountBalance;
            response.AccountName = accountDetails.Owner.FullName;
            response.TransactionAmount = amount;
            response.AccountType = accountDetails.AccountType.ToString();
            response.Note = $"Deposit of {amount} succesful";

            return response;
        }

        public TransferResponse Transfer(AccountDetails sender, AccountDetails receiver, double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Transfer amount canot be zero or less");
            }

            if (sender.AccountType.Equals(AccountType.Savings) && sender.AccountBalance <= minimumSavingsBalance)
            {
                throw new InvalidOperationException($"Transfer fail! Sender balance is less than {minimumSavingsBalance}");
            }

            if (sender.AccountBalance < amount)
            {
                throw new InvalidOperationException("Sender account balance is less than transfer amount");
            } else
            {
                sender.AccountBalance -= amount;
                receiver.AccountBalance += amount;
            }

            TransferResponse response = new TransferResponse();
            response.SenderBalance = sender.AccountBalance;
            response.ReceiverBalance = receiver.AccountBalance;
            response.Amount = amount;
            response.SenderAccountNumber = sender.AccountNumber;
            response.ReceiverAccountNumber = receiver.AccountNumber;

            return response;
        }

        public TransactionResponse Withdraw(AccountDetails accountDetails, double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Withdrawal amount cannot be zero or less");
            }

            if (accountDetails.AccountType.Equals(AccountType.Savings) && accountDetails.AccountBalance <= minimumSavingsBalance)
            {
                throw new InvalidOperationException($"Withdrawal fail! Balance is less than {minimumSavingsBalance}");
            }

            if (accountDetails.AccountBalance < amount)
            {
                throw new InvalidOperationException("Withdrawal fail! Balance is less than withdrawal amount");
            } else
            {
                accountDetails.AccountBalance -= amount;
            }

            TransactionResponse response = new TransactionResponse();
            response.AccountBalance = accountDetails.AccountBalance;
            response.AccountName = accountDetails.Owner.FullName;
            response.TransactionAmount = amount;
            response.AccountType = accountDetails.AccountType.ToString();
            response.Note = $"Withdrawal of {amount} succesful";

            return response;
        }
    }
}

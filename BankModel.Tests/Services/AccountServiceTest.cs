using BankModel.Dto;
using BankModel.Enums;
using BankModel.Model;
using BankModel.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Tests.Services
{
    public class AccountServiceTest
    {
        private readonly AccountServiceImpl accountService;

        public AccountServiceTest()
        {
            accountService = new AccountServiceImpl();
        }

        [Fact]
        public void Deposit_ReturnsTransactionResponse_IfSuccessful()
        {
            double amount = 1000;
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.AccountBalance = 0;
            accountDetails.AccountNumber = "123456789";
            accountDetails.AccountId = 1;
            accountDetails.AccountType = AccountType.Savings;
            accountDetails.Owner = new User();
            accountDetails.Owner.FullName = "Test";

            TransactionResponse response = new TransactionResponse();
            response.AccountBalance = 1000;
            response.AccountName = accountDetails.Owner.FullName;
            response.TransactionAmount = amount;
            response.AccountType = AccountType.Savings.ToString();
            response.Note = $"Deposit of {amount} succesful";

            TransactionResponse result = accountService.Deposit(accountDetails, amount);
            
            result.Should().NotBeNull();
            result.TransactionAmount.Should().Be(response.TransactionAmount);
            result.Note.Should().Be(response.Note);

        }

        [Fact]
        public void Deposit_ThrowsInvalidOperation_IfAmount_IsLessThanOrEquals_Zero()
        {
            double amount = 0;
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.AccountBalance = 0;
            accountDetails.AccountNumber = "123456789";
            accountDetails.AccountId = 1;
            accountDetails.AccountType = AccountType.Savings;
            accountDetails.Owner = new User();
            accountDetails.Owner.FullName = "Test";

            TransactionResponse response = new TransactionResponse();
            response.AccountBalance = 1000;
            response.AccountName = accountDetails.Owner.FullName;
            response.TransactionAmount = amount;
            response.AccountType = AccountType.Savings.ToString();
            response.Note = $"Deposit of {amount} succesful";

            Action depositAction = () => accountService.Deposit(accountDetails, amount);

            depositAction.Should().Throw<InvalidOperationException>()
                .WithMessage("Amount cannot be zero or less");

        }

        [Fact]
        public void Transfer_ReturnsTransferResponse_IfSuccessful()
        {
            double amount = 1000;
            AccountDetails sender = new AccountDetails();
            sender.AccountBalance = 2000;
            sender.AccountNumber = "123456789";
            sender.AccountId = 1;
            sender.AccountType = AccountType.Savings;
            sender.Owner = new User();
            sender.Owner.FullName = "Sender";

            AccountDetails receiver = new AccountDetails();
            receiver.AccountBalance = 0;
            receiver.AccountNumber = "123472189";
            receiver.AccountId = 2;
            receiver.AccountType = AccountType.Savings;
            receiver.Owner = new User();
            receiver.Owner.FullName = "Receiver";

            TransferResponse response = new TransferResponse();
            response.SenderBalance = sender.AccountBalance;
            response.ReceiverBalance = receiver.AccountBalance + amount;
            response.Amount = amount;
            response.SenderAccountNumber = sender.AccountNumber;
            response.ReceiverAccountNumber = receiver.AccountNumber;

            TransferResponse result = accountService.Transfer(sender, receiver, amount);

            result.Should().NotBeNull();
            result.ReceiverBalance.Should().Be(response.ReceiverBalance);

        }

        [Fact]
        public void Transfer_ThrowsInvalidOperation_IfSenderBalance_IsLessThan_Amount()
        {
            double amount = 1000;
            AccountDetails sender = new AccountDetails();
            sender.AccountBalance = 500;
            sender.AccountNumber = "123456789";
            sender.AccountId = 1;
            sender.AccountType = AccountType.Savings;
            sender.Owner = new User();
            sender.Owner.FullName = "Sender";

            AccountDetails receiver = new AccountDetails();
            receiver.AccountBalance = 0;
            receiver.AccountNumber = "123472189";
            receiver.AccountId = 2;
            receiver.AccountType = AccountType.Savings;
            receiver.Owner = new User();
            receiver.Owner.FullName = "Receiver";

            Action result = () => accountService.Transfer(sender, receiver, amount);

            result.Should().Throw<InvalidOperationException>("Sender account balance is less than transfer amount");

        }

        [Fact]
        public void Withdraw_ReturnsTransactionResponse_IfSuccessful()
        {
            double amount = 1000;
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.AccountBalance = 2000;
            accountDetails.AccountNumber = "123456789";
            accountDetails.AccountId = 1;
            accountDetails.AccountType = AccountType.Savings;
            accountDetails.Owner = new User();
            accountDetails.Owner.FullName = "Test";

            TransactionResponse response = new TransactionResponse();
            response.AccountBalance = accountDetails.AccountBalance - amount;
            response.AccountName = accountDetails.Owner.FullName;
            response.TransactionAmount = amount;
            response.AccountType = AccountType.Savings.ToString();
            response.Note = $"Withdrawal of {amount} succesful";

            TransactionResponse result = accountService.Withdraw(accountDetails, amount);

            result.Should().NotBeNull();
            result.AccountBalance.Should().Be(response.AccountBalance);
            result.Note.Should().Be(response.Note);

        }
    }
}

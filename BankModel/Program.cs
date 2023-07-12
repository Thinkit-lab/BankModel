using BankModel.Model;
using BankModel.Services;
using BankModel.Utils;
using System;

namespace BankModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // User Objaects
           User user1 = new User();
           user1.UserId = 1;
            user1.FullName = "1lukunle Afolabi";
            user1.Age = 30;
            user1.Email = "afo@gmail.com";
            user1.AccountDetails = new AccountDetailsList<AccountDetails>();

            User user2 = new User();
            user2.UserId = 2;
            user2.FullName = "Atake Joshua";
            user2.Age = 25;
            user2.Email = "atake@gmail.com";
            user2.AccountDetails = new AccountDetailsList<AccountDetails>();

            //AccountDetails Objects
            AccountDetails accountDetails1 = new AccountDetails();
            accountDetails1.AccountId = 1;
            accountDetails1.AccountNumber = "123456789";
            accountDetails1.AccountBalance = 0;
            accountDetails1.AccountType = Enums.AccountType.Savings;
            accountDetails1.Owner = user1;

            AccountDetails accountDetails2 = new AccountDetails();
            accountDetails2.AccountId = 2;
            accountDetails2.AccountNumber = "987654321";
            accountDetails2.AccountBalance = 0;
            accountDetails2.AccountType = Enums.AccountType.Savings;
            accountDetails2.Owner = user1;

            AccountDetails accountDetails3 = new AccountDetails();
            accountDetails3.AccountId = 3;
            accountDetails3.AccountNumber = "234158769";
            accountDetails3.AccountBalance = 0;
            accountDetails3.AccountType = Enums.AccountType.Current;
            accountDetails3.Owner = user1;

            AccountDetails accountDetails4 = new AccountDetails();
            accountDetails4.AccountId = 4;
            accountDetails4.AccountNumber = "873456234";
            accountDetails4.AccountBalance = 0;
            accountDetails4.AccountType = Enums.AccountType.Current;
            accountDetails4.Owner = user2;

            AccountDetails accountDetails5 = new AccountDetails();
            accountDetails5.AccountId = 5;
            accountDetails5.AccountNumber = "8453613425";
            accountDetails5.AccountBalance = 0;
            accountDetails5.AccountType = Enums.AccountType.Savings;
            accountDetails5.Owner = user2;

            user1.AccountDetails.Add(user1.AccountDetails, accountDetails1);
            user1.AccountDetails.Add(user1.AccountDetails, accountDetails2);
            user1.AccountDetails.Add(user1.AccountDetails, accountDetails3);
            user2.AccountDetails.Add(user2.AccountDetails, accountDetails4);
            user2.AccountDetails.Add(user2.AccountDetails, accountDetails5);

            Console.WriteLine(user1);
            Console.WriteLine(user2);
            
            AccountServiceImpl accountService = new AccountServiceImpl();
            Console.WriteLine(accountService.Deposit(accountDetails1, 2000));
            Console.WriteLine(accountService.Deposit(accountDetails3, 500));
           // Console.WriteLine(accountService.Withdraw(accountDetails1, 1000));
            Console.WriteLine(accountService.Withdraw(accountDetails3, 500));
            Console.WriteLine(accountService.Transfer(accountDetails1, accountDetails4, 500));
            Console.WriteLine(accountDetails4);


        }
    }
}
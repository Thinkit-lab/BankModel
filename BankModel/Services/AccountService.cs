using BankModel.Dto;
using BankModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Services
{
    interface AccountService
    {
        TransactionResponse Deposit(AccountDetails accountDetails, double amount);
        TransactionResponse Withdraw(AccountDetails accountDetails, double amount);
        TransferResponse Transfer(AccountDetails sender, AccountDetails receiver, double amount);
    }
}

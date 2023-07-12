using BankModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Utils
{
    public class AccountDetailsList<T> : List<AccountDetails>
    {
        public new void Add(AccountDetailsList<AccountDetails> accountDetails, AccountDetails item) 
        {
            int accountTypeCount = 0;
            if (accountDetails.Count > 0)
            {
                for (int i = 0; i < accountDetails.Count; i++)
                {
                    if (accountDetails[i].AccountType.Equals(item.AccountType))
                    {
                        accountTypeCount++;
                    }
                }
                if (accountTypeCount < 1)
                {
                    base.Add(item);
                }
            } else { base.Add(item); }
            
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}

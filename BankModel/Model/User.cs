using BankModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Model
{
    public class User
    {
        public User()
        {
        }

        public User(int userId, string fullName, string email, int age, AccountDetailsList<AccountDetails> accountDetails)
        {
            this.UserId = userId;
            this.FullName = fullName;
            this.Email = email;
            this.Age = age;
            this.AccountDetails = accountDetails;
        }

        private int userId;
        private string fullName;
        private string email;
        private int age;
        private AccountDetailsList<AccountDetails> accountDetails;

        public int UserId { get => userId; set => userId = value; }
        public string FullName { 
            get => fullName; 
            set  
                {
                char[] nameArr = value.ToCharArray();

                if (char.IsLetter(nameArr[0]))
                {
                    fullName = value;
                } else
                {
                    fullName = "User";
                }

            }
                
        }
        public string Email { get => email; set => email = value; }
        public int Age { get => age; set => age = value; }
        internal AccountDetailsList<AccountDetails> AccountDetails { 
            get => accountDetails; 
            set => accountDetails = value;
        }

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
            return $"User ID: {userId}\n" +
                   $"Full Name: {fullName}\n" +
                   $"Email: {email}\n" +
                   $"Age: {age}\n" +
                   $"Account Details: {accountDetails}\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Dto
{
    class TransferResponse
    {
        private string receiverAccountNumber;
        private string senderAccountNumber;
        private double amount;
        private double senderBalance;
        private double receiverBalance;

        public TransferResponse()
        {
        }

        public TransferResponse(string receiverAccountNumber, string senderAccountNumber,
            double amount, double senderBalance, double receiverBalance)
        {
            this.ReceiverAccountNumber = receiverAccountNumber;
            this.SenderAccountNumber = senderAccountNumber;
            this.Amount = amount;
            this.SenderBalance = senderBalance;
            this.ReceiverBalance = receiverBalance;
        }

        public string ReceiverAccountNumber { get => receiverAccountNumber; set => receiverAccountNumber = value; }
        public string SenderAccountNumber { get => senderAccountNumber; set => senderAccountNumber = value; }
        public double Amount { get => amount; set => amount = value; }
        public double SenderBalance { get => senderBalance; set => senderBalance = value; }
        public double ReceiverBalance { get => receiverBalance; set => receiverBalance = value; }

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
            return $"Receiver Account Number: {receiverAccountNumber}, " +
                $"Sender Account Number: {senderAccountNumber}, " +
                $"Amount: {amount}, " +
                $"Sender Balance: {senderBalance}, " +
                $"Receiver Balance: {receiverBalance}";
        }
    }
}

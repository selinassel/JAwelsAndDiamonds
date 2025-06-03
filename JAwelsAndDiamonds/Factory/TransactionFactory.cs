using JAwelsAndDiamonds.Model;
using System;

namespace JAwelsAndDiamonds.Factory
{
    public class TransactionFactory
    {
        public TransactionHeader createNewTransaction(int UserID, DateTime TrasactionDate, string PaymentMethod, string TransactionStatus)
        {
            TransactionHeader transaction = new TransactionHeader();
            transaction.UserID = UserID;
            transaction.TransactionDate = TrasactionDate;
            transaction.PaymentMethod = PaymentMethod;
            transaction.TransactionStatus = TransactionStatus;
            return transaction;
        }

        public TransactionDetail createTransactionDetail(int transactionID, int jewelID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionID;
            transactionDetail.JewelID = jewelID;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }

    }
}
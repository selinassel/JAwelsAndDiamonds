using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class TransactionRepository
    {
        TransactionFactory tf = new TransactionFactory();
        Database1Entities1 db = new Database1Entities1();

        public void addNewTransaction(int UserID, DateTime TrasactionDate, string PaymentMethod, string TransactionStatus)
        {
            TransactionHeader transaction = tf.createNewTransaction(UserID, TrasactionDate, PaymentMethod, TransactionStatus);
            db.TransactionHeaders.Add(transaction);
            db.SaveChanges();
        }

        public List<TransactionHeader> ViewHandlerOrders()
        {
            return db.TransactionHeaders
                .Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected")
                .Select(t => new
                {
                    t.TransactionID,
                    t.UserID,
                    t.TransactionDate,
                    t.PaymentMethod,
                    t.TransactionStatus
                })
                .AsEnumerable()
                .Select(t => new TransactionHeader
                {
                    TransactionID = t.TransactionID,
                    UserID = t.UserID,
                    TransactionDate = t.TransactionDate,
                    PaymentMethod = t.PaymentMethod,
                    TransactionStatus = t.TransactionStatus
                })
                .ToList();
        }

        public List<TransactionHeader> GetAllOrders()
        {
            using (var db = new Database1Entities1())
            {
                return db.TransactionHeaders.ToList();
            }
        }

        public List<TransactionDetailViewModel> ViewTransactionDetail()
        {
            return db.TransactionDetails
                .Select(j => new TransactionDetailViewModel
                {
                    TransactionID = j.TransactionID,
                    JewelName = j.MsJewel.JewelName,
                    Quantity = j.Quantity ?? 0
                })
                .ToList();
        }


        public class TransactionDetailViewModel
        {
            public int TransactionID { get; set; }
            public string JewelName { get; set; }
            public int Quantity { get; set; }
        }

        //public void UpdateTransactionStatus(int transactionId, string newStatus)
        //{
        //    var transaction = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
        //    if (transaction != null)
        //    {
        //        transaction.TransactionStatus = newStatus;
        //        db.SaveChanges();
        //    }
        //}


    }
}
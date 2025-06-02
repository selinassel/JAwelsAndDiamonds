using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System.Collections.Generic;

namespace JAwelsAndDiamonds.Handler
{
    public class TransactionsHandler
    {
        Database1Entities1 db = new Database1Entities1();
        TransactionRepository tr = new TransactionRepository();
        public List<TransactionHeader> GetHandlerOrders()
        {
            return tr.GetAllOrders();
        }

        public void UpdateTransactionStatus(int transactionId, string currentStatus, string newStatus)
        {
            using (var db = new Database1Entities1())
            {
                var transaction = db.TransactionHeaders.Find(transactionId);
                if (transaction != null && transaction.TransactionStatus == currentStatus)
                {
                    transaction.TransactionStatus = newStatus;
                    db.SaveChanges();
                }
            }
        }
    }
}
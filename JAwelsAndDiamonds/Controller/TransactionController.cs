using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using System.Collections.Generic;

namespace JAwelsAndDiamonds.Controller
{
    public class TransactionController
    {
        TransactionsHandler handler = new TransactionsHandler();

        public List<TransactionHeader> GetHandlerOrders()
        {
            return handler.GetHandlerOrders();
        }

        public void ConfirmPayment(int transactionId)
        {
            handler.UpdateTransactionStatus(transactionId, "Payment Pending", "Shipment Pending");
        }

        public void ShipPackage(int transactionId)
        {
            handler.UpdateTransactionStatus(transactionId, "Shipment Pending", "Arrived");
        }

        public void UpdateStatus(int transactionId, string currentStatus, string newStatus)
        {
            handler.UpdateTransactionStatus(transactionId, currentStatus, newStatus);
        }

    }
}
using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        TransactionRepository tr = new TransactionRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            GridViewOrder.DataSource = tr.ViewHandlerOrders();
            GridViewOrder.DataBind();
        }

        //protected void GridViewOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "ConfirmPayment")
        //    {
        //        int transactionId = Convert.ToInt32(e.CommandArgument);
        //        //tr.UpdateTransactionStatus(transactionId, "Shipment Pending");
        //    }
        //    else if (e.CommandName == "ShipPackage")
        //    {
        //        int transactionId = Convert.ToInt32(e.CommandArgument);
        //        //tr.UpdateTransactionStatus(transactionId, "Arrived");
        //    }

        //    BindData(); // Refresh grid after action
        //}
    }
}
using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        TransactionRepository tr = new TransactionRepository();
        Database1Entities1 db = new Database1Entities1();
        TransactionController tc = new TransactionController();
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

        protected void GridViewOrder_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ConfirmPayment")
            {
                tc.ConfirmPayment(transactionId);
            }
            else if (e.CommandName == "ShipPackage")
            {
                tc.ShipPackage(transactionId);
            }

            BindData(); // Refresh data after update
        }
    }
}
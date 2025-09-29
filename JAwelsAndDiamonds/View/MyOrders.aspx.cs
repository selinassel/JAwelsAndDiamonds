using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Repository;
using System;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class MyOrders : System.Web.UI.Page
    {
        TransactionRepository tr = new TransactionRepository();
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
            GridViewMyOrder.DataSource = tr.ViewMyOrder();
            GridViewMyOrder.DataBind();
        }

        protected void GridViewMyOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);
            var controller = new TransactionController();

            if (e.CommandName == "ViewDetail")
            {
                Response.Redirect($"TransactionDetails.aspx?transactionId={transactionId}");
                return;
            }
            else if (e.CommandName == "ConfirmPackage")
            {
                controller.UpdateStatus(transactionId, "Arrived", "Done");
            }
            else if (e.CommandName == "RejectPackage")
            {
                controller.UpdateStatus(transactionId, "Arrived", "Rejected");
            }

            BindData();
        }


    }
}
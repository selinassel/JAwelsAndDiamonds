using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        TransactionRepository tr = new TransactionRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            int transactionId;
            if (int.TryParse(Request.QueryString["transactionId"], out transactionId))
            {
                BindData(transactionId);
            }
            else
            {

                Response.Write("Invalid or missing transaction ID.");
            }
        }

        protected void BindData(int transactionId)
        {
            GridViewTransactionDetail.DataSource = tr.ViewTransactionDetail(transactionId);
            GridViewTransactionDetail.DataBind();
        }
    }
}
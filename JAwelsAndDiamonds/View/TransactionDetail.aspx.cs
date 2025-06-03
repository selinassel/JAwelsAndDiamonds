using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class TransactionDetail : System.Web.UI.Page
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
            GridViewTransactionDetail.DataSource = tr.ViewTransactionDetail();
            GridViewTransactionDetail.DataBind();
        }
    }
}
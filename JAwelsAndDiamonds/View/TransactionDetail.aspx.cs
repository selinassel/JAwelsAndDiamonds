using System;

namespace JAwelsAndDiamonds.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BindData()
        {

            GridViewJewelList.DataSource = jh.ViewJewel();
            GridViewJewelList.DataBind();


            GridViewTransactionDetail.DataSource =
            GridViewTransactionDetail.DataBind();
        }
    }
}
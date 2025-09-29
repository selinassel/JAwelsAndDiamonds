using JAwelsAndDiamonds.Dataset;
using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repoorts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.View
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var allTransactions = TransactionsHandler.GetData();

                var doneTransactions = allTransactions
                    .Where(t => t.TransactionStatus != null && t.TransactionStatus.Equals("Done", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (doneTransactions.Count == 0)
                {
                    CrystalReportViewer1.Visible = false;
                    return;
                }

                CrystalReport1 report = new CrystalReport1();
                DataSet1 dataset = GetData(doneTransactions);
                report.SetDataSource(dataset);
                CrystalReportViewer1.ReportSource = report;
            }
        }

        private static DataSet1 GetData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.Transaction;
            var detailTable = data.TransactionDetail;

            foreach (var t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                headerTable.Rows.Add(hrow);

                foreach (var d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["JewelID"] = d.JewelID;
                    drow["Quantity"] = d.Quantity ?? 0;
                    detailTable.Rows.Add(drow);
                }
            }

            return data;
        }
    }
}

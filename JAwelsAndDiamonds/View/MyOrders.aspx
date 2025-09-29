<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="JAwelsAndDiamonds.View.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>My Orders</h1>
    </div>

    <div>
        <asp:GridView ID="GridViewMyOrder" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewMyOrder_RowCommand" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
                <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button
                            ID="btnViewDetail"
                            runat="server"
                            Text="View Detail"
                            CommandName="ViewDetail"
                            CommandArgument='<%# Eval("TransactionID") %>'
                            CssClass="action-btn btn btn-success"
                            Visible='<%# Eval("TransactionStatus").ToString() == "Payment Pending" || Eval("TransactionStatus").ToString() == "Shipment Pending" || Eval("TransactionStatus").ToString() == "Arrived" || Eval("TransactionStatus").ToString() == "Done" || Eval("TransactionStatus").ToString() == "Rejected" %>' />

                        <asp:Button
                            ID="btnConfirmPackage"
                            runat="server"
                            Text="Confirm Package"
                            CssClass="action-btn btn btn-primary"
                            CommandName="ConfirmPackage"
                            CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />

                        <asp:Button
                            ID="btnRejectPackage"
                            runat="server"
                            Text="Reject Package"
                            CssClass="action-btn btn btn-danger"
                            CommandName="RejectPackage"
                            CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

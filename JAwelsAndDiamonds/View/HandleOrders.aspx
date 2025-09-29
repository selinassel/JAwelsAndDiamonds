<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="JAwelsAndDiamonds.View.HandleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Handle Orders</h1>
    </div>

    <div>
        <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewOrder_RowCommand" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button
                            ID="btnConfirmPayment"
                            runat="server"
                            Text="Confirm Payment"
                            CssClass="action-btn btn btn-success"
                            CommandName="ConfirmPayment"
                            CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Convert.ToString(Eval("TransactionStatus")) == "Payment Pending" %>' />

                        <asp:Button
                            ID="btnShipPackage"
                            runat="server"
                            Text="Ship Package"
                            CssClass="action-btn btn btn-primary"
                            CommandName="ShipPackage"
                            CommandArgument='<%# Eval("TransactionID") %>'
                            Visible='<%# Convert.ToString(Eval("TransactionStatus")) == "Shipment Pending" %>' />

                        <asp:Label
                            ID="lblWaiting"
                            runat="server"
                            Text="Waiting for user confirmation..."
                            Visible='<%# Convert.ToString(Eval("TransactionStatus")) == "Arrived" %>' />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="JAwelsAndDiamonds.View.HandleOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
     <h1>Handle Orders</h1>
 </div>

 <div>
     <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False">
         <Columns>
             <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
             <asp:BoundField DataField="UserID" HeaderText="User Id" />
             <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
             <asp:TemplateField HeaderText="Actions">
                 <ItemTemplate>
                     <asp:LinkButton
                         ID="btnConfirmPayment"
                         runat="server"
                         Text="Confirm Payment"
                         CommandName="ConfirmPayment"
                         CommandArgument='<%# Eval("TransactionID") %>'
                         Visible='<%# Eval("TransactionStatus").ToString() == "Payment Pending" %>' />

                     <asp:LinkButton
                         ID="btnShipPackage"
                         runat="server"
                         Text="Ship Package"
                         CommandName="ShipPackage"
                         CommandArgument='<%# Eval("TransactionID") %>'
                         Visible='<%# Eval("TransactionStatus").ToString() == "Shipment Pending" %>' />

                     <asp:Label
                         ID="lblWaiting"
                         runat="server"
                         Text="Waiting user confirmation..."
                         Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                 </ItemTemplate>
             </asp:TemplateField>

         </Columns>
     </asp:GridView>
 </div>
</asp:Content>

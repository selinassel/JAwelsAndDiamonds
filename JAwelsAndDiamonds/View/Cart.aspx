CART.ASPX

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="JAwelsAndDiamonds.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Jewel's Cart</h2>
    </div>
    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
            <asp:BoundField DataField="BrandName" HeaderText="Brand" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="60px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateItem" CommandArgument='<%# Eval("JewelID") %>' />
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="TotalLabel" runat="server" Font-Bold="true" Font-Size="Larger" />

    <br /><br />

    <asp:Label ID="PaymentLabel" runat="server" Text="Select Payment Method:" />
    <asp:DropDownList ID="PaymentDropdown" runat="server" />
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />

    <br /><br />

    <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" OnClick="ClearCartButton_Click" CssClass="btn btn-danger" />
    <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" CssClass="btn btn-success" />

</asp:Content>
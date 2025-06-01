<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="JAwelsAndDiamonds.View.AddJewel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Jewel</h2>
    <div>
        <asp:Label ID="jewelNameLbl" runat="server" Text="Input Jewel Name: " />
        <asp:TextBox ID="jewelNameTxt" runat="server" placeholder="Jewel Name"/>
    </div>
    <div>
        <asp:Label ID="jewelCategoryLbl" runat="server" Text="Select Jewel Category: " />
        <asp:DropDownList ID="JewelCategoryDdl" runat="server"></asp:DropDownList>
    </div>
    <div>
       <asp:Label ID="jewelBrandLbl" runat="server" Text="Select Jewel Brand: " />
       <asp:DropDownList ID="JewelBrandDdl" runat="server"></asp:DropDownList>
    </div>
    <div>
       <asp:Label ID="jewelPriceLbl" runat="server" Text="Input Jewel Price: " />
       <asp:TextBox ID="jewelPriceTxt" runat="server" placeholder="Jewel Price"/>
    </div>
    <div>
       <asp:Label ID="jewelReleaseLbl" runat="server" Text="Input Jewel's Release Year: " />
       <asp:TextBox ID="jewelReleaseTxt" runat="server"/>
    </div>
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red"/>

    <div>
        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click"/>
        <asp:Button ID="addBtn" runat="server" Text="Add Jewel" OnClick="addBtn_Click"/>
    </div>
</asp:Content>

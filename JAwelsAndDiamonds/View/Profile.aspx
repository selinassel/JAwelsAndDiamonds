<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="JAwelsAndDiamonds.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Profile</h2>

    <asp:Label ID="lblUsername" runat="server" Font-Bold="true" Text="Username: "></asp:Label>
    <asp:Label ID="lblEmail" runat="server" Font-Bold="true" Text="Email: "></asp:Label>
    <asp:Label ID="lblDOB" runat="server" Font-Bold="true" Text="Date of Birth: "></asp:Label>
    <asp:Label ID="lblGender" runat="server" Font-Bold="true" Text="Gender: "></asp:Label>

    <h3>Change Password</h3>
    <asp:Label ID="lblMessage" runat="server" CssClass="error-msg"></asp:Label>

    <div class="form-group">
        <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:" AssociatedControlID="txtOldPassword"></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" AssociatedControlID="txtNewPassword"></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" AssociatedControlID="txtConfirmPassword"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"/>
</asp:Content>

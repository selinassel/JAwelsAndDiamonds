<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Navbar.Master" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="JAwelsAndDiamonds.View.ShowDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Jewels Detail</h1>
    </div>

    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell><b>Jewel Name :</b></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LblJewelName" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Category : </b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblCategoryName" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Brand :</b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblBrandName" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Country of Origin :</b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblCountry" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Class :</b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblBrandClass" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Price :</b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblPrice" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><b>Release Year :</b></asp:TableCell><asp:TableCell>
                    <asp:Label ID="LblReleaseYear" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div style="margin-top: 20px;">

        <%  if (Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["Role"] != null && Session["Role"].ToString() == "Customer")
            { %>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
        <% }
            else if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
            { %>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Jewel" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete Jewel" OnClick="btnDelete_Click" />
        <% } %>
    </div>
</asp:Content>

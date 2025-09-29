<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="JAwelsAndDiamonds.View.Reports" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 800px;">
        <CR:CrystalReportViewer 
            ID="CrystalReportViewer1" 
            runat="server"
            ToolPanelView="None"
            HasExportButton="True"
            HasPrintButton="True"
            Width="100%" 
            Height="100%" />
    </div>
</asp:Content>

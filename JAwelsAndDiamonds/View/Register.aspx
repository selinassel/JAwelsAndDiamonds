<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JAwelsAndDiamonds.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <style>
        html, body {
            height: 100%;
            margin: 0;
        }
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            background: #f9f9f9;
            font-family: Arial, sans-serif;
        }
        form {
            display: flex;
            flex-direction: column;
            padding: 30px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background: white;
            box-shadow: 0 4px 10px rgb(0 0 0 / 0.1);
        }
        input:not([type="radio"]):not([type="checkbox"])  {
            padding: 8px;
            width: 250px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        label {
            margin-right: 10px;
        }
        #registButton {
            background-color: lightskyblue;
            color: white;
            border: none;
            padding: 10px 25px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        #registButton:hover {
            background-color: dodgerblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Register</h2>
        <div>
            <asp:Label Text="Email: " runat="server" />
            <asp:TextBox ID="emailBox" runat="server" TextMode="Email" placeholder="Enter email" />
        </div>
        <p></p>
        <div>
            <asp:Label Text="Username: " runat="server" />
            <asp:TextBox ID="usernameBox" runat="server" placeholder="Enter username"/>
        </div>
        <p></p>
        <div>
            <asp:Label Text="Password: " runat="server" />
            <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" placeholder="Enter password"/>
        </div>
        <p></p>
        <div>
            <asp:Label Text="Confirm Password: " runat="server" />
            <asp:TextBox ID="confirmPwBox" runat="server" TextMode="Password" placeholder="Confirm your password"/>
        </div>
        <p></p>
        <div style="display: flex; align-items: center; gap: 10px;">
            <asp:Label Text="Gender: " runat="server"/>
            <asp:RadioButton ID="genderMale" runat="server" GroupName="Gender" Text="Male"/>
            <asp:RadioButton ID="genderFemale" runat="server" GroupName="Gender" Text="Female"/>
        </div>
        <p></p>
        <div>
            <asp:Label Text="Date of Birth: " runat="server" />
            <asp:TextBox ID="dobBox" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <p></p>
        <div>
            <asp:Label ID="errorMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <p></p>
        <div>
            <asp:Button ID="registButton" runat="server" Text="Register" OnClick="RegistButton_Click"/>
        </div>
    </form>
</body>
</html>

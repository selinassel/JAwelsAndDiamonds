<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JAwelsAndDiamonds.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        #loginButton {
            background-color: lightskyblue;
            color: white;
            border: none;
            padding: 10px 25px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        #loginButton:hover {
            background-color: dodgerblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login</h2>
        <div>
            <asp:Label Text="Email: " runat="server" />
            <input id="emailBox" type="email" runat="server" placeholder="Enter your email"/>
        </div>
        <p></p>
        <div>
            <asp:Label Text="Password: " runat="server" />
            <input id="passwordBox" type="password" runat="server" placeholder="Enter your password"/>
        </div>
        <p></p>
        <div">
            <asp:CheckBox ID="rememberMe" runat="server" Text="Remember Me"/>
        </div>
        <p></p>
        <div style="color: red">
            <asp:Label ID="errorLabel" runat="server"/>
        </div>
        <p></p>
        <div>
            <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click"/>
        </div>
    </form>
</body>
</html>

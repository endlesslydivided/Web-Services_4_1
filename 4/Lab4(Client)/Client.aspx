﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="Lab4_ASMX.Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Client form</title>
   
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="first" />
            <asp:TextBox runat="server" ID="second" />
            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Sum" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="result" />
        </div>
    </form>
    
</body>
</html>

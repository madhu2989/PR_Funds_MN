<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_otp.aspx.cs" Inherits="PR_Funds_MN.WebForm_otp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 48%;
        }
        .auto-style2 {
            width: 155px;
        }
        .auto-style3 {
            width: 297px;
        }
        .auto-style4 {
            width: 146px;
        }
        .auto-style5 {
            width: 272px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <asp:Label ID="Label1" runat="server" Text="verify your mobile number"></asp:Label>
           
            <asp:Label ID="Label2" runat="server" ForeColor="#00CC00"></asp:Label>
            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
           
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        Enter your mobile No:
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="235px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" Text="Send OTP" Width="104px" BackColor="#0066FF" ForeColor="Black" OnClick="Button1_Click1" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        Enter OTP:
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox2" runat="server" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="Button2" runat="server" Text="Verify" Width="99px" BackColor="#00CC00" ForeColor="Black" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>


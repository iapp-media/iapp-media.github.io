<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StoreMana.Mini.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button runat="server" Text="Button" OnClick="Unnamed1_Click" />
            </div>
            <div>
                <asp:Repeater ID="RP1" runat="server"> 
                    <ItemTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Order_No")%>'></asp:Literal></div>
                            <div class="col">
                                <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Contact_ID")%>'></asp:Literal></div>
                            <div class="col">
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("status")%>'></asp:Literal></div>
                            <div class="col">
                                <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("CD")%>'></asp:Literal></div>
    <div class="col">
        <asp:Button ID="Button1" runat="server" Text="詳細資訊" /></div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>
                <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
            </div>
        </div>



        <div>
        </div>
    </form>
</body>
</html>

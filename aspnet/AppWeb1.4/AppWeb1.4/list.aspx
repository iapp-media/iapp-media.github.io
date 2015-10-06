<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="list.aspx.vb" Inherits="AppWeb1._4.list" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <link rel="stylesheet" type="text/css" href="css/list.css">
    <link href="img/favicon.ico" rel="shortcut icon" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="content"> 
            <asp:LinkButton ID="LBNew" runat="server" CssClass="addapp-1" Text="增加iApp"></asp:LinkButton> <%--增加App--%>
            <div class="title">
                <p>我的iApp</p>
                <div class="bar1"></div>
            </div>
            <div id="box">
                <div class="op">
                    <ul>
                        <asp:Literal ID="L" runat="server"></asp:Literal>
                        <asp:Repeater ID="RP1" runat="server">
                            <ItemTemplate>
                                <li>
                                    <p class="app-name">
                                        <asp:Literal ID="L1" runat="server" Text='<%# Bind("App_Name") %>'></asp:Literal>
                                    </p>
                                    <asp:Literal ID="LKey" runat="server" Visible="false" Text='<%# Bind("IDNo") %>'></asp:Literal>

                                    <asp:Literal ID="L2" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="LB2" runat="server" CommandName="CN2" CssClass="delete-1" Text="刪除"></asp:LinkButton><%--刪除--%>
                                    <asp:Literal ID="L3" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="LB3" runat="server" CommandName="CN3" CssClass="share-1" Text="分享"></asp:LinkButton><%--分享--%>
                                    <div class="bar2"></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                    </ul>
                </div>
            </div>
        </div>
    </form>

</body>
</html>

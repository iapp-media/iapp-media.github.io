<%@ Page Language="VB" AutoEventWireup="false" CodeFile="複製 - Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
    <link rel="stylesheet" type="text/css" href="css/masonry.css"/>
    <link href="css/colorbox.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-header" style="width: 640px">
        <div align="center">
            <h1><asp:Literal ID="LTitle" runat="server">商店</asp:Literal></h1>
        </div>
    </div>
        <div style=" width:640px">
    <table id="Table4" cellpadding="5" cellspacing="0" class="form_tb" width="100%">
        <tr>
            <td class="form_LC" style=" width:150px">
               產品類別：
            </td>
            <td class="form_RC" colspan="2">
                <asp:DropDownList ID="DDL_Cate" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="form_LC">
                產品名稱：
            </td>
            <td class="form_RC" colspan="2">
                <asp:TextBox ID="TName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_LC">
            </td>
            <td class="form_RC">
                <asp:Button ID="BT_Search" runat="server" Text="查詢" />
            </td>
            <td style=" text-align:right">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    <div style=" width:640px">
        <div id="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="L" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>

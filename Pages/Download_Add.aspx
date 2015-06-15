<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Download_Add.aspx.vb" Inherits="Mana_Download_Download_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>臺中區監理所</title>
    <link href="../func/just_style8.css" type="text/css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="bread"><asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath></div>
<table border="0" width="100%" id="table1" cellspacing="0" cellpadding="0">
	<tr>
		<td style="width:10px;"><img alt="圓角框" border="0" src="../images/CTitle_empty_01.gif" style="width:10px;" height="50" /></td>
		<td class="br_top_blue"><div class="title_bg_blue">
            <asp:Label ID="LabelT" 
                runat="server" Text="新增檔案"></asp:Label>
                </div></td>
		<td style="width:10px;"><img alt="圓角框" border="0" src="../images/Title_RT_blue.gif" style="width:10px;" height="50" /></td>
	</tr>
	<tr>
		<td class="br_left_blue" style="width:10px;"></td>
		<td class="cont_bg">
		<div class="submenu"><asp:Label ID="Label1" runat="server"></asp:Label></div>
            	<table width="100%" id="table2" cellspacing="0" cellpadding="5" class="form_tb">
                <tr id="tr_cate" runat="server" visible="false">
                    <td class="form_LC">分類名稱：</td>
                    <td class="form_RC">
                    <asp:DropDownList ID="DDL" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                        <asp:DropDownList ID="DDL2" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DDL3" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                        <asp:DropDownList ID="DDL4" runat="server" Visible="False">
                    </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="form_LC">檔案名稱：</td>
                    <td class="form_RC">
                        <asp:TextBox ID="TFileName" runat="server" Width="560px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="form_LC">附件：</td>
                    <td class="form_RC">
                                <asp:FileUpload ID="FU1" runat="server" Width="250px" />
                                <asp:Button ID="BTFU1" runat="server" Height="20px" Text="上傳" Width="56px" />
                                <asp:Button ID="BTFUDel1" runat="server" Height="20px" Text="刪除" 
                                    Visible="False" Width="56px" />
                                　（上傳附件後請點選聯結以確認附件上傳成功） 
                                <asp:CheckBoxList ID="CBLFU1" runat="server" Visible="False">
                                </asp:CheckBoxList>
                                <asp:Label ID="LFilePath" runat="server"></asp:Label>
                                &nbsp;</td>
                </tr>
                <tr>
                    <td class="form_LC">順序：</td>
                    <td class="form_RC">
                        <asp:TextBox ID="TSort" runat="server" Width="56px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">&nbsp;</td>
                    <td class="form_RC">
                                <asp:Button ID="BT"
                                    runat="server" Text="儲存送出" CssClass="btn" />
                                <asp:Button ID="BTD" runat="server" CssClass="btn" Text="刪除" Visible="False" /></td>
                </tr>
                </table>
            &nbsp;
		</td>
		<td class="br_right_blue"></td>
	</tr>
	<tr>
		<td style="width:10px;" height="10"><img alt="圓角框" border="0" src="../images/Circle_LB_blue.gif" style="width:10px;" height="10" /></td>
		<td class="br_bottom_blue"></td>
		<td><img alt="圓角框" border="0" src="../images/Circle_RB_blue.gif" style="width:10px;" height="10" /></td>
	</tr>
</table>
</form>
</body>
</html>

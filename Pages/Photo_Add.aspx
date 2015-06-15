<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Photo_Add.aspx.vb" Inherits="Mana_Photo_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>活動花絮資料維護</title>
      <link href="../func/just_style8.css" type="text/css" rel="stylesheet" />     
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager2" EnablePartialRendering="true" runat="server"  EnableScriptGlobalization="true"/>
<table border="0" width="100%" id="table2" cellspacing="0" cellpadding="0">
	<tr>
		<td><img border="0" src="../images/CTitle_empty_01.gif" width="10" height="50"></td>
		<td class="br_top_blue"><div class="title_bg_blue"><asp:Label ID="LabelT" runat="server">電子相簿資料維護</asp:Label></div></td>
		<td><img border="0" src="../images/Title_RT_blue.gif" width="10" height="50"></td>
	</tr>
	<tr>
		<td class="br_left_blue" width="10"></td>
		<td class="cont_bg">
	<div class="submenu">| <a href="photo_Add.aspx">新增相簿</a> | <a href="photo_MANA.aspx">相簿列表</a> |</div>
            <table id="table3" cellpadding="5" cellspacing="0" class="form_tb" width="100%">
                <tr id="tr_Station" runat="server">
                    <td class="form_LC">
                        所站：</td>
                    <td class="form_RC">
                                <asp:DropDownList ID="DDLStation" runat="server">
                                </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">
                        公布日期：</td>
                    <td class="form_RC">
                                <asp:TextBox ID="TDate" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">
                        名稱：</td>
                    <td class="form_RC">
                                <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">
                        說明：</td>
                    <td class="form_RC">
                                <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">
                        上傳圖片：</td>
                    <td class="form_RC">
                                圖說：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                                <asp:FileUpload ID="FU" runat="server" Width="350px" />
                                <asp:Button ID="Button1" runat="server" Height="20px" Text="上傳" Width="56px" />
                                <asp:CheckBoxList ID="CBL" runat="server" RepeatColumns="2" 
                                    RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                <asp:Button ID="Button2" runat="server" Height="20px" Text="刪除相片" Visible="False"
                                    Width="80px" />
                    </td>
                </tr>
                <tr>
                    <td class="form_LC">
                        &nbsp;</td>
                    <td class="form_RC">
                    <asp:Button ID="BT" runat="server" Text="新增儲存" />
                                <asp:Button ID="BTD" runat="server" Text="刪除此筆" Visible="False" />
                                <input id="return" onclick="history.back();" type="button" value="回上一頁" /></td>
                </tr>
                </table>
           </td>
		<td class="br_right_blue"></td>
	</tr>
	<tr>
		<td width="10" height="10"><img border="0" src="../images/Circle_LB_blue.gif" width="10" height="10"></td>
		<td class="br_bottom_blue"></td>
		<td><img border="0" src="../images/Circle_RB_blue.gif" width="10" height="10"></td>
	</tr>
</table>
</form>

</body>

</html>
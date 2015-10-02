<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Secu.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MaTool</title>
</head>
<body>
		<div style="TEXT-ALIGN: center">
		    <br/>
				<form id="Form1" method="post" runat="server"> 
                    <table id="Table4" border="1" cellpadding="4" cellspacing="0" width="260">
                        <tr>
                            <td style="border-top-width: 1px; border-left-width: 1px; border-bottom: #CCCCCC 1px dotted;
                                border-right-width: 1px; width: 60px;" align="left">
                                帳號</td>
                            <td align="left" style="border-top-width: 1px; border-left-width: 1px; border-bottom: #CCCCCC 1px dotted;
                                border-right-width: 1px">
                                <asp:TextBox ID="TUID" runat="server" Width="100px" TabIndex="1" Autocomplete="off"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="border-top-width: 1px; border-left-width: 1px; border-bottom: #CCCCCC 1px dotted;
                                border-right-width: 1px; width: 60px;" align="left">
                                密碼</td>
                            <td align="left" style="border-top-width: 1px; border-left-width: 1px; border-bottom: #CCCCCC 1px dotted;
                                border-right-width: 1px">
                                <asp:TextBox ID="TPWD" runat="server" Width="100px" TextMode="Password" TabIndex="2"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 60px">&nbsp;
                            </td>
                            <td align="left">
                                請輸入下圖顯示文字<br />
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 70px">
                                        	<asp:TextBox ID="TB3" runat="server" Width="100px" TabIndex="3" Autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                        	<asp:ImageButton AlternateText="圖形驗證" ID="ImageButton1" runat="server" ImageUrl="ValidateCode.aspx" TabIndex="6" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="Button1" runat="server" Text="登入" Width="60px" />
                                <asp:Button ID="Button2" runat="server" Text="取消" Width="60px" />
                            </td>
                        </tr>
                    </table>
				</form> 
		</div>
</body>
</html>

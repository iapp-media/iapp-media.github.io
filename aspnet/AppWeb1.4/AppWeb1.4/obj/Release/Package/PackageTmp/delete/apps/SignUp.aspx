<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignUp.aspx.vb" Inherits="AppWeb1._4.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
         <link href="img/favicon.ico" rel="shortcut icon" />
</head>
<body>
        <form id="form2" runat="server">
            <div class="content">
                <!-- title -->
                <div class="title">
                    <p>註冊</p>
                    <div class="bar"></div>
                </div>
                <!-- 註冊input位置 -->
                <div class="input">
                    <div>
                        <table>
                                <tr>
                                    <td>姓名:</td>
                                    <td>
                                        <asp:TextBox  ID="User_Name" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="User_Name" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>帳號</td>
                                    <td>
                                        <asp:TextBox  ID="Email" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="請輸入Email格式" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>密碼</td>
                                    <td>
                                        <asp:TextBox  ID="Pw" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Pw" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                    </div>
                </div> 
                <a href="#">
                    <div class="confirm">
                        <p><asp:LinkButton ID="regBtn1"  runat="server">確認</asp:LinkButton></p>
                    </div>
                </a>
            </div>
        </form>
    </body>
    <script src="js/jquery-2.1.4.min.js"></script>
</html>

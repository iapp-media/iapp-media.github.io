<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Login.Register" %>

<!DOCTYPE html>
<html lang="en">

<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>iApp Mobile We-Media Platform</title>
    <link rel="stylesheet" href="css/reset.css" />
    <%--           <link rel="stylesheet" href="css/default.css" />--%>
    <link rel="stylesheet" href="css/signup.css" />
    <link href="css/button.css" rel="stylesheet" />
    <%--   <link href="img/favicon.ico" rel="shortcut icon" />--%>
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
                                <asp:TextBox ID="User_Name" runat="server" CssClass="tsty"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="User_Name" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>帳號</td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" placeholder="Email" CssClass="tsty"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="請輸入Email格式" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>密碼</td>
                            <td>
                                <asp:TextBox ID="Pw" runat="server" TextMode="Password" CssClass="tsty"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Pw" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="Sendbox_1">
                <asp:CheckBox ID="CB" runat="server" /><strong>我同意 IApp微店《<a target="_blank" id="TosLink" href="../ministore/terms.html">服務條款</a>》及《<a target="_blank" id="PrivacyLink" href="../ministore/privacy.html">隱私權政策</a>》</strong>
            </div>

            <div class="confirm">
                <asp:Button ID="Button1" runat="server" Text="儲存" OnClick="regBtn1_Click" CssClass="save-1" />
            </div>
            <div class="close"> 
                <asp:Button ID="Button2" runat="server" Text="取消" CssClass="cancel-1" OnClientClick="window.open('login.aspx', '_self', '');" />
            </div>
        </div> 
    </form>
</body>
<script src="js/jquery-2.1.4.min.js"></script>
<script>
</script>

</html>


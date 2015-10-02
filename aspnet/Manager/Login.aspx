<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>iApp後台管理系統</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/metisMenu.min.css" rel="stylesheet" />
    <link href="css/Ys-template.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">iApp後台管理系統</h3>
                        </div>
                        <div class="panel-body">
                            <div>

                                <div class="form-group">
                                    <input id="ACC" class="form-control" placeholder="Account" name="Account"   autofocus="autofocus" runat="server"/>
                                </div>
                                <div class="form-group">
                                    <input id="PW" class="form-control" placeholder="Password" name="password" type="password" value="" runat="server"/>
                                </div>
                            <%--    <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me">Remember Me 
                                    </label>
                                </div> --%>
                                <asp:Button ID="BT1" runat="server" Text="Login" CssClass="btn btn-lg btn-success btn-block" OnClick="BT1_Click"  /> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <!-- jQuery -->
    <script type="text/jscript" src="js/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script type="text/jscript" src="js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script type="text/jscript" src="js/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/Ys-template.js"></script>
</body>
</html>

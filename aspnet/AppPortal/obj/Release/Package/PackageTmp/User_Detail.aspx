<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Detail.aspx.cs" Inherits="AppPortal.User_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title>User Detail</title>
  <link rel="stylesheet" type="text/css" media="all" href="css/styles.css">
    <link href="img/favicon.ico" rel="shortcut icon" />
 <script src="js/jquery-1.8.2.min.js"></script>
</head>
<body>
  <div id="topbar">
  </div>
  <div id="w">
    <div id="content" class="clearfix">
      <div id="userphoto"><img src="img/avatar.png" alt="default avatar"></div>
      <h1>個人資料</h1>

      <nav id="profiletabs">
        <ul class="clearfix">
          <li><a href="#Apps">Apps</a></li>
          <li><a href="#settings">Settings</a></li>
        </ul>
      </nav>
          
      <section id="Apps" class="">
        <p>Apps list:</p>
        <ul id="Appslist" class="clearfix">
             <asp:Literal ID="AppsL" runat="server"></asp:Literal>
       
        </ul>
      </section>
      
      <section id="settings" class="hidden">
        <p>Edit your user settings:</p>  
           <asp:Literal ID="SettingL" runat="server"></asp:Literal>
      </section>
    </div><!-- @end #content -->
  </div><!-- @end #w -->
<script type="text/javascript">
    $(function () {
        $('#profiletabs ul li a').on('click', function (e) {
            e.preventDefault();
            var newcontent = $(this).attr('href');

            $('#profiletabs ul li a').removeClass('sel');
            $(this).addClass('sel');

            $('#content section').each(function () {
                if (!$(this).hasClass('hidden')) { $(this).addClass('hidden'); }
            });

            $(newcontent).removeClass('hidden');
        });
    });
</script>
</body>
</html>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AppWeb1._4._Default" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>accomplishaccomplishaccomplishaccomplish</title>
    
    <link rel="stylesheet" href="css/accomplish.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script>
        function init() {
            $("#list").sortable({
                update: function () {
                    dragSelector: "li",
                    putin($(this).sortable('toArray'));
                }
            });
        }
    </script>
    <link href="css/my.css" rel="stylesheet" />
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <script>
            //// 透過PageRequestManager的物件，我們可以在add_pageLoaded的事件後重新註冊jQuery的方法內容
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(init);
        </script>
        <div class="All">
           <!-- 
           <div id="UserInfo">
                歡迎您，親愛的
                <asp:Label ID="Label1" runat="server" Text="訪客"></asp:Label>
                <a href="logout.aspx">登出</a>
            </div>
             -->
            <!-- 左側區塊 -->
            <div class="left">
                <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <ul id="list">
                            <asp:Literal ID="L" runat="server"></asp:Literal>
                        </ul>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton4" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton5" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton6" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DELE1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div> 
            
		<div class="content">
			<div class="phone">
				<div class="show">
					<div class="smallbar2"><p style="color: #F19439;text-align: center;">您的iApp</p></div>
				</div>
				<a href="#" onclick="pagechange(-1)"><img class="up" src="img/up.png" onMouseOut="this.src='img/up.png'"onMouseOver="this.src='img/up2.png'"/></a>
				<a href="#" onclick="pagechange(1)"><img class="down" src="img/down.png" onMouseOut="this.src='img/down.png'" onMouseOver="this.src='img/down2.png'" /></a>
				
                <div style="position: relative; margin:0px;padding:0px; top: 0px; left: 0px; height: 498px; width: 300px;">
                    <iframe src="Pages/p01.aspx" scrolling="no" id="midiframe" style="height: 488px; width: 100%; border:0px"></iframe>
                        <div id="MIDHIDE" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; cursor: pointer;" onclick="editmid()"></div>
                </div>


			</div>
			
			<div class="select">
				<div class="pic1">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
						<asp:ImageButton ID="ImageButton1" CssClass="picture" runat="server" ImageUrl="img/picture1.jpg" CommandArgument="1" />
					</div>
					<p style="font-size: 5px;text-align: center;">單圖</p>
				</div>
				<div class="pic2">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                        <asp:ImageButton ID="ImageButton2" CssClass="picture" runat="server" ImageUrl="img/picture2.jpg" CommandArgument="2" />
					</div>
					<p style="font-size: 5px;text-align: center;">單圖下文字</p>
				</div>
				<div class="pic3">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
						<asp:ImageButton ID="ImageButton3" CssClass="picture" runat="server" ImageUrl="img/picture3.jpg" CommandArgument="3" />
					</div>
					<p style="font-size: 5px;text-align: center;">三格</p>
				</div>
				<div class="pic4">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
						<asp:ImageButton ID="ImageButton4" CssClass="picture" runat="server" ImageUrl="img/picture4.jpg" CommandArgument="4" />
					</div>
					<p style="font-size: 5px;text-align: center;">三張連圖</p>
				</div>
				<div class="pic5">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
						<asp:ImageButton ID="ImageButton5" CssClass="picture" runat="server" ImageUrl="img/picture5.jpg" CommandArgument="5" />
					</div>
					<p style="font-size: 5px;text-align: center;">封面文字</p>
				</div>
				<div class="pic6">
					<div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
						<asp:ImageButton ID="ImageButton6" CssClass="picture" runat="server" ImageUrl="img/picture6.jpg" CommandArgument="6" />
					</div>
					<p style="font-size: 5px;text-align: center;">中間文字</p>
				</div>
			</div>
              <div class="edit" >
               <iframe id="Iframe"  src="Pages/seeEdit.aspx" style="height: 543px; width: 470px">
               </iframe>
             </div>
			<img class="logo" src="img/logo3.png"/>
			<img class="head" src="img/head.png" />
			<img class="button1" src="img/button1.png"/>
			
		</div>
           <!-- 
            <div id="funcdiv">
                <div id="btnMore">
                    <a href="#" id="pageShow">加入頁面按鈕</a>
                </div>

                <div id="btnLast">
                    <a href="#" onclick="pagechange(-1)">上一頁</a>
                </div>
                <div id="btnNext">
                    <a href="#" onclick="pagechange(1)">下一頁</a>
                </div>
            </div>
            <div id="rightdv">
                <div id="tab">
                    <ul id="Test">
                        <li>
                            </li>
                        <li>
                            </li>
                        <li>
                            <asp:ImageButton ID="ImageButton33" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/3.jpg" Width="140px" CommandArgument="3" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton34" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/4.jpg" Width="140px" CommandArgument="4" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton35" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/5.jpg" Width="140px" CommandArgument="5" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton36" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/6.jpg" Width="140px" CommandArgument="6" /></li>
                    </ul>
                </div>
            </div>
             //-->
            
           
        </div>
       
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="La" runat="server" Text="Label" CssClass="nosee"></asp:Label>
                <asp:TextBox ID="AA" runat="server" CssClass="nosee"></asp:TextBox>
                <asp:TextBox ID="DELEID" runat="server" CssClass="nosee"></asp:TextBox>
                <asp:LinkButton ID="DELE1" runat="server"></asp:LinkButton>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
    </form>
</body>
      <script>
          var c = 0;
          var page_id = 0;
          function show(str, id) {
              page_id = id;
              document.getElementById("midiframe").src = str;
              $(".edit").hide();
              for (var i = 0; i <= $("#list").sortable('toArray').length; i++)       //判斷使用者目前點到哪一頁
              {
                  if (($("#list").sortable('toArray')[i]).toString().replace("s", "") == id) {
                      c = i;                                                         //當前頁數上下頁功能使用
                  }
              }
              
          }
          function editmid()
          {
              str = "Pages/seeEdit.aspx?ID=" + page_id;
              document.getElementById("Iframe").src = str;
          }


          $(document).ready(function () {
              $("#pageShow").click(function () {
                  $("#rightdv").animate({ width: 'toggle' }, 350);
                  $(".edit").hide();
              });

          });

          function pagechange(a) {
              c = c + a;
              if (c < 0) {
                  alert(c + "No Page");
                  c = 0;

              } else if (c >= $("#list").sortable('toArray').length) {
                  alert(c + "Page Over");
                  c = c - 1;
              }
              else {
                  document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c]).toString().replace("s", "");
                  //document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c]).toString().replace("s", "");

              }
          }

          function putin(a) {
              document.getElementById("AA").value = a;

              //alert(document.getElementById("AA").value);
          }
          function putDELE(a) {
              document.getElementById("DELEID").value = a;
          }
          //$(function () {
          //    $("#list").dragsort({ dragSelector: "a" });
          //});
          $(document).ready(function () {
              $("#MIDHIDE").click(function () {
                  $("#rightdv").hide();
                  $(".edit").show();
              });
          });
    </script>
</html>

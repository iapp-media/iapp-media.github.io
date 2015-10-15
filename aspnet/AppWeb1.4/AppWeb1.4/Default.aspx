<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AppWeb1._4._Default" %>

<!DOCTYPE html>
<html>

<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>iApp Mobile We-Media Platform</title>
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" href="css/default.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link rel="stylesheet" href="css/jquery.mCustomScrollbar.min.css" />
    <link href="img/favicon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="css/button.css">
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
</head>
<body>
    <!-- 導覽教學頁 -->
    <div class="demonstrate">
        <img src="img/demonstrate.jpg" style="width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; z-index: 999;">
        <!-- <div id="start" class="animated pulse infinite"><p><a href="javascript: void(0)">GO >></a></p>
        </div> -->
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <script>
            //// 透過PageRequestManager的物件，我們可以在add_pageLoaded的事件後重新註冊jQuery的方法內容
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(init);
        </script>
        <div class="all">
            <asp:HyperLink ID="HLogo" CssClass="homelogo" runat="server" NavigateUrl="../portal/" ImageUrl="img/iapplogo.png"></asp:HyperLink> 
            <div class="pageNavall">
                <!-- 左側區塊 -->
                <div id='pageNav'>
                    <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <ul id="list">
                                <asp:Literal ID="L" runat="server"></asp:Literal>
                                <%--<asp:TextBox ID="T3" runat="server"></asp:TextBox>--%>
                            </ul>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DELE1" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="RP1" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="content">
                <div class="phone">
                    <div class="show">
                        <!-- 標題 -->
                        <div class="smallbar">
                            <p style="color: #F19439; text-align: center; line-height: 50px;">您的iApp</p>
                        </div>
                        <!-- iframe顯示區域 -->
                        <div class="iframe">
                            <iframe src="Pages/cover.htm" scrolling="no" id="midiframe" style="height: 100%; width: 100%; border: 0px"></iframe>
                        </div>
                    </div>
                    <!-- 分享/預覽 -->
                    <div class="preview">
                        <a href="javascript: void(0)" id="preview">
                            <img class="preview1" src="img/preview.png" />
                            <img class="preview2" src="img/preview2.png" /></a>
                    </div>
                    <!-- 返回修改-最後完成頁時出現 -->
                    <div class="return hide">
                        <a href="javascript: void(0)" id="return">
                            <img class="preview1" src="img/return-01.png" />
                            <img class="preview2" src="img/return-02.png"></a>
                    </div>
                    <!-- 上一頁＆下一頁 -->
                    <div class="up">
                        <a href="javascript: void(0)" onclick="pagechange(-1)">
                            <img class="up-img1" src="img/up.png" />
                            <img class="up-img2" src="img/up2.png"></a>
                    </div>

                    <div class="down">
                        <a href="javascript: void(0)" onclick="pagechange(1)">
                            <img class="down1" src="img/down.png" />
                            <img class="down2" src="img/down2.png"></a>
                    </div>
                </div>
                <!-- 增加 -->
                <div class="add">
                    <a href="javascript: void(0)" id="pageShow">
                        <img class="add1" src="img/add01.png" />
                        <img class="add2" src="img/add02.png" /></a>
                </div>
                <!-- 發布 -->
                <div class="publish-btn hide">
                    <a href="javascript: void(0)" id="publish-btn">
                        <img class="publish-btn1" src="img/publish-1.png" />
                        <img class="publish-btn2" src="img/publish-2.png" /></a>
                </div>
                <!-- 按下增加，呼叫select選擇區域 -->
                <div class="select">
                    <a href="javascript: void(0)" id="close-select">
                        <img style="position: absolute; bottom: 20px; right: 10px; width: 20px; z-index: 3;" src="img/close-1.png">
                    </a>
                    <asp:Repeater ID="RP1" runat="server">
                        <ItemTemplate>
                            <asp:Literal ID="L1" Visible="false" runat="server" Text='<%# Bind("IDNo") %>'></asp:Literal>
                            <asp:Literal ID="L2" runat="server"></asp:Literal>
                            <div style="width: 85px; height: 125px; border-style: solid; border-width: 1px; border-color: #000000;">
                                <asp:ImageButton ID="IMB" CssClass="picture" CommandName="addPage" runat="server" ImageUrl='<%# Bind("img") %>' />
                            </div>
                            <p style="font-size: 12px; text-align: center;">
                                <asp:Literal ID="PageName" runat="server" Text='<%# Bind("Page_Name")%>'></asp:Literal>
                            </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                </div>
                <!-- iframe編輯區域 -->
                <div class="edit hide">
                    <a href="javascript: void(0)" id="close">
                        <img style="position: absolute; bottom: 20px; right: 10px; width: 20px; z-index: 3;" src="img/close-1.png">
                    </a>
                    <%--                                      <a href="javascript: void(0)" id="btpic"><img class="button-pic" src="img/button-pic.png"></a>
                  <a href="javascript: void(0)" id="btword"><img class="button-wod" src="img/button-word.png"></a>--%>
                    <!-- 編輯iframe -->
                    <iframe id="iframe-ed1" class="iframe-ed1" src="" scroll="no"></iframe>
                </div>

                <!-- 設定＆個人資料＆列表 -->
                <asp:Literal ID="Lprofile" runat="server"></asp:Literal>
                <%--<a class='iframe-info' href="http://www.iapp-media.com/Login/profile.aspx?i="  >
                    <img class="head" src="img/defaulthead.jpg" /></a>--%>
                <a class='iframe-info' href="list.aspx">
                    <img class="list" src="img/item-1.png" /></a>

                <!-- 發布頁面 -->
                <div class="publish hide">
                    <div class="top"></div>
                    <div class="middle">
                        <asp:Literal ID="LFrame2" runat="server"></asp:Literal>
                    </div>
                    <div class="bottom">
                        <a href="javascript: void(0)" id="close-publish">
                            <img class="cancel" src="img/close-1.png"></a>
                    </div>
                </div>

                <!-- 完成時候的結果頁面 -->
                <div class="final hide">
                    <div class="top"></div>
                    <div class="middle">
                        <div class="topImg">
                            <img src="img/pic-22.png" class="topImg1">
                            <img src="img/iapplogo2.png" alt="" class="topImg2">
                        </div> 
                        <img id="Qrimg" src="#">
                        <div class="describe"> 
                                Digital+數碼數位<br />
                                專注在Digital的思考<br />
                                建構行動自媒體的社群平台 
                        </div>
                        <div class="sharemore">
                            <ul>
                                <li>
                                    <img id="sharefb" src="img/sharefb.png" alt=""></li>
                                <li>
                                    <img id="sharetwitter" src="img/sharetwitter.png" alt=""></li>
                                <li>
                                    <img id="shareline" src="img/shareline.png" alt=""></li>
                            </ul>
                        </div>
                        <%--  <a href="javascript: void(0)">
                            <img src="img/copylink.png" style="position: absolute; top: 242px; left: 450px;">
                        </a>--%>
                        <div class="src" id="final">http://iapp-media.com/</div>

                        <asp:LinkButton ID="NewApps" runat="server" CssClass="create create-1" Text="微創作"></asp:LinkButton>

                        <%--微創作--%>


                        <asp:LinkButton ID="FBShare" runat="server" OnClientClick="FBShareCK()" CssClass="share hotshare-1" Text="熱分享"></asp:LinkButton><%--熱分享--%>
                    </div>
                    <div class="bottom"></div>
                </div>

                <!-- logo＆company tiltle -->
                <img class="logo" src="img/bgimg.png" />
                <div style="position: fixed; bottom: 0; right: 10px;">
                    <img src="img/digitallogo.png" border="0">
                </div>
            </div>

        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="La" runat="server" Text="Label" CssClass="hide"></asp:Label>
                <asp:TextBox ID="AA" runat="server" CssClass="hide"></asp:TextBox>
                <asp:TextBox ID="DELEID" runat="server" CssClass="hide"></asp:TextBox>
                <asp:LinkButton ID="DELE1" runat="server" CssClass="hide"></asp:LinkButton>
                <asp:LinkButton ID="SavSort" runat="server" CssClass="hide"></asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <!-- 有min版本的話換掉 -->
    <script src="js/jquery.colorbox-min.js"></script>
    <script src="js/jquery.url.min.js"></script>
    <script src="js/webedit.js"></script>
    <script src="js/jquery.mCustomScrollbar.min.js"></script>
</body>
</html>

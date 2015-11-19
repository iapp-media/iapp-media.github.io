<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_SInfo.aspx.cs" Inherits="StoreMana.Setting_SInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div>--%>
     <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Setting.aspx" style="color: white">參數設定</a></div>
                <div class="swiper-slide"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></div>
                <div class="swiper-slide"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></div>
            </div>
        </div>
    </div>

    <div class="buydivmove">
        <div class="col-xs-12 insidecare">
            <div class="row">
 
                <div class="col-xs-12 libor paynumber PadLib ProGrayC">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">付款方式</p>
                        </div>
                    </div>
                    <div class="col-xs-8 SinCheck">
                        <asp:CheckBoxList ID="CB_Payment" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1">
                        </asp:CheckBoxList>
                    </div>
                </div>
                 <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">寄送方式</p>
                        </div>
                    </div>
                    <div class="col-xs-8 SinCheck">
                        <asp:CheckBoxList ID="CB_Delivery" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1">
                        </asp:CheckBoxList>
                    </div>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">選購情境</p>
                        </div>
                    </div>
                    <asp:DropDownList ID="DLlayout" runat="server"  CssClass="form-control">
                        <asp:ListItem Value="0">basic基本場景</asp:ListItem>
                        <asp:ListItem Value="5">fast 快速場景</asp:ListItem>
                    </asp:DropDownList> 
                </div>
<%--                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">店家帳號</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBStoreNID" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>--%>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">銀行名稱</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBBankName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">銀行代碼</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBBankNo" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">受款帳號</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBACC" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">受款戶名</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBACName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">商店名稱</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBName" Font-Names="TBName" runat="server" CssClass="form-control magclose" onkeyup="words_deal(12)"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">聯絡人</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBCEO" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>

                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">聯絡電話</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBTEL" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">聯絡地址</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TBAddr" runat="server" CssClass="form-control magclose"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor status CBbot CBBTN">
                    <asp:Button ID="BT_Save" runat="server" Text="儲存" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Save_Click" />
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script>

        var texttmp = $("#ContentPlaceHolder1_TBName").val();
        function words_deal(cct) {
            var curLength = getlength($("#ContentPlaceHolder1_TBName").val());
            if (curLength > cct) {
                document.getElementById('ContentPlaceHolder1_TBName').value = texttmp;
                alert("超過字數限制，多出的字將被移除！");
            } else {
                texttmp = $("#ContentPlaceHolder1_TBName").val();
            }
        }
        function getlength(str) {
            var arr = str.match(/[^\x00-\xff]/ig);
            return (arr == null) ? str.length : str.length + arr.length;
        }
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_SInfo.aspx.cs" Inherits="StoreMana.Setting_SInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div>
        <div id="content"> 
        <div class="col-xs-12 AllBox BoxBorder">
            <div class="row">
                <!-- 參數設定 -->
                <div class="allmodify">
                    <ul class="buydivmove mart10">
                        <li class="modify col-xs-12">
                            <div class="col-xs-12 insidecare">
                                <div class="row">
                                     <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-5">付款方式</label>
                                        <asp:CheckBoxList ID="CB_Payment" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:CheckBoxList>

                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-5">寄送方式</label>
                                        <asp:CheckBoxList ID="CB_Delivery" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:CheckBoxList> 
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">店家帳號</label>
                                        <asp:TextBox ID="TBStoreNID" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">銀行名稱</label>
                                        <asp:TextBox ID="TBBankName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">銀行代碼</label>
                                        <asp:TextBox ID="TBBankNo" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">受款帳號</label>
                                        <asp:TextBox ID="TBACC" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">受款戶名</label>
                                        <asp:TextBox ID="TBACName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">商店名稱</label>
                                        <asp:TextBox ID="TBName"  Font-Names="TBName" runat="server" CssClass="form-control magclose" onkeyup="words_deal(12)" ></asp:TextBox>
 
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">聯絡地址</label>
                                        <asp:TextBox ID="TBAddr" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">連絡電話</label>
                                        <asp:TextBox ID="TBTEL" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label class="col-xs-6">連絡人</label>
                                        <asp:TextBox ID="TBCEO" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="BT_Save" runat="server" Text="儲存" CssClass="btn btn-default col-xs-12" OnClick="BT_Save_Click" />
                                 </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- 參數設定 end -->
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

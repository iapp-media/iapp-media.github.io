<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="StoreMana.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">分店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div> 
    <!-- 參數設定 -->
    <div class="allmodify">
        <ul class="buydivmove mart10">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品類別</label>
                            <div class="col-lg-6">
                                <div class="input-group">
                                    <asp:TextBox ID="TB_Cate" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="BTplus" runat="server" Text="+" CssClass="btn btn-default" OnClick="BTplus_Click" />
                                    </span>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="input-group">

                                    <asp:CheckBoxList ID="CBL_Cate" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                    <asp:Button ID="BTDEL" runat="server" Text="刪除" CssClass="btn btn-default" OnClick="BTDEL_Click" />
                                </div>
                            </div>
                        </div>
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
                            <asp:TextBox ID="TBName" runat="server" CssClass="form-control magclose"></asp:TextBox>
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
                        <%--                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">付款方式</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">寄送方式</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>--%>
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <!-- 參數設定 end -->
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="StoreMana.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div>

    <!-- WRAPPER -->
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
                                        <label for="" class="col-xs-6">商品類別</label>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:TextBox ID="TB_Cate" runat="server"  BorderColor="Red" ></asp:TextBox>
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
                                 </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- 參數設定 end -->
            </div>
        </div>
    </div>
</asp:Content>

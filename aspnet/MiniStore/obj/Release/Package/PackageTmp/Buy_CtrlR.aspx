<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_CtrlR.aspx.cs" Inherits="MiniStore.Buy_CtrlR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-xs-12 libor ContentTop">
        <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2" onclick="javascript:history.back()" />

        <h1 class="col-xs-10">購買商品明細</h1>

    </div>
    <ul class="buydivmove">
        <li class="productcare">
            <div class="col-xs-12 insidecare">
                <div class="row">

                    <div class="col-xs-12 detailsbox">
                        <div class="row">
                            <asp:Repeater ID="RP4" runat="server">
                                <ItemTemplate>
                                    <div class="details" runat="server" id="DivDetails">
                                        <div class="col-xs-5 col-sm-3">
                                            <img src="<%# ShowImg(Eval("Item_ID")) %>" alt="Alternate Text" class=" imgH" />
                                        </div>
                                        <div class="col-xs-7 col-sm-9">
                                            <h3><%# Eval("Name") %></h3>
                                            <div class="MonBox">
                                                <p>價錢</p>
                                                <span runat="server" id="Dtotal" class="TBC">$<%# Eval("Total","{0:0.####}") %></span></div>
                                            <div class="MonBox">
                                                <p>數量</p>
                                                <span runat="server" id="Qty" class="TBC"><%# Eval("qty") %></span>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="L4" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD4" runat="server"></asp:SqlDataSource>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-xs-12 libor">
                                <div class="buyCtrlMoney2">
                                    <p>您在此商店有<asp:Literal ID="AllBpoin" runat="server"></asp:Literal>點數</p>
                                    <div class="check"> 
                                        <asp:CheckBox ID="ChBonus" runat="server" Text="使用折扣" AutoPostBack="true" OnCheckedChanged="ChBonus_CheckedChanged" />

                                    </div>
                                    <p>
                                        <asp:Literal ID="BpoinRule" runat="server"></asp:Literal>
                                    </p>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="col-xs-12 libor payNum">
                                <div class="buyCtrlMoney1">
                                    <label class="col-xs-6 padReset">總消費金額</label>
                                    <asp:Label ID="TB_Paysum" runat="server" Text="" CssClass="col-xs-6 padReset TRC"></asp:Label>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div id="BonusDiscount" class="col-xs-12 libor payNum" runat="server" visible="false">
                                <div class="buyCtrlMoney1">
                                    <asp:Label ID="LBpoint" runat="server" CssClass="col-xs-6 padReset" Text=""></asp:Label>
                                    <asp:Label ID="LBprice" runat="server" CssClass="col-xs-6 padReset TRC" Text=""></asp:Label>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="col-xs-12 libor payNum allPadMon">
                                <div class="buyCtrlMoney">
                                    <label class="col-xs-6 padReset">合計:</label>
                                    <asp:Label ID="LTotal" runat="server" Text="" CssClass="col-xs-6 padReset TRC"></asp:Label>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="col-xs-12 libor paytheway AllPad">
                                <label for="" class="col-xs-4 padReset">付款方式</label>
                                <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control marReset"></asp:DropDownList>
                            </div>
                            <div class="col-xs-12 libor paytheway AllPad Divide">
                                <label class="col-xs-4 padReset">運送方式</label>
                                <asp:DropDownList ID="DL_Delivery" runat="server" CssClass="form-control marReset" placeholder="請選擇運送方式"></asp:DropDownList>
                            </div>
                            <div class="col-xs-12 libor CBbot CBarea CBline padTOP">
                                <div></div>
                            </div>
                            <div class="col-xs-12 libor sendadress AllPad">
                                <label class="col-xs-5 padReset">姓名</label>
                                <asp:TextBox ID="TB_Name" runat="server" CssClass="col-xs-7"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 libor sendadress AllPad">
                                <label class="col-xs-5 padReset">電話</label>
                                <asp:TextBox ID="TB_Tel" runat="server" CssClass="col-xs-7"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 libor sendadress AllPad">
                                <label class="col-xs-5 padReset">郵遞區號</label>
                                <asp:TextBox ID="TB_MNO" runat="server" CssClass="col-xs-7"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 libor sendadress AllPad">
                                <label class="col-xs-5 padReset">地址</label>
                                <asp:TextBox ID="TB_Addr" runat="server" CssClass=" col-xs-7" Rows="3"></asp:TextBox>
                            </div>

                            <div class="col-xs-12 libor CBbot CBarea CBline padTOP">
                                <div></div>
                            </div>
                            <div class="col-xs-12 libor status CBbot CBBTN">
                                <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </li>
    </ul>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script>
        function cint2(obj) {
            if ($.isNumeric(obj)) {
                return parseInt(obj);
            } else {
                return 0;
            }
        }

        //$(document).ready(function () {
        //    var ISChB = 1;
        //    $("#BonusDiscount").hide();

        //    $("#ContentPlaceHolder1_ChBonus").click(function () {
        //        if (ISChB == 1) {
        //            $("#BonusDiscount").fadeIn();
        //            tmptotal(1);
        //            ISChB = 0;
        //        } else {
        //            $("#BonusDiscount").hide();
        //            tmptotal(0);
        //            ISChB = 1;
        //        }
        //    });

        //    function tmptotal(a) {
        //        var a7 = cint2(document.getElementById("ContentPlaceHolder1_TB_Paysum").innerHTML);
        //        var a6 = cint2(document.getElementById("ContentPlaceHolder1_LBprice").innerHTML);

        //        if (a == 1) {
        //            document.getElementById("ContentPlaceHolder1_LTotal").innerHTML = a7 + a6;
        //        } else {
        //            document.getElementById("ContentPlaceHolder1_LTotal").innerHTML = a7;
        //        }

        //    }


        //});

    </script>
</asp:Content>


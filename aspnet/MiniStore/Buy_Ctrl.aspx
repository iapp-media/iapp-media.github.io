<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Ctrl.aspx.cs" Inherits="MiniStore.Buy_Ctrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <asp:Label ID="LCount" runat="server" Text="" CssClass="hidden"></asp:Label>


                            <asp:Repeater ID="RP1" runat="server" OnItemDataBound="RP1_ItemDataBound">
                                <ItemTemplate>
                                    <div class="details col-xs-12" runat="server" id="DivDetails">
                                        <div class="DTimg">
                                            <img src="<%# ShowImg(Eval("ItemID")) %>" alt="Alternate Text" class="productSize imgH" />
                                        </div>
                                        <div class="Detailsmid">
                                            <h3><%# Eval("Name") %></h3>
                                            <div class="MonBox">
                                                <p>價錢</p>
                                                <span runat="server" id="Dtotal" class="TBC">$<%# Eval("Total") %></span></div>
                                            <span runat="server" id="Dprice" style="visibility: hidden"><%# Eval("Price") %></span>
                                            <asp:Label ID="Lb_Item" runat="server" Text='<%# Eval("ItemID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="Lb_Carbaby" runat="server" Text='<%# Eval("carID") %>' Visible="false"></asp:Label>
                                            <asp:Literal ID="L_BTminus" runat="server"></asp:Literal>
                                            <asp:TextBox ID="Qty" runat="server" CssClass="input-number" Text='<%# Eval("AMT","{0:0.####}") %>'></asp:TextBox>
                                            <asp:Literal ID="L_BTplus" runat="server"></asp:Literal>
                                        </div>

                                        <asp:Literal ID="L_DELE" runat="server"></asp:Literal>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD1" runat="server" OnSelected="SD1_Selected"></asp:SqlDataSource>
                    <div class="col-xs-12 libor">
                        <div class="buyCtrlMoney2">
                            <p>您在此商店有<asp:Literal ID="AllBpoin" runat="server"></asp:Literal>點數</p>
                            <div class="check">
                                <asp:CheckBox ID="ChBonus" runat="server" Text="使用折扣" />
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
                    <div id="BonusDiscount" class="col-xs-12 libor payNum">
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
                        
                    

                    <%--                    <div class="col-xs-12 libor paytheway  PaylastBox">
                        <label class="col-xs-5 padReset">使用上次記錄</label>
                        <div class="PLBBot PLBTop col-xs-7">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="組別ㄧ" CssClass="AllPad" />
                            <asp:CheckBox ID="CheckBox3" runat="server" Text="組別二" />
                        </div>
                    </div>--%>
                    <div class="col-xs-12 libor CBbot CBarea CBline padTOP">
                        <div></div>
                    </div>
                    <div class="col-xs-12 libor status CBbot CBBTN">
                        <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
                    </div>

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
        function CountPrice(K1) {
            $.ajax({
                type: 'GET',
                url: 'ShopCarBaby.aspx?K0=3&K3=' + getQValue("SN") + '',
                success: function (msg) {
                    //$("#ContentPlaceHolder1_TB_Paysum").val(msg);
                    document.getElementById("ContentPlaceHolder1_TB_Paysum").innerHTML = msg;
                },
                error: function (msg) {
                    alert(msg)
                }
            });
        }
        function putDELE(obj, K0, K1, K2) {
            if (confirm('確定刪除這項商品？')) {
                $.ajax({
                    type: 'GET',
                    url: 'ShopCarBaby.aspx?K0=' + 0 + '&K1=' + K1 + '&K2=' + K2 + '',
                    success: function (msg) {
                        if (msg != "suc") { return false; }
                        document.getElementById("ContentPlaceHolder1_LCount").innerHTML = cint2(document.getElementById("ContentPlaceHolder1_LCount").innerHTML) - 1
                        $("#ContentPlaceHolder1_RP1_DivDetails_" + obj).hide();
                        CountPrice(K1)
                    },
                    error: function (msg) {
                        alert(msg)
                    }
                });
            } else {
                return false;
            }
        }

        function plus(obj, num, K0, K1) {
            $.ajax({
                type: 'GET',
                url: 'ShopCarBaby.aspx?K0=' + K0 + '&K1=' + K1 + '',
                success: function (msg) {
                    if (msg != "suc") { return false; }

                    var a1 = cint2($("#ContentPlaceHolder1_RP1_Qty_" + num).val().replace(/\,/g, ""));
                    if (a1 == obj) {
                        alert('超過現貨數量');
                    } else {
                        $("#ContentPlaceHolder1_RP1_Qty_" + num).val(a1 + 1);
                        var a2 = cint2(document.getElementById("ContentPlaceHolder1_RP1_Dprice_" + num).innerHTML.replace(/\,/g, ""));
                        document.getElementById("ContentPlaceHolder1_RP1_Dtotal_" + num).innerHTML = '$' + ((a1 + 1) * a2);
                        SumItemTotal(document.getElementById("ContentPlaceHolder1_LCount").innerHTML);

                    }
                },
                error: function (msg) {
                    alert(msg)
                }
            });
        }

        function minus(num, K0, K1) {
            var a1 = cint2($("#ContentPlaceHolder1_RP1_Qty_" + num).val().replace(/\,/g, ""));
            if (a1 == 1) {
                //   alert('不能再少了');
            } else {
                $.ajax({
                    type: 'GET',
                    url: 'ShopCarBaby.aspx?K0=' + K0 + '&K1=' + K1 + '',
                    success: function (msg) {
                        if (msg != "suc") { return false; }

                        $("#ContentPlaceHolder1_RP1_Qty_" + num).val(a1 - 1);
                        var a2 = cint2(document.getElementById("ContentPlaceHolder1_RP1_Dprice_" + num).innerHTML.replace(/\,/g, ""));
                        document.getElementById("ContentPlaceHolder1_RP1_Dtotal_" + num).innerHTML = '$' + ((a1 - 1) * a2);
                        SumItemTotal(document.getElementById("ContentPlaceHolder1_LCount").innerHTML);
                    },
                    error: function (msg) {
                        alert(msg)
                    }
                });
            }
        }

        function SumItemTotal(obj) {
            var tmpA = 0;
            for (var i = 0; i < obj; i++) {
                tmpA += cint2(document.getElementById("ContentPlaceHolder1_RP1_Dtotal_" + i).innerHTML.replace(/\,/g, "").replace("$", ""));
            }
            //$("#ContentPlaceHolder1_TB_Paysum").val(tmpA);
            document.getElementById("ContentPlaceHolder1_TB_Paysum").innerHTML = tmpA;
        }
        function getQValue(varname) {
            var url = window.location.href;
            var qparts = url.split("?");
            if (qparts.length <= 1) {
                return "";
            } else {
                var query = qparts[1];
                var vars = query.split("&amp;");
                var value = "";
                for (i = 0; i < vars.length; i++) {
                    var parts = vars[i].split("=");
                    if (parts[0] == varname) {
                        value = parts[1];
                        break;
                    }
                }
                value = unescape(value);
                value.replace(/\+/g, " ").replace("#", "");
                return value;
            }
        }

        $(document).ready(function () {
            var ISChB = 1;
            $("#BonusDiscount").hide();

            $("#ContentPlaceHolder1_ChBonus").click(function () {
                if (ISChB == 1) {
                    $("#BonusDiscount").fadeIn();
                    tmptotal(1); 
                    ISChB = 0;
                } else {
                    $("#BonusDiscount").hide();
                    tmptotal(0);
                    ISChB = 1;
                }
            });

            function tmptotal(a) {
                var a7 = cint2(document.getElementById("ContentPlaceHolder1_TB_Paysum").innerHTML);
                var a6 = cint2(document.getElementById("ContentPlaceHolder1_LBprice").innerHTML);

                if (a == 1) {
                    document.getElementById("ContentPlaceHolder1_LTotal").innerHTML = a7 + a6;
                } else {
                    document.getElementById("ContentPlaceHolder1_LTotal").innerHTML = a7;
                }

            }


        });

     </script>
</asp:Content>

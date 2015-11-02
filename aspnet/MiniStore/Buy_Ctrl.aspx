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
                                                <span runat="server" id="Dtotal" class="TOC">$<%# Eval("Total") %></span>
                                            </div>
                                            <%--<span runat="server" id="Dprice" style="visibility: hidden"><%# Eval("Price") %></span>--%>
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

                    <div class="col-xs-12 libor payNum AllPad">
                        <label class="col-xs-6 padReset">總消費金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6 padReset TRC" Enabled="false"></asp:TextBox>
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
                        <label class="col-xs-5 padReset">收件人資訊</label>
                        <div class="col-xs-7 padReset">
                            <asp:TextBox ID="TB_Name" runat="server" placeholder="姓名" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3"></asp:TextBox>
                        </div>
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

        function putDELE(obj, K0, K1, K2) {
            if (confirm('確定刪除這項商品？')) {
                $.ajax({
                    type: 'GET',
                    url: 'ShopCarBaby.aspx?K0=' + 0 + '&K1=' + K1 + '&K2=' + K2 + '',
                    success: function (msg) {
                        if (msg != "suc") { return false; }
                        document.getElementById("ContentPlaceHolder1_LCount").innerHTML = cint2(document.getElementById("ContentPlaceHolder1_LCount").innerHTML) - 1
                        $("#ContentPlaceHolder1_RP1_DivDetails_" + obj).hide();
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
                alert('不能再少了');
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
            $("#ContentPlaceHolder1_TB_Paysum").val(tmpA);
        }

    </script>
</asp:Content>

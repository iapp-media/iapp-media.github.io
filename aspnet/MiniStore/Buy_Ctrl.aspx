<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Ctrl.aspx.cs" Inherits="MiniStore.Buy_Ctrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <%-- 總金額 -付款方式 -寄送方式 -收件人資訊 -購買商品明細( name*qty = price) --%>
                    <%--                    <div style="display:none">
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-12">購買商品明細</label>
                        <div class="col-xs-7">
                            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" EnableTheming="True" DataKeyNames="ItemID,carID" BorderStyle="Solid" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="商品名稱">
                                        <ItemStyle CssClass="gv_row" Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Price" HeaderText="單價" HtmlEncode="false" DataFormatString="{0:#,##0.##}">
                                        <ItemStyle CssClass="gv_row" Width="70px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="BTminus" runat="server" Text="-" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gv_row" Width="60px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="數量">
                                        <ItemTemplate>
                                            <asp:TextBox ID="C3" runat="server" Text='<%# Eval("AMT","{0:0.####}") %>' Width="60px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gv_row" Width="60px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="BTplus" runat="server" Text="+" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="gv_row" Width="60px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Total" HeaderText="總價">
                                        <ItemStyle CssClass="gv_row" Width="70px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" CommandName="DELE" HeaderText="" Text="刪除">
                                        <ItemStyle CssClass="gv_row" HorizontalAlign="Center" Width="30px" />
                                    </asp:ButtonField>
                                </Columns>

                            </asp:GridView>
                          
                        </div>
                    </div> 
                    </div>--%>
                    <div class="col-xs-12 detailsbox">
                        <asp:Label ID="LCount" runat="server" Text="" CssClass="hidden"></asp:Label>

                        <h1>購買商品明細</h1>
                        <asp:Repeater ID="RP1" runat="server" OnItemDataBound="RP1_ItemDataBound">
                            <ItemTemplate>
                                <div class="details" runat="server" id="DivDetails">
                                    <img src="<%# ShowImg(Eval("ItemID")) %>" alt="Alternate Text" class="productSize" />
                                    <h3><%# Eval("Name") %></h3>
                                    <span runat="server" id="Dtotal">$<%# Eval("Total") %></span>
                                    <span runat="server" id="Dprice" style="visibility: hidden"><%# Eval("Price") %></span>
                                    <asp:Label ID="Lb_Item" runat="server" Text='<%# Eval("ItemID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Lb_Carbaby" runat="server" Text='<%# Eval("carID") %>' Visible="false"></asp:Label>
                                    <br />
                                    <asp:Literal ID="L_BTminus" runat="server"></asp:Literal>
                                    <asp:TextBox ID="Qty" runat="server" CssClass="input-number" Text='<%# Eval("AMT","{0:0.####}") %>'></asp:TextBox>
                                    <asp:Literal ID="L_BTplus" runat="server"></asp:Literal>
                                    <asp:Literal ID="L_DELE" runat="server"></asp:Literal>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD1" runat="server" OnSelected="SD1_Selected"></asp:SqlDataSource>

                    <div class="col-xs-12 libor payNum">
                        <label class="col-xs-6">應付金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">付款方式</label>
                        <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label class="col-xs-6">運送方式</label>
                        <asp:DropDownList ID="DL_Delivery" runat="server" CssClass="form-control" placeholder="請選擇運送方式"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor sendadress">
                        <label class="col-xs-5">收件人資訊</label>
                        <div class="col-xs-7">
                            <asp:TextBox ID="TB_Name" runat="server" placeholder="姓名" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label class="col-xs-5">儲存收件人資訊以便下次使用</label>
                        <asp:CheckBox ID="CBinfo" runat="server" Text="是" />
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="否" />
                        <span>使用上次記錄</span>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="組別ㄧ" />
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="組別二" />
                    </div>
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Ctrl.aspx.cs" Inherits="MiniStore.Buy_Ctrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <%-- 總金額 -付款方式 -寄送方式 -收件人資訊 -購買商品明細( name*qty = price) --%>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">購買商品明細</label>
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
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="col-xs-12 libor payNum">
                        <label for="" class="col-xs-6">應付金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">付款方式</label>
                        <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">運送方式</label>
                        <asp:DropDownList ID="DL_Delivery" runat="server" CssClass="form-control" placeholder="請選擇運送方式"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">收件人資訊</label>
                        <div class="col-xs-7">
                            <asp:TextBox ID="TB_Name" runat="server" placeholder="姓名" CssClass="col-xs-12"></asp:TextBox>

                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
        </li>
    </ul>
    <script>
        function cint2(obj) {
            if ($.isNumeric(obj)) {
                return parseInt(obj);
            } else {
                return 0;
            }
        }
        function plus(a) {

            var a1 = cint2($("#ContentPlaceHolder1_GV_C3_" + a).val().replace(/\,/g, ""));
            alert(a1);
            $("#ContentPlaceHolder1_GV_C3_" + a).text(Math.round(a1 - 1));

        }
        function minus(a) {
            var a1 = cint2($("#ContentPlaceHolder1_GV_C3_" + a).val().replace(/\,/g, ""));
            alert(a1);
            $("#ContentPlaceHolder1_GV_C3_" + a).text(Math.round(a1 + 1));
        }

    </script>
</asp:Content>

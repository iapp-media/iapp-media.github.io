<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Car.aspx.cs" Inherits="MiniStore.Buy_Car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row1 {
            border: 1px solid #000;
            float: left;
            padding: 2px 2px 2px 2px;
            width: 100%;
        }

        .col2 {
            margin: 0 0 0 45px;
            border: 1px solid red;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 100%; height: 100%">
        <h1>我的購物車</h1>
        <div>
            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" EnableTheming="True" DataKeyNames="ItemID" BorderStyle="Solid" Width="100%" OnRowDataBound="GV_RowDataBound" OnRowCommand="GV_RowCommand">
                <Columns> 
                    <asp:BoundField DataField="Product_Name" HeaderText="商品名稱">
                        <ItemStyle CssClass="gv_row" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="單價" HtmlEncode="false" DataFormatString="{0:#,##0.##}">
                        <ItemStyle CssClass="gv_row" Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AMT" HeaderText="數量">
                        <ItemStyle CssClass="gv_row" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" HeaderText="總價">
                        <ItemStyle CssClass="gv_row" Width="70px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="CN" HeaderText="" Text="修改">
                        <ItemStyle CssClass="gv_row" HorizontalAlign="Center" Width="30px" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="DELE" HeaderText="" Text="刪除">
                        <ItemStyle CssClass="gv_row" HorizontalAlign="Center" Width="30px" />
                    </asp:ButtonField>
                </Columns>

            </asp:GridView>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
        </div>
        <div>
            <div class="col-xs-12 libor paytheway">
                <label for="" class="col-xs-6">付款方式</label>
                <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control">
                    <asp:ListItem Text="面交" Value="1"></asp:ListItem>
                    <asp:ListItem Text="7-11 ibon" Value="2"></asp:ListItem>
                    <asp:ListItem Text="銀行轉帳" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-12 libor sendtheway">
                <label for="" class="col-xs-6">寄送方式</label>
                <asp:DropDownList ID="DL_Delivery" runat="server" CssClass="form-control">
                    <asp:ListItem Text="面交自取" Value="1"></asp:ListItem>
                    <asp:ListItem Text="7-11" Value="2"></asp:ListItem>
                    <asp:ListItem Text="寄送到府" Value="3"></asp:ListItem>
                </asp:DropDownList>
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


        <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Confirm_Click" />





    </div>



</asp:Content>

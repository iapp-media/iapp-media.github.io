<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Cust_Mana.aspx.cs" Inherits="StoreMana.Cust_Mana" %>

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
 <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx?com=1" style="color: white">社群力排行</a></li>
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx" style="color: white">客戶列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx?act=1" style="color: white">活動力排行</a></li>
            </ul>
        </div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">　
                <div class="row">
                    <div class="col-xs-12">
                        <div>篩選</div>
                       <div>年</div>
                        <asp:DropDownList ID="DLYY" runat="server" CssClass="form-control col-xs-5">
                            <asp:ListItem>104</asp:ListItem>
                            <asp:ListItem>105</asp:ListItem>
                        </asp:DropDownList> 
                        <div>月份</div>
                        <asp:DropDownList ID="DLMM" runat="server" CssClass="form-control col-xs-5">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList> 
                         

                        <asp:Button ID="BT_Search" runat="server" Text="查詢" OnClick="BT_Search_Click" CssClass="btn btn-warning col-xs-5 " />
                    </div>
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                                <div class="row1">
                                    <div class="col2">客戶Email</div>
                                    <div class="col2">姓名</div>
                                   
                                </div> 
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("Account")%>'></asp:Literal>
                                    </div>
                                    <div class="col2">
                                        <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                    </div>  
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>

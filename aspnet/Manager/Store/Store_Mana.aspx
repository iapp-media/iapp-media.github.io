<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store_Mana.aspx.cs" Inherits="Store_Store_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-body">
        <div class="page-title">
            <span class="title">店家管理</span>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GV" runat="server" CssClass="datatable table table-striped" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="True" PageSize="20" OnRowDataBound="GV_RowDataBound" OnRowCommand="GV_RowCommand" DataKeyNames="SInfo_ID">
                                    <Columns>
                                        <asp:BoundField DataField="Store_Name" HeaderText="商店名稱" />
                                        <asp:BoundField DataField="Lv" HeaderText="會員等級" />
                                        <asp:BoundField DataField="Store_Cate" HeaderText="商店類型" />
                                        <asp:BoundField DataField="CtOrders" HeaderText="(本月)訂單數量" />
                                        <asp:BoundField DataField="pageview" HeaderText="商店瀏覽數" />
                                        <asp:BoundField DataField="CtProduct" HeaderText="商品數量" />
                                        <asp:ButtonField ButtonType="Button" CommandName="CN" Text="檢視更多" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


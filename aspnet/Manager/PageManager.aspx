<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="PageManager.aspx.cs" Inherits="PageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              <div class="side-body">
                    <div class="page-title">
                        <span class="title">頁面資料</span>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-body">

    
        <asp:Button ID="Btn" runat="server" Text="新增" OnClick="Btn_Click" />
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Page_Name" HeaderText="Page_Name" />
            <asp:BoundField DataField="Theme_ID" HeaderText="主題_ID" />
            <asp:BoundField HeaderText="編輯類型" DataField="EditStat" />
            <asp:BoundField DataField="URL" HeaderText="URL" />
            <asp:BoundField DataField="Img01" HeaderText="左邊用Page小圖:" />
            <asp:BoundField DataField="Img01_b" HeaderText="大圖1" />
            <asp:BoundField DataField="Img02_b" HeaderText="大圖2" />
            <asp:BoundField DataField="Img03_b" HeaderText="大圖3" />
            <asp:BoundField DataField="h1" HeaderText="文字1" />
            <asp:BoundField DataField="h2" HeaderText="文字2" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="修改" />
            <asp:ButtonField ButtonType="Button" CommandName="Del" Text="刪除" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
<asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>




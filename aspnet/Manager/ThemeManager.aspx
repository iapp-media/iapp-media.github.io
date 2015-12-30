<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThemeManager.aspx.cs" Inherits="ThemeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="side-body">
                    <div class="page-title">
                        <span class="title">主題管理</span>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-body">
  
        <asp:Button ID="Btn" runat="server" Text="新增" OnClick="Btn_Click" />
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Theme_Name" HeaderText="Theme_Name" />
            <asp:BoundField DataField="FoderName" HeaderText="存放資料夾名稱" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="修改" />
            <asp:ButtonField ButtonType="Button" CommandName="Del" Text="刪除" />
            <asp:ButtonField CommandName="UploadFiles" Text="上傳資料" />
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



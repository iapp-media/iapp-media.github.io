<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Company_Mana.aspx.cs" Inherits="Company_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-body">
        <div class="page-title">
            <span class="title">廠商管理</span>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-body">
     
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                  
                    <a href="Company_Add.aspx" target="_self" > 新增廠商</a>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GV" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound" AllowPaging="true">
                            <Columns> 
                                <asp:BoundField DataField="Name" HeaderText="廠商名稱" />
                                <asp:BoundField DataField="ACC" HeaderText="帳號" />
                                <asp:BoundField DataField="BossName" HeaderText="負責人" />
                                <asp:BoundField DataField="Tel" HeaderText="連絡電話" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:ButtonField ButtonType="Button" CommandName="CN" Text="修改" />
                                <asp:ButtonField ButtonType="Button" CommandName="DEL" Text="刪除" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
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




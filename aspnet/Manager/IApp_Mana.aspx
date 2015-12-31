<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="IApp_Mana.aspx.cs" Inherits="IApp_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                       <div class="side-body">
                    <div class="page-title">
                        <span class="title">店家管理</span>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-body">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">IApp管理</h1>

        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    IApp管理
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GV" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound" AllowPaging="true">
                            <Columns>
                                <asp:BoundField DataField="User_Name" HeaderText="使用者名稱" />
                                <asp:BoundField DataField="Theme_ID" HeaderText="主題" />
                                <asp:BoundField DataField="App_Name" HeaderText="iApp名稱" />
                                <asp:BoundField DataField="App_Cover" HeaderText="封面圖" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Couple_list.aspx.cs" Inherits="Wedding.Couple_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">客戶列表</h1>

        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    客戶列表
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GV" AutoGenerateColumns="False" runat="server" CssClass="table table-hover" DataKeyNames="IDNo">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="姓名" />
                                <asp:BoundField DataField="Tel" HeaderText="電話" />
                                <asp:BoundField DataField="Email" HeaderText="EMail" />
                                <asp:BoundField DataField="CreateDate" HeaderText="註冊日期" HtmlEncode="false" DataFormatString="{0:d}" />
                                  <asp:BoundField DataField="IDNu" HeaderText="驗證碼" />
                                <%--                 <asp:ButtonField ButtonType="Button" CommandName="CN" Text="修改" />--%>
                            </Columns>
                        </asp:GridView> 
                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
    </div>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
</asp:Content>

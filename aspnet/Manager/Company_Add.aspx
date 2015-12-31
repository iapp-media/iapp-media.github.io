<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Company_Add.aspx.cs" Inherits="Company_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-body">
        <div class="page-title">
            <span class="title">新增廠商</span>

            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-body"> 
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <%--                            <div class="form-group">
                                <label>主題</label>
                                <asp:DropDownList ID="DL_Theme" runat="server" class="form-control"></asp:DropDownList>
                            </div>--%>
                                                <div class="form-group">
                                                    <label>帳號</label>
                                                    <asp:TextBox ID="T_ACC" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>密碼</label>
                                                    <asp:TextBox ID="T_PassWord" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>公司名稱</label>
                                                    <asp:TextBox ID="T_Company" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>負責人</label>
                                                    <asp:TextBox ID="T_BossName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>地址</label>
                                                    <asp:TextBox ID="T_Addr" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>電話</label>
                                                    <asp:TextBox ID="T_Tel" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>傳真</label>
                                                    <asp:TextBox ID="T_FAX" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <asp:Button ID="BT_Send" runat="server" Text="送出" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Send_Click" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


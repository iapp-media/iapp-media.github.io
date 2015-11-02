<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Couple_Add.aspx.cs" Inherits="Wedding.Couple_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">新增客戶</h1>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>
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
                                <label>姓名</label>
                                <asp:TextBox ID="T_Name" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>電話</label>
                                <asp:TextBox ID="T_Tel" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>地址</label>
                                <asp:TextBox ID="T_Addr" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="T_Email" runat="server" CssClass="form-control"></asp:TextBox>
                            </div> 
                        </div>
                        <asp:Button ID="BT_Send" runat="server" Text="送出" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Send_Click" />

                    </div>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>

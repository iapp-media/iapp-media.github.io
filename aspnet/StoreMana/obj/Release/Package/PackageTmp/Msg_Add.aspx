<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Msg_Add.aspx.cs" Inherits="StoreMana.Msg_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4"> 
            <div class="list-group"> 
                <div class="list-group-item">
                    <div class="row"> 
                        <div class="col-xs-12">
                            <asp:TextBox ID="TB_Qen" runat="server" ReadOnly="true" Class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-12">
                              <asp:TextBox ID="TB_Ans" runat="server" Class="form-control" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <asp:Button ID="BT_Confirm" runat="server" Text="回覆" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Confirm_Click" />
                </div>
             </div></div></div>
</asp:Content>

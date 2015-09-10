<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="MessageBoard.aspx.cs" Inherits="MiniStore.MessageBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
            <form id="Form1" runat="server">
                <ul class="list-group">
                  <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ul>

                <div class="navbar-fixed-bottom">
                    <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4" style="padding-bottom:10px;padding-left:30px;padding-right:30px;">
                        <asp:TextBox ID="TB_Cont" class="form-control" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="Bt_Leave" runat="server" Text="Leave" CssClass="btn btn-default btn-lg btn-block" OnClick="Bt_Leave_Click" />
                    </div>
                </div>
                
            </form>       
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
</asp:Content>

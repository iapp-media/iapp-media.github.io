<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MiniStore.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
            <form id="Form1" runat="server">

                <div class="row">
                  <div class="col-xs-12">
                    <div class="input-group">
                      <asp:TextBox ID="TB_Cont" runat="server" class="form-control"></asp:TextBox>
                      <span class="input-group-btn">
                        <asp:Button ID="BT_Search" class="btn btn-default" runat="server" Text="Go!" OnClick="BT_Search_Click" />
                      </span>
                    </div><!-- /input-group -->
                  </div><!-- /.col-lg-6 -->
                </div><!-- /.row -->

                <%--<ul class="list-group">
                  <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ul>--%>
               
<%--                <div class="row">
                  <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>--%>

                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                 
            </form>       
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
    <script type="text/javascript" src="scripts/holder.js"></script>
</asp:Content>

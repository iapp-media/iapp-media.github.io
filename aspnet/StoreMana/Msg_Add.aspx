<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Msg_Add.aspx.cs" Inherits="StoreMana.Msg_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="buydivmove">
        <div class="productcare col-xs-12">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12 libor Reply Issue">
                        <asp:TextBox ID="TB_Qen" runat="server" ReadOnly="true" CssClass="spansizebig"></asp:TextBox>
                        <asp:TextBox ID="TB_Ans" runat="server" Class="form-control" Rows="5"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" Text="回覆" CssClass="btn btn-warning col-xs-2 sendcareButtom" OnClick="BT_Confirm_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
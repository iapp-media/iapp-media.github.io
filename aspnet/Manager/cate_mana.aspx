<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="cate_mana.aspx.cs" Inherits="cate_mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">商品類別管理</h1>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">

                        <table border="1" style="width: 100%">
                            <tr>
                                <td style="width: 100px">
                                    <asp:TreeView ID="View1" runat="server" ImageSet="Simple" NodeIndent="10" ExpandDepth="0" OnSelectedNodeChanged="View1_SelectedNodeChanged">
                                        <ParentNodeStyle Font-Bold="False" />
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px"
                                            VerticalPadding="0px" />
                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                                            NodeSpacing="0px" VerticalPadding="0px" />
                                    </asp:TreeView>

                                    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                                        <table style="width: 100%" class="form_tb">
                                            <tr>
                                                <td class="form_LC">類別名稱：</td>
                                                <td>
                                                    <asp:TextBox ID="TName" runat="server" BorderColor="#999999"
                                                        BorderStyle="Solid" BorderWidth="1px" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="TrPayment" visible="false">
                                                <td class="form_LC">預設付款方式：</td>
                                                <td>
                                                    <asp:CheckBoxList ID="CBLPayment" runat="server"></asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="TrDelivery" visible="false">
                                                <td class="form_LC">預設取貨方式：</td>
                                                <td>
                                                  <asp:CheckBoxList ID="CBLDelivery" runat="server"></asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="form_LC">排序：</td>
                                                <td>
                                                    <asp:TextBox ID="TSort" runat="server" BorderColor="#999999"
                                                        BorderStyle="Solid" BorderWidth="1px" Width="60px">0</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="form_LC">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="BAdd" runat="server" Text="新增" Visible="False" OnClick="BAdd_Click" />
                                                    <asp:Button ID="BEdit" runat="server" Text="修改儲存" Visible="False" OnClick="BEdit_Click" />
                                                    <asp:Button ID="BDel" runat="server" Text="刪除" Visible="False" OnClick="BDel_Click" />
                                                    <asp:Literal ID="RefNO" runat="server" Visible="False"></asp:Literal>
                                                    <asp:Literal ID="strNo" runat="server" Visible="False"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


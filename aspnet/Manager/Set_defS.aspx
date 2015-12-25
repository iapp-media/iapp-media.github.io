<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="Set_defS.aspx.cs" Inherits="Set_defS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
    
    <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
     <asp:Literal ID="LTitle" runat="server" Visible="false"></asp:Literal>
     <asp:Literal ID="LColName" runat="server" Visible="false"></asp:Literal>

    <asp:Button ID="BTpay" runat="server" Text="付款方式" OnClick="BTpay_Click"   />
    <asp:Button ID="BTDeli" runat="server" Text="運送方式" OnClick="BTDeli_Click"  />
    <asp:Button ID="BTOrder" runat="server" Text="訂單狀態" OnClick="BTOrder_Click"   /> <br />
      <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idno" EnableTheming="True" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound"   Width="100%"  >
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="CN" HeaderText="" Text="修改">
                                <ItemStyle CssClass="gv_row" HorizontalAlign="Center" Width="30px" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Button" CommandName="DELE" HeaderText="" Text="刪除">
                                <ItemStyle CssClass="gv_row" HorizontalAlign="Center" Width="30px" />
                            </asp:ButtonField>
                       
                            <asp:TemplateField HeaderText="*狀態">
                                <ItemTemplate>
                                    <asp:TextBox ID="TStatus" runat="server" Text='<%# Bind("Status") %>' ></asp:TextBox>
                                </ItemTemplate>
                                 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="*Memo">
                                <ItemTemplate>
                                    <asp:TextBox ID="TMemo" runat="server" Text='<%# Bind("Memo") %>' ></asp:TextBox>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                           
                        </Columns>
                        <PagerStyle BackColor="White" CssClass="gv_pager" ForeColor="#000066" HorizontalAlign="Left" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" CssClass="gv_head" Font-Bold="True" ForeColor="White" />
                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
</asp:Content>


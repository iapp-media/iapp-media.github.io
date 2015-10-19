<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Msg_Mana.aspx.cs" Inherits="StoreMana.Msg_Mana" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4"> 
            <div class="list-group"> 
                <div class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">
                            <p>回覆類別</p>
                        </div>
                        <div class="col-xs-8">
                            <asp:DropDownList class="form-control" ID="DL" runat="server"> 
                                <asp:ListItem Value="0">尚未回覆</asp:ListItem>
                                     <asp:ListItem Value="1">已回覆</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="row">
                        <div class="col-xs-4">
                            <p>商品名稱</p>
                        </div>
                        <div class="col-xs-8">
                            <asp:DropDownList class="form-control" ID="DL_Pname" runat="server">   
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <asp:Button ID="BT_Search" runat="server" Text="Search" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Search_Click" />
                </div>
             </div>
 <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate> 
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row1">
                        <div class="col2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Question")%>'></asp:Literal>
                               <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("agoday")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Ans")%>'></asp:Literal>
                        </div> 
                          <div class="col2">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                     回覆
                            </asp:HyperLink>
                        </div>
                    </div> 
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>

                    </div>
 

                </div> 
          

</asp:Content>

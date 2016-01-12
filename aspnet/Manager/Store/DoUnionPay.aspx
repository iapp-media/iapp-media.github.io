<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DoUnionPay.aspx.cs" Inherits="Store_DoUnionPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <div class="side-body">
                    <div class="page-title">
                        <span class="title">銀聯卡串接</span>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-body"> 
                                     <label   class="col-xs-2 control-label">店家STORE_ID:</label>
                                     <asp:TextBox ID="TBSID" runat="server"></asp:TextBox>
                                    <div class="sub-title">作廢</div>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="送出" OnClick="Button1_Click" />
                                    <div class="sub-title">取消</div>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button2" runat="server" Text="送出" OnClick="Button2_Click" />
                                    <div class="sub-title">查詢</div>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button3" runat="server" Text="送出" OnClick="Button3_Click" />

                                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


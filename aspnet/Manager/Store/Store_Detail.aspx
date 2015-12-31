<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store_Detail.aspx.cs" Inherits="Store_Store_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="side-body">
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-header">
                        <div class="card-title">
                            <div class="title">店家資訊</div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">商店名稱</label>
                                <div class="col-xs-10">
                                    <asp:TextBox ID="TB_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                               <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">提供付款方式</label>
                                <div class="col-xs-10">
                                    <asp:DropDownList ID="DL" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            


                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <div class="checkbox3 checkbox-round checkbox-check checkbox-light">
                                        <input type="checkbox" id="checkbox-10">
                                        <label for="checkbox-10">
                                            Remember me 
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <button type="submit" class="btn btn-default">Sign in</button>
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


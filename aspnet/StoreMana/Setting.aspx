<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="StoreMana.Setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- 參數設定 -->
            <div class="allmodify">
                <ul class="buydivmove mart10">
                    <li class="modify col-xs-12">
                        <div class="col-xs-12 insidecare">
                            <div class="row">
                                <div class="col-xs-12 libor paynumber">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox"> 搖一搖
                                        </label>
                                    </div>
                                </div>
                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">商品類別</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">商品狀態</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">付款方式</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 libor paynumber">
                                    <label for="" class="col-xs-6">寄送方式</label>
                                    <div class="col-lg-6">
                                        <div class="input-group">
                                            <input type="text" class="form-control magclose">
                                            <span class="input-group-btn"><button class="btn btn-default" type="button">+</button></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <!-- 參數設定 end -->
</asp:Content>

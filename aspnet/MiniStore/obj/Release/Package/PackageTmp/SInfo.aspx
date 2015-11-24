<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="SInfo.aspx.cs" Inherits="MiniStore.SInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 libor ContentTop">
        <a href="Default.aspx?SN=OfficACC"><img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2"></a> 
        <h1 class="col-xs-10">StudioA</h1>
    </div>
    
        <div class="Mapbox">
            <div id="map"></div>
        </div>
        <div class="colorBG"></div>

    <div class="col-xs-12 promana" id="SinfoPage">
        <div class="row">
            <div class="productcare">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor productsinside">
                            <div id="SinfoTop">
                                <img src="img/user_store.png" alt="Alternate Text">
                            </div>
                            <div class="ListT">
                                <span class="glyphicon glyphicon-tags" aria-hidden="true"></span>
                                <div><span>3C</span>/<span>蘋果優質經銷商(Apple Premium Reseller)</span></div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-10">
                                    <p class="BoxLeft TBC">111台北市士林區文林路138號</p>
                                </div>
                                <div class="col-xs-2 RightBTN" id="Mapclick">
                                    <span class="glyphicon glyphicon-map-marker" aria-hidden="true"></span>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-10">
                                    <p class="BoxLeft TBC">02-28811361</p>
                                </div>
                                <div class="col-xs-2 RightBTN" onclick="location.href='tel:02-28811361'">
                                    
                                    <span class="glyphicon glyphicon-earphone" aria-hidden="true"></span>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft TRBC">公休日</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight">
                                        無
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 Listarea">
                                <div>
                                    <p class="BoxLeft TRBC">營業時間</p>
                                </div>
                                <div>
                                    <textarea>
                                        星期二	14:00–22:30
                                        星期三	14:00–22:30
                                        星期四	14:00–22:30
                                        星期五	14:00–22:30
                                        星期六	14:00–22:30
                                        星期日	14:00–22:30
                                        星期一	14:00–22:30
                                    </textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

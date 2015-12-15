<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="SInfo.aspx.cs" Inherits="MiniStore.SInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12 libor ContentTop">
<%--        <a href="Default.aspx?SN=OfficACC">
            <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2"/></a>--%>
        <asp:Literal ID="LSinfo" runat="server"></asp:Literal>
        <h1 class="col-xs-10">微店資訊</h1>
    </div>
    <!-- Google Map -->
    <div class="Mapbox">
        <div id="map"></div>
    </div>
    <!-- end Google Map -->
    <div class="colorBG"></div>
    <div class="col-xs-12 promana" id="SinfoPage">
        <div class="row">
            <div class="productcare"> 
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor productsinside">
                            <div id="SinfoTop">
                                <asp:Image ID="Image1" runat="server" />
                            <%--    <img src="img/user_store.png" alt="Alternate Text" />--%>
                            </div>
                            <div class="ListT">
                                <span class="glyphicon glyphicon-tags" aria-hidden="true"></span>
                                <div><span>
                                    <asp:Literal ID="L_SCate" runat="server"></asp:Literal></span>/<span>
                                        <asp:Literal ID="L_SName" runat="server"></asp:Literal></span></div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-10">
                                    <p class="BoxLeft TBC">
                                        <asp:Label ID="L_place" runat="server" Text="Label"></asp:Label>
                                        
                                    </p>
                                </div>
                                <div class="col-xs-2 RightBTN" id="Mapclick">
                                    <span class="glyphicon glyphicon-map-marker" aria-hidden="true"></span>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-10">
                                    <p class="BoxLeft TBC">
                                        <span id="phoneNUM">
                                        <asp:Literal ID="LTel" runat="server"></asp:Literal>
                                            </span>
                                    </p>
                                </div>
                                <div class="col-xs-2 RightBTN" id="phoneAttr" onclick="location.href='tel:02-28811361'">

                                    <span class="glyphicon glyphicon-earphone" aria-hidden="true"></span>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft TRBC">公休日</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight">
                                        <asp:Label ID="L_DayOff" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 Listarea">
                                <div>
                                    <p class="BoxLeft TRBC">營業時間</p>
                                </div>
                                <div>
                                    <asp:Label ID="L_POTime" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
   
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UrlRefer.aspx.cs" Inherits="Store_UrlRefer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-body">
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-header">
                        <div class="card-title">
                            <div class="title">瀏覽統計</div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-xs-12">
                            <div class="form-inline">
                                <div class="form-group col-xs-4">
                                    <label>店家名稱:</label>
                                    <asp:TextBox ID="TBName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-xs-4">
                                    <label>日期起:</label>
                                    <div id="datepicker" class="input-group date" data-date-format="yyyy/mm/dd">
                                        <asp:TextBox ID="TBSDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                       
                                </div> 
                                <div class="form-group col-xs-4">
                                    <label>日期迄:</label>
                                    <div class="input-group date" data-date-format="yyyy/mm/dd">
                                        <asp:TextBox ID="TBEDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                       
                                </div> 
                                 <asp:Button ID="BTSearch" runat="server" Text="查詢" CssClass="btn btn-primary col-xs-2 " OnClick="BTSearch_Click"  /> 
                            </div>  
                        </div>
                        <div class="col-xs-12">
                            瀏覽人數：<asp:Label ID="LB1" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="50">
                                <Columns>
                                    <asp:BoundField DataField="fromurl" HeaderText="FromUrl" />
                                    <asp:BoundField DataField="tourl" HeaderText="ToUrl" />
                                    <asp:BoundField DataField="date" HeaderText="日期" />
                                    <asp:BoundField DataField="IP" HeaderText="IP" />

                                    <asp:BoundField DataField="SName" HeaderText="To店家" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <script src="../js/jquery-2.1.4.min.js"></script>
    
    <script src="../js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">
        var ToDD = new Date();
         
        //UTCDate(ToDD.getFullYear(), ToDD.getMonth(), ToDD.getDate());
        $(function () {
            $(".date").datepicker({
                autoclose: true,
                todayHighlight: true
            }).datepicker('update', new Date());
        });
        $(function () {
            $("#datepicker").datepicker({
                autoclose: true,
                todayHighlight: true
            }).datepicker('update', '' + ToDD.getFullYear() + '/' + ToDD.getMonth() + 1 + '/01');
        });  
    </script>


</asp:Content>


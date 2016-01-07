<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store_Detail.aspx.cs" Inherits="Store_Store_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .message-list2 {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }

            .message-list2 > li {
                border-bottom: 1px dotted #EEE;
                padding: 8px;
            }

                .message-list2 > li > .message-block {
                    min-height: 60px;
                }

                    .message-list2 > li > .message-block .username {
                        font-size: 12px;
                        font-weight: bold;
                    }

                    .message-list2 > li > .message-block .message-datetime {
                        font-size: 10px;
                        color: #AAA;
                    }

                    .message-list2 > li > .message-block .message {
                        font-size: 12px;
                    }

                .message-list2 > li .profile-img {
                    width: 60px;
                    height: 60px;
                }
    </style>
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
                                <label for="inputEmail3" class="col-xs-2 control-label">商店名稱:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Name" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">會員等級:
                                    <asp:Literal ID="L_lv_id" runat="server" Visible="false"></asp:Literal>
                                </label>
                                <div class="col-xs-3">
                                    <asp:DropDownList ID="DL_Lv" runat="server" CssClass="form-control"> 
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">商店類別:
                                    <asp:Literal ID="L_scate_id" runat="server" Visible="false"></asp:Literal>
                                </label>
                                <div class="col-xs-3">
                                    <asp:DropDownList ID="DL_Cate" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">選購情境:
                                    <asp:Literal ID="L_view_id" runat="server" Visible="false"></asp:Literal>
                                </label>

                                <div class="col-xs-3">
                                    <asp:DropDownList ID="DL_View" runat="server" CssClass="form-control"> 
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">提供付款方式:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Payment" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">提供運送方式:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Delivery" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">銀行名稱:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Bank_Name" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">銀行代碼:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Bank_No" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">受款帳號:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Bank_ACC" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">受款戶名:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Bank_ACName" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">連絡人:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_CEOName" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">聯絡電話:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_TEL" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">聯絡地址:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;">
                                        <asp:Literal ID="TB_Addr" runat="server"></asp:Literal>
                                    </label>
                                </div>
                            </div>
                               <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">備註:</label>
                                <div class="col-xs-10">
                                    <label class="control-label" style="font-weight: 100;width:100%" >
                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"  CssClass="form-control" Width="60%" Height="200px" ></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                               <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">附件:</label>
                                <div class="col-xs-10"> 
                                    <asp:FileUpload ID="FU" runat="server" />
                                    <asp:Button ID="BTFile" runat="server" Text="上傳" CssClass="btn btn-primary" OnClick="BTFile_Click"   />
                                        <asp:CheckBoxList ID="Filelist" runat="server"></asp:CheckBoxList> 
                                    
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-xs-2">
                                    <asp:Button ID="BT_info" runat="server" Text="修改" CssClass="btn btn-primary col-xs-11"  OnClick="BT_info_Click"/> 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-7">
                                    <div class="panel fresh-color panel-success" style="border: none">
                                        <div class="panel-heading">修改記錄</div>
                                        <div class="panel-body">
                                            <ul class="message-list2">
                                                <asp:Literal ID="L_info_Record" runat="server"></asp:Literal>   
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                      <div class="modal fade bs-example-modal-lg" id="modalInfo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title" id="H1">修改記錄</h4>
                                                    </div>
                                                    <div class="modal-body">
 <ul class="message-list2">
                                                <asp:Literal ID="L_info_ALL" runat="server"></asp:Literal>   
                                            </ul>                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                       <%-- <button type="button" class="btn btn-info" data-dismiss="modal">OK</button>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                            <div class="sub-title">費率計算</div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-xs-2 control-label">處理費率:</label>
                                <div class="col-xs-1">
                                    <h4>
                                        <asp:Label ID="L_Fee" runat="server" Text=""></asp:Label>
                                        %</h4> 
                                </div>
                                <div class="col-xs-9">
                                    <!-- Button trigger modal -->
                                    <button type="button" class="btn btn-primary btn-warning" data-toggle="modal" data-target="#modalWarning">
                                        修改費率
                                    </button>
                                    <!-- Modal -->
                                    <div class="modal fade modal-warning" id="modalWarning" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="myModalLabel">處理費修改</h4>
                                                </div>
                                                <div class="modal-body">

                                                     
                                                                                <div class="card-body">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <label  >處理費率:</label>
                                 　          <asp:TextBox ID="TB_Fee" runat="server" type="number" CssClass="form-control" ></asp:TextBox>% 
                                        </div> 
                                    </div>
                                                                                                                        <div class="form-inline">
                                        <div class="form-group">
                                            <label  >備&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 註:</label>
                                 　          <asp:TextBox ID="TB_Memo" runat="server" type="number" CssClass="form-control" TextMode="MultiLine" Width="405px" Height="200px"></asp:TextBox> 
                                        </div> 
                                    </div>
                                </div> 
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> 
                                                    <asp:Button ID="BT_save" runat="server" Text="Save" CssClass="btn btn-warning" OnClick="BT_save_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-7">
                                    <div class="panel fresh-color panel-success" style="border: none">
                                        <div class="panel-heading">修改記錄</div>
                                        <div class="panel-body">
                                            <ul class="message-list2">
                                                <asp:Literal ID="L_Fee_Record" runat="server"></asp:Literal>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>



                             



                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <a href="Store_Mana.aspx" class="btn btn-primary">回上一頁
                                   </a>
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


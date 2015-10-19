<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="StoreMana.Mini.Product_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 建檔修改 -->
    <div class="allmodify">
        <ul class="buydivmove mart10">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品類別</label>
                            <asp:DropDownList class="form-control" ID="DL_Cate" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor status">
                            <label for="" class="col-xs-6">商品圖片</label>
                           <div style="display:none;">
                               <%-- 不要的 --%>
                            <div class="form-group">
                                <div style="margin: 0 0 0 300px; width: 500px">
                                    <!-- 輪播圖 -->
                                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                        <!-- Wrapper for slides -->
                                        <div class="carousel-inner" role="listbox">
                                            <asp:Literal ID="L" runat="server"></asp:Literal>
                                        </div>
                                        <!-- Controls -->
                                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div> 
                                </div> 
                            </div>
                           </div>
                            <div id="slider" class="col-xs-6">
                                <div class="control_next glyphicon glyphicon-chevron-right"></div>
                                <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                                <ul>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" />

                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter">
                                    </li>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" />
                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter">
                                    </li>

                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" />
                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter">
                                    </li>

                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" />
                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter">
                                    </li>
                                    
                                </ul>
                            </div>
                            <%-- slider自動播放函式 --%>
                       <%-- <div class="slider_option">
                            <input type="checkbox" id="checkbox">  
                        </div>--%>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
        <p class="text-center fonts">填寫資料</p>
        <ul class="buydivmove">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品名稱</label>
                            <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server" placeholder="限30個字以內"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">價格</label>
                            <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">數量</label>
                            <asp:TextBox ID="TB_qty" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品說明</label>
                            <asp:TextBox ID="TB_Description" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品規格</label>
                            <asp:TextBox ID="TB_Dimension" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label class="col-xs-6">付款方式</label>
                           <div style="display:none">
                               <asp:CheckBoxList ID="CB_Payment" runat="server"    RepeatDirection="Horizontal" RepeatLayout="Flow"  > 
                               </asp:CheckBoxList>
                           </div>
                            <div class="checkbox col-xs-4 florichebox">
                                <label>
                                    <input type="checkbox">
                                    面交
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    7-11 ibon
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    銀行轉帳
                                </label>
                            </div>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label  class="col-xs-6">寄送方式</label>
                            <div style="display:none">
                               <asp:CheckBoxList ID="CB_Delivery" runat="server"    RepeatDirection="Horizontal" RepeatLayout="Flow"  >        
                               </asp:CheckBoxList>
                           </div>  
                             <div class="checkbox col-xs-4 florichebox">
                                <label>
                                    <input type="checkbox">
                                    面交自取
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    7-11
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    寄送到府
                                </label>
                            </div>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">備註</label>
                            <asp:TextBox ID="TB_Memo" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <asp:Button ID="BT_Create" runat="server" Text="Create" CssClass="btn btn-primary btn-lg btn-block sendcareButtom" OnClick="BT_Create_Click" />
        <asp:Button ID="BT_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-lg btn-block sendcareButtom" OnClick="BT_Cancel_Click" />
            </li>
        </ul>
       

        <asp:Literal ID="LPID" runat="server" Visible="false"></asp:Literal> 
    </div> 
    <script>
        $('.carousel').carousel({
            interval: false
        })

        function Iframeload() { 
            window.location.reload("Product_Add.aspx"); 
        }
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="IApp_Add.aspx.cs" Inherits="IApp_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <title>IApp_ADD</title>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="Server">


    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">(channel)新增IApp</h1>
                <asp:Literal ID="L_APPID" runat="server" Visible="false"></asp:Literal>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
           <%--     <div class="panel-heading">
                    Iapp_add
                       <asp:Literal ID="L_APPID" runat="server"></asp:Literal>
                </div>--%>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div>
                                <div class="form-group">
                                    <label>主題</label>
                                    <asp:DropDownList ID="DL_Theme" runat="server" class="form-control"></asp:DropDownList>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>APP_Name</label>
                                    <asp:TextBox ID="T_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>描述</label>
                                    <asp:TextBox ID="T_Memo" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>App_URL</label>
                                    <asp:TextBox ID="T_URL" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>是否發布</label>

                                    <asp:DropDownList ID="DL_IsPost" runat="server" class="form-control">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>置頂排序</label>
                                    <asp:TextBox ID="TSort" runat="server" CssClass="form-control">1</asp:TextBox>
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>封面圖</label>
                                    <asp:FileUpload ID="FU_cover" runat="server" Width="240px" />
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>Icon圖</label>
                                    <asp:FileUpload ID="FU_icon" runat="server" Width="240px" />
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <div class="form-group">
                                    <label>分享圖</label>
                                    <asp:FileUpload ID="FU_share" runat="server" Width="240px" />
                                    <%--<p class="help-block">Example block-level help text here.</p>--%>
                                </div>
                                <asp:Button ID="BT_Send" runat="server" Text="送出" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Send_Click"  />

                            </div>
                        </div>

                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->




</asp:Content>


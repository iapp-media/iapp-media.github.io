
Partial Class Mana_Default
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            DDLin()

            If IsNumeric(Request.QueryString("s")) Then
                'str = "select * from Product where Store_ID=" & Request.QueryString("s") & " order by Creat_Date desc"
                str = "select Product.IDNo,Product.Product_Name,Product.Price,Product.Creat_Date,Product_Img.FilePath,Store.Store_Name from Product,Product_Img,Store " & _
                    "where Product.IDNo = Product_Img.Product_ID and Store.IDNo = Product.Store_ID and Product.Store_ID=" & Request.QueryString("s") & " and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID ) order by Creat_Date desc"
                SD.ConnectionString = Main.ConnStr
                SD.SelectCommand = str
                GV.DataSourceID = SD.ID

                ' 店名
                'str = "select store_name from store where IDNo=" & Request.QueryString("s") & ""
                'str = "select store_name from store where User_ID='" & Session("User_ID") & "'"
                'Dim SN As String = Main.Scalar(str)
                'If SN <> "" Then
                '    LTitle.Text = SN
                'End If

                '自己的店才顯示編輯選項()
                Dim dd As Data.DataTable = Main.GetDataSetNoNull("select * from store where IDNo='" & Request.QueryString("s") & "'")
                If dd.Rows.Count > 0 Then
                    'LTitle.Text = dd.Rows(0).Item("Store_name")
                    If dd.Rows(0).Item("User_ID") = Session("User_ID") Then
                        GV.Columns(3).Visible = True
                        'DM.Visible = True
                    End If
                End If

                'DM1.HRef = "Default.aspx?s=" & Request.QueryString("s") & ""
                'DM2.HRef = "orders_mana.aspx?s=" & Request.QueryString("s") & ""
                'DM3.HRef = ""
                'DM4.HRef = "message_mana.aspx?s=" & Request.QueryString("s") & ""
                'DM5.HRef = "store_mana.aspx?s=" & Request.QueryString("s") & ""

            End If
        End If
    End Sub

    Sub DDLin()
        str = "select Cate_Name,IDNo from Product_Cate where ref=-1 order by Cate_Name"
        Comm.FillDDP(DDL_Cate, str, "Cate_Name", "IDNo")
    End Sub

    Protected Sub BT_Search_Click(sender As Object, e As System.EventArgs) Handles BT_Search.Click
        L.Text = "select Product.IDNo,Product.Product_Name,Product.Price,Product.Creat_Date,Product_Img.FilePath,Store.Store_Name from Product,Product_Img,Store where Product.IDNo = Product_Img.Product_ID and Store.IDNo = Product.Store_ID"
        If TName.Text <> "" Then L.Text += " and Product.Product_Name= '" & TName.Text & "'"
        If DDL_Cate.SelectedValue <> "" Then L.Text += " and Product.Cate_ID= '" & DDL_Cate.SelectedValue & "'"
        L.Text += " and Product.Store_ID=" & Request.QueryString("s") & " order by Creat_Date desc"
        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
        'Response.Write(L.Text) '測試
    End Sub

    Protected Sub GV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GV.RowCommand
        Dim i As Integer = e.CommandArgument
        If e.CommandName = "CN" Then
            Response.Redirect("Product_Add.aspx?s=" & Request.QueryString("s") & "&p=" & GV.DataKeys(i).Item(0))
        End If
    End Sub

    Protected Sub BT_Add_Click(sender As Object, e As System.EventArgs) Handles BT_Add.Click
        Response.Redirect("Product_Add.aspx?s=" & Request.QueryString("s"))
    End Sub

    Protected Sub GV_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GV.RowDataBound
        If e.Row.RowIndex > -1 Then
            e.Row.Cells(0).Text = "<img height=""100"" width=""100"" src=""../" & e.Row.Cells(0).Text.ToString.Replace("\", "/") & """ />"
        End If
    End Sub
End Class

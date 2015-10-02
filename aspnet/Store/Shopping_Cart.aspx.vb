
Partial Class Shopping_Cart
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String
    Dim cookie As HttpCookie

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            cookie = Request.Cookies.Get("cart")

            ' 取購物車cookie
            If Not cookie Is Nothing Then
                Dim tmp As String() = cookie.Value.Split(",")
                str = "select Product.IDNo,Product.Product_Name,Product.Price,Product.Creat_Date,Product_Img.FilePath,Store.Store_Name " & _
                    "from Product,Product_Img,Store where Product.IDNo = Product_Img.Product_ID and Store.IDNo = Product.Store_ID and " & _
                    "product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID ) and product.idno in("
                For i As Integer = 0 To tmp.Length - 1
                    If i = tmp.Length - 1 Then
                        str += "'" & tmp(i) & "'"
                    Else
                        str += "'" & tmp(i) & "',"
                    End If
                Next
                str += ")"
            End If
        End If

        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = str
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub GV_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GV.RowDataBound
        If e.Row.RowIndex > -1 Then
            e.Row.Cells(0).Text = "<img height=""100"" width=""100"" src=""" & e.Row.Cells(0).Text.ToString.Replace("\", "/") & """ />"
        End If
    End Sub

    Protected Sub GV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GV.RowCommand
        Dim i As Integer = e.CommandArgument
        If e.CommandName = "CN" Then
            cookie = Request.Cookies.Get("cart")
            Dim tmp As String() = cookie.Value.Split(",")
            Array.Clear(tmp, i, 1)

            ' 重寫cookie，刪掉取消項目
            cookie.Values.Clear()

            str = "select Product.IDNo,Product.Product_Name,Product.Price,Product.Creat_Date,Product_Img.FilePath,Store.Store_Name " & _
                "from Product,Product_Img,Store where Product.IDNo = Product_Img.Product_ID and Store.IDNo = Product.Store_ID and " & _
                "product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID ) and product.idno in("

            For a As Integer = 0 To tmp.Length - 1
                If tmp(a) <> "" Then
                    str += "'" & tmp(a) & "',"
                    cookie.Value += "" & tmp(a) & ","
                End If
                'Response.Write(a & " " & tmp(a) & "<br/>")
            Next

            ' 去掉最後一個逗號
            cookie.Value = cookie.Value.Substring(0, cookie.Value.Length - 1)
            str = str.Substring(0, str.Length - 1)
            str += ")"

            Response.Write(cookie.Value)
            Response.Cookies.Add(cookie)

            SD.ConnectionString = Main.ConnStr
            SD.SelectCommand = str
            GV.DataSourceID = SD.ID

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Session("Store_ID") Then
            cookie = Request.Cookies.Get("cart")
            Dim tmp As String() = cookie.Value.Split(",")

            Dim DT As Data.DataTable = Main.GetDataSet("select * from Users where Account='" & Session("User_ID") & "'")
            If DT.Rows.Count > 0 Then

                str = "insert into orders(Customer_ID,Contact_ID,Contact_Name,tel,email,city,addr,store_ID,status,order_no) values('" & DT.Rows(0).Item("IDNo") & _
                        "','" & DT.Rows(0).Item("Account") & "','" & DT.Rows(0).Item("User_Name") & "','" & DT.Rows(0).Item("tel") & "','" & DT.Rows(0).Item("email") & _
                        "','" & DT.Rows(0).Item("city") & "','" & DT.Rows(0).Item("addr") & "','" & Request.QueryString("s") & "','1','" & comm.GetDateString(Now) & "')"
                If Main.NonQuery(str) Then





                Else
                    ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗，請檢查欄位是否均已填寫');</script>")
                End If

            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub
End Class

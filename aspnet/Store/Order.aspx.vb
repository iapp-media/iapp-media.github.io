
Partial Class Order
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsNumeric(Request.QueryString("c")) Then
            Literal2.Text = Request.QueryString("c")
        End If

        If IsNumeric(Request.QueryString("p")) Then
            str = "select * from product,Product_Img where product.IDNo = Product_Img.Product_ID and Product.IDNo = " & Request.QueryString("p") & " and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"
            Dim DT As Data.DataTable = Main.GetDataSet(str)
            If DT.Rows.Count > 0 Then
                imgPP.Src = DT.Rows(0).Item("FilePath").ToString.Replace("\", "/")
                Literal1.Text = DT.Rows(0).Item("Description") & " <br />" & DT.Rows(0).Item("Price")
                Literal4.Text = DT.Rows(0).Item("Price")
                Literal5.Text = Convert.ToString((CInt(Literal2.Text) * CInt(DT.Rows(0).Item("Price"))))
            End If
        End If

    End Sub

    Protected Sub BT_C_Click(sender As Object, e As System.EventArgs) Handles BT_C.Click

        If Session("Store_ID") Then
            If IsNumeric(Request.QueryString("p")) And IsNumeric(Request.QueryString("s")) Then

                Dim DT As Data.DataTable = Main.GetDataSet("select * from Users where Account='" & Session("User_ID") & "'")
                If DT.Rows.Count > 0 Then

                    str = "insert into orders(Customer_ID,Contact_ID,Contact_Name,tel,email,city,addr,store_ID,status,order_no) values('" & DT.Rows(0).Item("IDNo") & _
                        "','" & DT.Rows(0).Item("Account") & "','" & DT.Rows(0).Item("User_Name") & "','" & DT.Rows(0).Item("tel") & "','" & DT.Rows(0).Item("email") & _
                        "','" & DT.Rows(0).Item("city") & "','" & DT.Rows(0).Item("addr") & "','" & Request.QueryString("s") & "','1','" & comm.GetDateString(Now) & "')"
                    If Main.NonQuery(str) Then

                        ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');location.href='Product_Detail.aspx?p=" & Request.QueryString("p") & "'</script>")
                        'Dim Order_ID As Integer = Main.Scalar("select top 1 IDNo from orders where Contact_ID='" & DT.Rows(0).Item("Account") & "' order by IDNo DESC")
                        Dim DTO As Data.DataTable = Main.GetDataSet("select top 1 * from orders where Contact_ID='" & DT.Rows(0).Item("Account") & "' order by IDNo DESC")
                        Main.NonQuery("insert into Order_Content(Order_ID,Item_ID,Total,AMT,Price,Order_No) values('" & DTO.Rows(0).Item("IDNo") & "','" & Request.QueryString("p") & _
                                      "','" & Literal5.Text & "','" & Literal2.Text & "','" & Literal4.Text & "','" & DTO.Rows(0).Item("Order_No") & "')")
                    Else
                        ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗，請檢查欄位是否均已填寫');</script>")
                    End If
                End If
            End If
        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

End Class

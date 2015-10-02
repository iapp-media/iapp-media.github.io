Imports System.Data

Partial Class Product_Detail
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String
    Dim cookie As HttpCookie

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If IsNumeric(Request.QueryString("p")) Then
                str = "SELECT * FROM product,product_img where product.IDNo = product_img.Product_ID and product.idno = " & Request.QueryString("p") & ""
                Dim DT As DataTable = Main.GetDataSetNoNull(str)

                If DT.Rows.Count > 0 Then
                    For i As Integer = 0 To DT.Rows.Count - 1
                        Select Case i
                            Case "0"
                                img1.Src = DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                            Case "1"
                                img2.Src = DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                            Case "2"
                                img3.Src = DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                            Case "3"
                                img4.Src = DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                        End Select
                    Next

                    LTitle.Text = DT.Rows(0)("Product_Name")
                    L_ProductName.Text = DT.Rows(0)("Product_Name")
                    L_Price.Text = DT.Rows(0)("Price") & "元"
                    L_Payment.Text = DT.Rows(0)("Payment")
                    L_Delivery.Text = DT.Rows(0)("Delivery")
                    L_Dimension.Text = DT.Rows(0)("Dimension")
                    L_Description.Text = DT.Rows(0)("Description")
                    L_StoreID.Text = DT.Rows(0)("Store_ID")
                End If
                'Response.Write(str)   '測試
            End If

        End If
    End Sub

    Protected Sub BT_Buy_Click(sender As Object, e As System.EventArgs) Handles BT_Buy.Click
        Response.Redirect("Order.aspx?s=" & L_StoreID.Text & "&p=" & Request.QueryString("p") & "&c=" & DDL.SelectedValue & "")
    End Sub

    Protected Sub BT_Cart_Click(sender As Object, e As System.EventArgs) Handles BT_Cart.Click

        cookie = Request.Cookies.Get("cart")

        If cookie Is Nothing Then
            cookie = New HttpCookie("cart")
            cookie.Value = Request.QueryString("p")
            cookie.Expires = DateTime.Now.AddDays(1)
        Else
            Dim tmp As String() = cookie.Value.Split(",")

            For a As Integer = 0 To tmp.Length - 1
                If tmp(a) = Request.QueryString("p").ToString Then
                    Exit Sub
                End If
            Next

            cookie.Value += "," & Request.QueryString("p").ToString
        End If

        Response.Cookies.Add(cookie)

        'If cookie.Value.Length > 0 Then
        '    Dim tmp As String() = cookie.Value.Split(",")

        '    For i As Integer = 0 To tmp.Length - 1
        '        Response.Write(tmp(i) & " ")
        '    Next
        'End If

    End Sub

    Protected Sub BT_Back_Click(sender As Object, e As EventArgs) Handles BT_Back.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub BT_Leave_Click(sender As Object, e As EventArgs) Handles BT_Leave.Click
        Response.Redirect("messageboard.aspx?s=" & L_StoreID.Text & "&p=" & Request.QueryString("p") & "")
    End Sub

    Protected Sub BT_SC_Click(sender As Object, e As EventArgs) Handles BT_SC.Click
        Response.Redirect("Shopping_Cart.aspx")
    End Sub
End Class

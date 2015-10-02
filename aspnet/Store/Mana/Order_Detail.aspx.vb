
Partial Class Mana_Order_Detail
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If IsNumeric(Request.QueryString("o")) Then

                'str = "select idno,name from Order_status"
                'Comm.FillDDP(DropDownList1, str, "name", "idno")

                str = "SELECT * FROM orders,Order_Content where orders.IDNo = Order_Content.Order_ID and Orders.IDNo = " & Request.QueryString("o") & ""

                Dim DT As Data.DataTable = Main.GetDataSet(str)
                If DT.Rows.Count > 0 Then
                    Literal8.Text = DT.Rows(0).Item("Order_No")
                    Literal3.Text = DT.Rows(0).Item("Contact_ID")
                    Literal10.Text = DT.Rows(0).Item("email")
                    Literal4.Text = DT.Rows(0).Item("tel")
                    Literal9.Text = DT.Rows(0).Item("addr")
                    Literal2.Text = DT.Rows(0).Item("AMT")
                    DropDownList1.SelectedIndex = DT.Rows(0).Item("status")

                    str = "select * from product,Product_Img where product.IDNo = Product_Img.Product_ID and Product.IDNo = " & DT.Rows(0).Item("Item_ID") & " and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"
                    Dim D As Data.DataTable = Main.GetDataSet(str)
                    If D.Rows.Count > 0 Then
                        'Literal1.Text = D.Rows(0).Item("Description") & " <br />" & D.Rows(0).Item("Price")
                        Literal1.Text = D.Rows(0).Item("Product_Name")
                        imgPP.Src = "../" & D.Rows(0).Item("FilePath").ToString.Replace("\", "/")
                    End If

                End If
            End If

        End If



    End Sub

    Protected Sub BT_C_Click(sender As Object, e As System.EventArgs) Handles BT_C.Click

        str = "update Orders set status=" & DropDownList1.SelectedValue & " where IDno = " & Request.QueryString("o") & ""

        If Main.NonQuery(str) Then
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');</script>")
        Else
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>")
        End If

        Response.Write("<script language='javascript'> history.go(-2); </script>")

    End Sub

End Class

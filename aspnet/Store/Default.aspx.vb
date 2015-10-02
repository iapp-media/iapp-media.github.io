
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String
    'Dim url As String = "http://localhost:10989/"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            str = "SELECT top 20 product.IDNo,Product_Name,description,Store_ID,FilePath FROM product,product_img where product.IDNo = product_img.Product_ID and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"

            If IsNumeric(Request.QueryString("c")) Then
                Select Case Request.QueryString("c")
                    Case "1"
                        str += " and product.Cate_ID = '" & Request.QueryString("c") & "'"
                    Case "2"
                        str += " and product.Cate_ID = '" & Request.QueryString("c") & "'"
                    Case "3"
                        str += " and product.Cate_ID = '" & Request.QueryString("c") & "'"
                    Case "4"
                        str += " and product.Cate_ID = '" & Request.QueryString("c") & "'"
                End Select
            End If

            str += " order by NEWID()"

            GetDataList()
        End If
    End Sub

    Sub GetDataList()
        Dim DT As Data.DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            Dim tmp As String = ""
            For i As Integer = 0 To DT.Rows.Count - 1
                'Dim src As String = url + DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                tmp += "<div class=""item"">" & _
                "<div class=""imgcenter""><a href=""product_Detail.aspx?p=" & DT.Rows(i)("IDNo") & """ target=""_self"" >" & _
                "<img class=""item-pic"" height=""960"" width=""640"" src='" & DT.Rows(i)("FilePath").ToString.Replace("\", "/") & "'/></a>" & _
                "<p class=""describe"">" & DT.Rows(i)("description") & "</p>" & _
                "<p class='iapp-name'><a href='' target=""_blank"">" & DT.Rows(i)("Product_Name") & "</a></p>" & _
                "<p class='author'>by <a href='' target='_blank'>" & DT.Rows(i)("Store_ID") & "</a></p>" & _
                "</div>" & _
                "</div>"
            Next
            L.Text = tmp
        Else

        End If
    End Sub

End Class

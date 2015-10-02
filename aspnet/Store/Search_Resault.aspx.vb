Imports System.Data

Partial Class Search_Resault
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String
    'Dim url As String = "http://localhost:8451/store/"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Request.QueryString("entry")) Then
                LTitle.Text = HttpUtility.JavaScriptStringEncode(Request.QueryString("entry"))

                Main.ParaClear()
                Main.ParaAdd("@Product_Name", LTitle.Text, SqlDbType.NVarChar)

                str = "SELECT top 20 * FROM product,product_img where product.IDNo = product_img.Product_ID and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"
                str += " and Product_Name like '%' + @Product_Name + '%'"

                GetDataList()

                'Response.Write(str)   '測試
            End If
        End If
    End Sub

    Sub GetDataList()
        Dim DT As Data.DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            Dim tmp As String = ""
            For i As Integer = 0 To DT.Rows.Count - 1
                'Dim src As String = url + DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                tmp += "<div class=""item"">" & _
                "<div class=""imgcenter""><a href=""product_Detail.aspx?p=" & DT.Rows(i)("IDNo") & """ target=""_blank""><img class=""item-pic"" height=""960"" width=""640"" src='" & DT.Rows(i)("FilePath").ToString.Replace("\", "/") & "'/></a>" & _
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

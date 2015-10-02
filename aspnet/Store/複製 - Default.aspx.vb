
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String
    Dim url As String = "http://localhost:8451/store/"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            str = "SELECT * FROM product,product_img where 1=1 and product.IDNo = product_img.Product_ID and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"
            GetDataList()
            DDLin()
        End If
    End Sub

    'Sub GetDataList()
    '    str = "select a.Img01,c.FoderName,d.User_Name,b.App_Name,b.App_URL from User_Page a " +
    '          " inner join User_App b on a.User_App_ID=b.IDNo inner join Theme c on b.Theme_ID=c.IDNo " +
    '          " inner join Users d on b.User_ID=d.IDNo where sort=1"

    '    Dim DT As Data.DataTable = Main.GetDataSetNoNull(str)
    '    If DT.Rows.Count > 0 Then
    '        Dim tmp As String = ""

    '        For i As Integer = 0 To DT.Rows.Count - 1
    '            Dim src As String = url + DT.Rows(i)("FoderName") + "/Apps/" + DT.Rows(i)("Img01")
    '            tmp += "<div class=""item"">" & _
    '            "<div class=""imgcenter""><img class=""item-pic"" height=""960"" width=""640"" src='" & src & "'/>" & _
    '            "<p class=""describe"">describe</p>" & _
    '            "<p class=""iapp-name""><a href='" & DT.Rows(i)("App_URL") & "' target=""_blank"">" & DT.Rows(i)("App_Name") & "</a></p>" & _
    '            "<p class=""author"">by <a href='" & DT.Rows(i)("App_URL") & "' target=""_blank"">" & DT.Rows(i)("App_Name") & "</a></p>" & _
    '            "</div></div>"
    '        Next

    '        L.Text = tmp
    '    End If
    'End Sub

    Sub GetDataList()
        Dim DT As Data.DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            Dim tmp As String = ""
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim src As String = url + DT.Rows(i)("FilePath").ToString.Replace("\", "/")
                tmp += "<div class=""item"">" & _
                "<div class=""imgcenter""><img class=""item-pic"" height=""960"" width=""640"" src='" & src & "'/>" & _
                "<p class=""describe"">" & DT.Rows(i)("description") & "</p>" & _
                "<p class='iapp-name'><a href='' target=""_blank"">" & DT.Rows(i)("Product_Name") & "</a></p>" & _
                "<p class='author'>by <a href='' target='_blank'>" & DT.Rows(i)("Store_ID") & "</a></p>" & _
                "</div>" & _
                "</div>"
            Next
            L.Text = tmp

        Else
            L.Text = "查無結果"   '測試
        End If
    End Sub

    Protected Sub BT_Search_Click(sender As Object, e As System.EventArgs) Handles BT_Search.Click

        If TName.Text = "" And DDL_Cate.SelectedValue = "" Then Exit Sub

        str = "SELECT * FROM product,product_img where 1=1 and product.IDNo = product_img.Product_ID and product_img.IDNo in(select max(idno) from product_img GROUP by Product_ID )"
        If TName.Text <> "" Then str += " and product.product_name = '" & TName.Text & "'"
        If DDL_Cate.SelectedValue <> "" Then str += " and product.Cate_ID = '" & DDL_Cate.SelectedValue & "'"
        GetDataList()

        Response.Write(str)   '測試
    End Sub

    Sub DDLin()
        str = "select Cate_Name,IDNo from Product_Cate where ref=-1 order by Cate_Name"
        Comm.FillDDP(DDL_Cate, str, "Cate_Name", "IDNo")
    End Sub

End Class

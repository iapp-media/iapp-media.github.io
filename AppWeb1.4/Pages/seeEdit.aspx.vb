Public Class seeEdit
    Inherits System.Web.UI.Page
    Dim str As String
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("ID")) Then
            str = "Select a.URL from Pages a inner join User_Page b ON a.IDNo=b.Page_ID where b.IDNo=" & Request.QueryString("ID")
            Dim url As String = Main.Scalar(str)
            url = url.Replace(".aspx", "_Edit.aspx")
            If url <> "" Then
                Response.Redirect(url & "?ID=" & Request.QueryString("ID"))
            End If
            Response.End()
        Else
        End If
    End Sub

End Class
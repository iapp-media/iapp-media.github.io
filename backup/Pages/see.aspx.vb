Public Class see
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("ID")) Then
            str = "Select a.URL from Pages a inner join User_Page b ON a.IDNo=b.Page_ID where b.IDNo=" & Request.QueryString("ID")
            Dim url As String = Main.Scalar(str)
            If url <> "" Then
                'Response.Write(url & "?ID=" & Request.QueryString("ID"))
                Response.Redirect(url & "?ID=" & Request.QueryString("ID"))
            End If
            Response.End()
        Else
        End If
    End Sub
End Class
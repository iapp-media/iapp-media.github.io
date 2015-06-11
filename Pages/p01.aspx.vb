Public Class p01
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = "select Img01 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim url As String = Main.Scalar(str)
        If url <> "" Then
            Image1.ImageUrl = "../" & url.Replace("\", "/")
        End If
    End Sub

End Class
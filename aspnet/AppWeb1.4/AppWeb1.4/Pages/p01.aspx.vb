Public Class p01
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        str = "select Img01 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim url As String = Main.Scalar(str)
        Dim pages As New StringBuilder
        pages.Append(" <div class=""bg animated fadeIn1"" style=""background-image: url(../Apps/" & url & ");""></div>" & vbCrLf)
        L.Text = pages.ToString()
        'If url <> "" Then
        '    Image1.ImageUrl = "../" & url.Replace("\", "/")
        'End If
    End Sub

End Class
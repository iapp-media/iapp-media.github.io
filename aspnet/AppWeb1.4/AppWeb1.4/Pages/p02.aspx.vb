Public Class p021
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim page2, page2H As New StringBuilder()
        str = "select Img01,h1,h2 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim dr As DataTable = Main.GetDataSet(str)
        If dr.Rows.Count > 0 Then
            Dim url As String = dr.Rows(0).Item("Img01").ToString()
            Dim h1 As String = dr.Rows(0).Item("h1").ToString()
            Dim h2 As String = dr.Rows(0).Item("h2").ToString()
            If url <> "" Or h1 <> "" Then
                page2.Append(" <div class=""bg animated zoomInDown"" style=""background-image: url(../Apps/" & url & ");""></div>" & vbCrLf)
                page2H.Append(" <div class=""bar1 animated fadeIn1""><p id=""dw"" onclick=""passValue(1)"" class=""text1 animated fadeInLeft1"">" & h1 & "</p><p class=""text1-1 animated fadeInLeft1"" onclick=""passValue(2)"">" & h2 & "</p></div>" & vbCrLf)
            End If
        End If
        L.Text = page2.ToString()
        L2.Text = page2H.ToString()
    End Sub

End Class
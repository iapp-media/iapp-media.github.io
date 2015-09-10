Public Class p03
    Inherits System.Web.UI.Page
    Dim str As String = ""
    Public DBdata(3) As String
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim dr As System.Data.DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        imgSub()
    End Sub

    Sub imgSub()
        Dim page3 As New StringBuilder()
        str = "select Img01,Img02,Img03 from User_Page where IDNo=" & Request.QueryString("ID")
        dr = Main.GetDataSet(str)
        page3.Append("<div class=""border bg1"">" & vbCrLf)
        page3.Append(" <a id=""show-upload"" onclick=""goValue(1)"" class='#' href='javascrip:void(0)'> " & vbCrLf)
        page3.Append("<img class=""bg animated slideInLeft1"" src=""../Apps/" & dr.Rows(0).Item("Img01").ToString() & """/></a></div>" & vbCrLf)
        page3.Append("<div class=""border bg2"">" & vbCrLf)
        page3.Append(" <a id=""show-upload"" onclick=""goValue(2)"" class='#' href='javascrip:void(0)'> " & vbCrLf)
        page3.Append("<img class=""bg animated slideInRight1"" src=""../Apps/" & dr.Rows(0).Item("Img02").ToString() & """ /></a></div>" & vbCrLf)
        page3.Append("<div class=""border bg3"">" & vbCrLf)
        page3.Append(" <a id=""show-upload"" onclick=""goValue(3)"" class='#' href='javascrip:void(0)'> " & vbCrLf)
        page3.Append("<img class=""bg animated slideInLeft2"" src=""../Apps/" & dr.Rows(0).Item("Img03").ToString() & """ /></a></div>" & vbCrLf)
        Literal1.Text = page3.ToString()
    End Sub
End Class
Public Class p021
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = "select Img01,h1 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim dr As DataTable = Main.GetDataSet(str)
        If dr.Rows.Count > 0 Then
            Dim url As String = dr.Rows(0).Item("Img01").ToString()
            Dim h1 As String = dr.Rows(0).Item("h1").ToString()
            If url <> "" Or h1 <> "" Then
                Image1.ImageUrl = "../" & url.Replace("\", "/")
                Label1.Text = dr.Rows(0).Item("h1").ToString()
                If h1 = "" Then
                    Label1.Text = "點我修改文字"
                End If
            End If
        End If

    End Sub

End Class
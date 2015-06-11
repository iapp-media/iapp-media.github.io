Public Class Allupload
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Main.IsNumeric(Request.QueryString("ID")) Then
            str = "Select a.URL from Pages a inner join User_Page b on a.IDNo=b.Page_ID Where b.IDNo=" & Request.QueryString("ID")
            Dim url As String = Main.Scalar(str)
            Dim index As Integer = url.Substring(2, 1)
        End If
    End Sub

End Class
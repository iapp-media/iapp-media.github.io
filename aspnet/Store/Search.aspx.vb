
Partial Class Search
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub BT_Search_Click(sender As Object, e As System.EventArgs) Handles BT_Search.Click
        If TName.Text <> "" Then Response.Redirect("Search_Resault.aspx?entry=" & HttpUtility.UrlEncode(HttpUtility.JavaScriptStringEncode(TName.Text)) & "")
        Literal1.Text = HttpUtility.UrlEncode(HttpUtility.JavaScriptStringEncode(TName.Text))
    End Sub

End Class

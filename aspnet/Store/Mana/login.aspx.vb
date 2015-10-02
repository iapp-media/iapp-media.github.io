
Partial Class Mana_login
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If TUID.Text = "" Or TPWD.Text = "" Then Exit Sub
        str = "select * from Users where Account = '" & TUID.Text.Trim & "' and Password = '" & TPWD.Text.Trim & "'"
        Dim DT As Data.DataTable = Main.GetDataSet(str)
        If DT.Rows.Count > 0 Then
            Session("User_ID") = DT.Rows(0).Item("account")
            Response.Redirect("Default.aspx?s=" & DT.Rows(0).Item("IDNo") & "")
            'Dim t As Integer = Main.Scalar("select * from Store where User_ID='" & TUID.Text.Trim & "'")
            'If t > 0 Then
            '    Session("Store_ID") = DT.Rows(0).Item("IDNo")
            '    Response.Redirect("Default.aspx?s=" & DT.Rows(0).Item("IDNo") & "")
            'End If

            Session.Timeout() = 30   '分鐘'

        End If
    End Sub
End Class

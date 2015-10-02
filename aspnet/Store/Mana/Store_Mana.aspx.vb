
Partial Class Mana_Store_Mana
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)

            If Session("User_ID") <> "" Then
                Dim DT As Data.DataTable = Main.GetDataSetNoNull("select * from Users,store where users.Account = store.User_ID and users.Account ='" & Session("User_ID") & "'")
                If DT.Rows.Count > 0 Then
                    TB_StoreName.Text = DT.Rows(0).Item("Store_Name")
                    TB_UserNamer.Text = DT.Rows(0).Item("User_Name")
                    TB_Tel.Text = DT.Rows(0).Item("tel")
                    TB_Email.Text = DT.Rows(0).Item("email")
                    TB_Addr.Text = DT.Rows(0).Item("addr")
                End If

            End If
        End If
    End Sub

    Protected Sub BTS_Click(sender As Object, e As System.EventArgs) Handles BTS.Click
        If IsNumeric(Request.QueryString("s")) Then
            Dim tmp As String = ""
            If TB_StoreName.Text = "" Or TB_UserNamer.Text = "" Or TB_Tel.Text = "" Or TB_Email.Text = "" Or TB_Addr.Text = "" Then tmp += "請確實填寫"
            If tmp <> "" Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('" & tmp.Substring(1) & "');", True)
                Exit Sub
            End If

            ' 店名
            str = "update Store set Store_Name='" & TB_StoreName.Text.Trim() & "' where User_ID='" & Session("User_ID") & "'"
            Dim s As Integer = Main.NonQuery(str)
            If s = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('儲存失敗，請重新操作或連絡管理者');", True)
                Exit Sub
            End If

            ' 個人資料
            str = "update Users set User_Name='" & TB_UserNamer.Text.Trim() & "',tel='" & TB_Tel.Text.Trim() & "',email='" & TB_Email.Text.Trim() & "',addr='" & TB_Addr.Text.Trim() & "' where Account='" & Session("User_ID") & "'"
            Dim u As Integer = Main.NonQuery(str)
            If u = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('儲存失敗，請重新操作或連絡管理者');", True)
                Exit Sub
            End If

            Response.Write("<script>alert('儲存成功');window.open('Default.aspx?s=" & Request.QueryString("s") & "','_self');</script>")
        End If
    End Sub

    Protected Sub BTD_Click(sender As Object, e As System.EventArgs) Handles BTD.Click
        Response.Redirect("Default.aspx?s=" & Request.QueryString("s") & "")
    End Sub

End Class

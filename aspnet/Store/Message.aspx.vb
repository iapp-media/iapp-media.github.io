
Partial Class Message
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("entry")) Then
                
            End If
        End If
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If TB_Message.Text = "" Then Exit Sub

        str = "insert into message(Product_ID,cont,leave_ID) values(" & Request.QueryString("entry") & ",'" & TB_Message.Text & "','" & Session("User_ID") & "')"

        If Main.NonQuery(str) Then
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');location.href='MessageBoard.aspx?entry=" & Request.QueryString("entry") & "'</script>")
        Else
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>")
            Response.Write(str)
        End If

    End Sub
End Class

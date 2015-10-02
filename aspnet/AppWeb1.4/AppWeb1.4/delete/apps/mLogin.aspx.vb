Public Class mLogin
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""
    Dim CookieDays As Integer = 30   '設定Cookie存留時間

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Comm.ChkLoginStat("Login.aspx") Then
        '    If IsNumeric(Request.QueryString("c")) Then 
        '        Response.Write("<Script>window.open('capp.aspx?i=" + Request.QueryString("c") + "','_top')</Script>")
        '        Response.End()
        '    End If
        'Else 
        '    CID.Value = Request.QueryString("c") 
        'End If
        CID.Value = Request.QueryString("c")
    End Sub

    Protected Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If Comm.UserLogin(accBox.Text, pwBox.Text) Then 
            If IsNumeric(Request.QueryString("c")) Then
                Response.Write("<Script>window.open('capp.aspx?i=" & Request.QueryString("c") & "','_self')</Script>")
            Else
                Response.Write("<Script>window.open('../../../portal/portal.aspx','_self')</Script>")
            End If
            Response.End()
        Else 
            Response.Write("<script>alert('帳號或密碼錯誤')</script>")
        End If 
    End Sub
End Class

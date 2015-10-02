
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

              Session.Abandon()
        End If
    End Sub
 

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Session("imgWord") <> TB3.Text Then
            Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "<script>alert('驗證碼錯誤');</script>")
            TB3.Text = ""
            Exit Sub
        End If
        TB3.Text = ""  '過了就關掉

        If TUID.Text = "admin" And TPWD.Text = "speedooo" Then
            Session("secu") = "ok"
            Response.Redirect("newMIIB.aspx")

        Else
            Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "<script>alert('帳號或密碼錯誤');</script>")
            Exit Sub
        End If
 
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("secu.aspx")
    End Sub
End Class
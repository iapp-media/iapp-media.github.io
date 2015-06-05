Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("OK") = "OK" Then
            Session.RemoveAll()
            Session.Abandon()
        End If
        Response.Redirect("login.aspx")
    End Sub
End Class

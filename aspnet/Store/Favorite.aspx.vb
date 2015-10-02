
Partial Class Favorite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'LTitle.Text = "我的最愛"
        End If
    End Sub
End Class

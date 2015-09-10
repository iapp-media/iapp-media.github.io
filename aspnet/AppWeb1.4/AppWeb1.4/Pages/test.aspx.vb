Public Class test
    Inherits System.Web.UI.Page


    Dim Comm As New CommTool()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<img src=""../Apps/01/pic/" & Comm.FBShareImg(1) & """ />")

    End Sub

End Class
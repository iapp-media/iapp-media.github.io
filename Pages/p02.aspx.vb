Public Class p02
    Inherits System.Web.UI.Page
    Dim str As String
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim url As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imgSub(Image1, "Img01")
        imgSub(Image2, "Img02")
    End Sub

    Sub imgSub(img As WebControls.Image, Dbimg As String)
        str = "select " & Dbimg & " from User_Page where IDNo=" & Request.QueryString("ID")
        url = Main.Scalar(str)
        If url <> "" Then
            img.ImageUrl = "../" & url.Replace("\", "/")
        Else
            If (Dbimg = "Img01") Then
                img.ImageUrl = "../images/1c.jpg"
            ElseIf (Dbimg = "Img02") Then
                img.ImageUrl = "../images/2c.png"
            End If
        End If
    End Sub

End Class
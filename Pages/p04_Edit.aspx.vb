Imports System.Drawing
Public Class p04_Edit
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String
    Dim url As String
    Dim w As Integer = 290 '照片寬
    Dim h As Integer = 200 '照片高
    Public MainPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imgSub(Image1, "Img01")
        imgSub(Image2, "Img02")
        imgSub(Image3, "Img03")
    End Sub
    Sub SqlSub(ByVal FilePath As String, ByVal Img As String)
        Dim TmpSession As String = ""
        If IsNothing(Session("IDNo")) Then
            If Not IsNothing(Request.Cookies("ThisPC")) Then
                TmpSession = Request.Cookies("ThisPC").Value
            Else
                TmpSession = Session.SessionID
            End If
            Main.ParaClear()
            Main.ParaAdd("@" & Img, FilePath, Data.SqlDbType.VarChar)
            str = "Update User_Page set " & Img & " = @" & Img & " Where IDNo=" & Request.QueryString("ID") & " And SessionID = '" & TmpSession & "'"
            Main.NonQuery(str)
        Else
            Main.ParaClear()
            Main.ParaAdd("@" & Img, FilePath, Data.SqlDbType.VarChar)
            str = "Update User_Page set " & Img & " = @" & Img & " Where IDNo=" & Request.QueryString("ID")
            Main.NonQuery(str)
        End If
        imgSub(Image1, "Img01")
        imgSub(Image2, "Img02")
        imgSub(Image3, "Img03")
    End Sub

    Function uploadSub(FU As FileUpload, w As Integer, h As Integer) As String
        Dim FileName As String = FU.FileName.Replace(",", "")
        Dim FilePath As String = "User_Pic\" & FU.FileName.ToString() & ".jpg"
        If System.IO.Directory.Exists(MainPath & "User_Pic") = False Then
            System.IO.Directory.CreateDirectory(MainPath & "User_Pic")
        End If
        If (FU.HasFile = True) Then
            'Dim w As Integer = 290
            'Dim h As Integer = 450
            Dim inbmp As New Bitmap(FU.PostedFile.InputStream)
            inbmp = comm.zoomImage(inbmp, w, h)
            inbmp = comm.CutImage(inbmp, w, h)
            'im inbmp As New Bitmap(FU.PostedFile.InputStream)
            inbmp.Save(MainPath & FilePath)
        End If
        Return FilePath
    End Function

    Sub imgSub(img As WebControls.Image, Dbimg As String)
        str = "select " & Dbimg & " from User_Page where IDNo=" & Request.QueryString("ID")
        url = Main.Scalar(str)
        If url <> "" Then
            img.ImageUrl = "../" & url.Replace("\\", "/")
        Else
            If (Dbimg = "Img01") Then
                img.ImageUrl = "../images/1c.jpg"
            ElseIf (Dbimg = "Img02") Then
                img.ImageUrl = "../images/2c.png"
            ElseIf (Dbimg = "Img03") Then
                img.ImageUrl = "../images/3c.png"
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (comm.ChkType(FU1.PostedFile, "image") = False) Then
            'Msg.Text = "格式不正確!!"
            Response.Write("<Script>alert('格式不正確!!')</Script>")
            Return
        End If
        If (FU1.HasFile = True) Then
            uploadSub(FU1, w, h)
            SqlSub(uploadSub(FU1, w, h), "Img01")
        Else
            Response.Write("<Script>alert('沒有檔案')</Script>")
        End If
        flashMid()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (comm.ChkType(FU2.PostedFile, "image") = False) Then
            'Msg.Text = "格式不正確!!"
            Response.Write("<Script>alert('格式不正確!!')</Script>")
            Return
        End If
        If (FU2.HasFile = True) Then
            uploadSub(FU2, w, h)
            SqlSub(uploadSub(FU2, w, h), "Img02")
        Else
            Response.Write("<Script>alert('上傳兩個檔案')</Script>")
        End If
        flashMid()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (comm.ChkType(FU3.PostedFile, "image") = False) Then
            'Msg.Text = "格式不正確!!"
            Response.Write("<Script>alert('格式不正確!!')</Script>")
            Return
        End If
        If (FU3.HasFile = True) Then
            uploadSub(FU3, w, h)
            SqlSub(uploadSub(FU3, w, h), "Img03")
        Else
            Response.Write("<Script>alert('上傳兩個檔案')</Script>")
        End If
        flashMid()
    End Sub
    Sub flashMid()
        Response.Write("<Script>window.parent.show('Pages/see.aspx?ID=" & Request.QueryString("ID") & "'," & Request.QueryString("ID") & ");</Script>")
    End Sub
End Class
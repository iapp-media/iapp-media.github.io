Imports System.Drawing
Imports System.Data
Public Class p01_Edit
    Inherits System.Web.UI.Page
    Dim comm As New CommTool()
    Dim Main As New JDB()
    Dim str As String = ""
    Public MainPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = "select Img01 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim url As String = Main.Scalar(str)
        If url <> "" Then
            Image1.ImageUrl = "../" & url.Replace("\", "/")
        Else
            Image1.ImageUrl = ""
        End If
    End Sub

    Protected Sub BTFU_Click(sender As Object, e As EventArgs) Handles BTFU.Click
        If (comm.ChkType(FU.PostedFile, "image") = False) Then
            Msg.Text = "格式不正確!!"
            Return
        End If
        If (FU.HasFile = True) Then
            Dim FileName As String = FU.FileName.Replace(",", "")
            Dim FilePath As String = "User_Pic/" & FU.FileName.ToString() & ".jpg"
            If System.IO.Directory.Exists(MainPath & "User_Pic") = False Then
                System.IO.Directory.CreateDirectory(MainPath & "User_Pic")
            End If
            Dim w As Integer = 290
            Dim h As Integer = 450
            Dim inbmp As New Bitmap(FU.PostedFile.InputStream)
            inbmp = comm.zoomImage(inbmp, w, h)
            inbmp = comm.CutImage(inbmp, w, h)
            'im inbmp As New Bitmap(FU.PostedFile.InputStream)
            inbmp.Save(MainPath & FilePath)
            Image1.ImageUrl = "../" & FilePath.Replace("\", "/")
            Dim TmpSession As String = ""
            If IsNothing(Session("IDNo")) Then
                If Not IsNothing(Request.Cookies("ThisPC")) Then
                    TmpSession = Request.Cookies("ThisPC").Value
                Else
                    TmpSession = Session.SessionID
                End If
                Main.ParaClear()
                Main.ParaAdd("@Img01", FilePath, Data.SqlDbType.VarChar)
                str = "Update User_Page set Img01 = @Img01 Where IDNo=" & Request.QueryString("ID") & " And SessionID = '" & TmpSession & "'"
                Main.NonQuery(str)
            Else
                Main.ParaClear()
                Main.ParaAdd("@Img01", FilePath, Data.SqlDbType.VarChar)
                str = "Update User_Page set Img01 =@Img01 Where IDNo=" & Request.QueryString("ID") & " And User_ID = " & Session("IDNo")
                Main.NonQuery(str)
            End If
        End If
        flashMid()
    End Sub
    Sub flashMid()
        Response.Write("<Script>window.parent.show('Pages/see.aspx?ID=" & Request.QueryString("ID") & "'," & Request.QueryString("ID") & ");</Script>")
    End Sub
End Class
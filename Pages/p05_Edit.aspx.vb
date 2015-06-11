Imports System.Drawing
Imports System.Data
Public Class p05_Edit
    Inherits System.Web.UI.Page
    Dim comm As New CommTool()
    Dim Main As New JDB()
    Dim str As String = ""
    Public MainPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = "select Img01,h1 from User_Page where IDNo=" & Request.QueryString("ID")
        Dim dr As DataTable = Main.GetDataSet(str)
        If dr.Rows.Count > 0 Then
            Dim url As String = dr.Rows(0).Item("Img01").ToString()
            Dim h1 As String = dr.Rows(0).Item("h1").ToString()
            If url <> "" Then
                Image1.ImageUrl = "../" & url.Replace("\", "/")
            End If
            If h1 <> "" Then
                AA.Text = h1
                TextBox1.Text = AA.Text
            End If
        End If
    End Sub

    Protected Sub finish_Click(sender As Object, e As ImageClickEventArgs) Handles finish.Click
        If (comm.ChkType(FU.PostedFile, "image") = False And comm.ChkType(FU.PostedFile, "") <> True) Then
            Response.Write("<Script>alert('圖片格式不正確')</Script>")
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
                Main.ParaAdd("@h1", TextBox1.Text, Data.SqlDbType.NVarChar)
                str = "Update User_Page set Img01=@Img01,h1=@h1 Where IDNo=" & Request.QueryString("ID") & " And SessionID = '" & TmpSession & "'"
                Main.NonQuery(str)
            Else
                Main.ParaClear()
                Main.ParaAdd("@Img01", FilePath, Data.SqlDbType.VarChar)
                Main.ParaAdd("@h1", TextBox1.Text, Data.SqlDbType.NVarChar)
                str = "Update User_Page set Img01=@Img01,h1=@h1 Where IDNo=" & Request.QueryString("ID") & " And User_ID = " & Session("IDNo")
                Main.NonQuery(str)
            End If
        Else
            Dim TmpSession As String = ""
            If IsNothing(Session("IDNo")) Then
                If Not IsNothing(Request.Cookies("ThisPC")) Then
                    TmpSession = Request.Cookies("ThisPC").Value
                Else
                    TmpSession = Session.SessionID
                End If
                Main.ParaClear()
                Main.ParaAdd("@h1", TextBox1.Text, Data.SqlDbType.NVarChar)
                str = "Update User_Page set h1=@h1 Where IDNo=" & Request.QueryString("ID") & " And SessionID = '" & TmpSession & "'"
                Main.NonQuery(str)
            Else
                Main.ParaClear()
                Main.ParaAdd("@h1", TextBox1.Text, Data.SqlDbType.NVarChar)
                str = "Update User_Page set h1=@h1 Where IDNo=" & Request.QueryString("ID") & " And User_ID = " & Session("IDNo")
                Main.NonQuery(str)
            End If
        End If
        flashMid()
    End Sub

    Sub flashMid()
        Response.Write("<Script>window.parent.show('Pages/see.aspx?ID=" & Request.QueryString("ID") & "'," & Request.QueryString("ID") & ");</Script>")
    End Sub

    Sub check()

    End Sub
End Class
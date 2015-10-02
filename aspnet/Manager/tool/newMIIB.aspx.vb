Imports System.IO

Partial Class newMIIB
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Session("secu") <> "ok" Then
            Response.Redirect("secu.aspx")
        End If
        If Not Page.IsPostBack Then
            Result.Text += Session("secu") & Server.MapPath("./")
            txtdestin.Text = Server.MapPath("./")
            TextBox2.Text = Server.MapPath("./")
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim ifile As HttpPostedFile = File1.PostedFile
        Dim filename As String
        Dim xdate As String = CStr(Year(Now) - 1911) & CStr(Month(Now)) & CStr(Day(Now))
        xdate += CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now))
        Dim xdir As String = txtdestin.Text
        filename = xdir & Path.GetFileName(ifile.FileName)
        Dim Finfo As FileInfo = New FileInfo(filename)


        Result.Text = ""
        If ifile.ContentLength <> 0 Then
            If Finfo.Exists Then
                Finfo.MoveTo(xdir & "__" & Path.GetFileNameWithoutExtension(filename) & ".BAK" & xdate)
                Result.Text += "<br>更新檔案：" & xdir & "__" & Path.GetFileNameWithoutExtension(filename) & ".BAK" & xdate
            End If
            ifile.SaveAs(filename)
            Result.Text += "<br>檔案上傳成功：" & filename
        Else
            Result.Text = "沒有檔案"
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FileCollection As String()
        Dim MyFileInfo As FileInfo
        Dim i As Integer
        Result.Text = ""
        FileCollection = Directory.GetDirectories(txtdir.Text)
        For i = 0 To FileCollection.Length - 1
            MyFileInfo = New FileInfo(FileCollection(i))
            Result.Text += "<br>" & MyFileInfo.FullName.ToString()
        Next

        Result.Text += "<br>=============================================="
        FileCollection = Directory.GetFiles(txtdir.Text, "*.*")
        For i = 0 To FileCollection.Length - 1
            MyFileInfo = New FileInfo(FileCollection(i))
            Result.Text += "<br><a href=""GetFile.aspx?file=" & Server.UrlEncode(MyFileInfo.FullName.ToString()) & """ target=""_blank"">" & MyFileInfo.Name.ToString() & "</a>" & vbCrLf
        Next
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MyFileInfo As FileInfo = New FileInfo(txtdestin.Text)
        If MyFileInfo.Exists Then
            MyFileInfo.Delete()
        End If
        Result.Text = "刪除成功"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim MyFileInfo As FileInfo = New FileInfo(Move1.Text)
        If MyFileInfo.Exists And Move2.Text <> "" Then
            MyFileInfo.MoveTo(Move2.Text)
        End If
        Result.Text = "成功將" & Move1.Text & "移動至" & MyFileInfo.FullName
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str As String
        str = TextBox1.Text.Trim()
        Directory.CreateDirectory(TextBox2.Text.Trim() & TextBox1.Text.Trim())
        Result.Text = "建立目錄" & TextBox2.Text.Trim() & TextBox1.Text.Trim() & "成功"
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim FileCollection As String()
        Dim MyFileInfo As FileInfo
        Dim i As Integer
        FileCollection = Directory.GetDirectories(txtdir.Text)
        For i = 0 To FileCollection.Length - 1
            MyFileInfo = New FileInfo(FileCollection(i))
            Result.Text += "<br>" & MyFileInfo.FullName.ToString()
        Next

        Result.Text += "<br>=============================================="
        FileCollection = Directory.GetFiles(txtdir.Text, "*" & Me.TextBox3.Text.Trim & ".*")
        For i = 0 To FileCollection.Length - 1
            MyFileInfo = New FileInfo(FileCollection(i))

            Result.Text += "<br><a href=""GetFile.aspx?file=" & Server.UrlEncode(MyFileInfo.FullName.ToString()) & """ target=""_blank"">" & MyFileInfo.Name.ToString() & "</a>" & vbCrLf

        Next
    End Sub
End Class
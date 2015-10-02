Imports System.IO

Partial Class CheckFiles
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ss As New System.Text.StringBuilder
 
        ss.Append("<table border=1>")
        ss.Append("<tr><th>目錄</th><th>檔名</th></tr>" & vbCrLf)

        ss.Append(GetFilesInDir(txtdir.Text))
        ss.Append(GetDirInDir(txtdir.Text))

        ss.Append("</table>")
        Me.Literal1.Text = ss.ToString()

        ' Result.Text += "<br>=============================================="
    End Sub

    Function GetFilesInDir(ByVal Dir As String) As String
        Dim FileCollection As String()
        Dim MyFileInfo As FileInfo
        Dim ss As New System.Text.StringBuilder
        FileCollection = Directory.GetFiles(Dir, Me.TextBox1.Text.Trim)
        For i As Integer = 0 To FileCollection.Length - 1
            MyFileInfo = New FileInfo(FileCollection(i))
            ss.Append("<tr>" & vbCrLf)
            ss.Append("    <td>" & MyFileInfo.DirectoryName & "</td><td>" & MyFileInfo.Name & "</td>" & vbCrLf)
            ss.Append("</tr>" & vbCrLf)
        Next
        Return ss.ToString()
    End Function

    Function GetDirInDir(ByVal Dir As String)
        Dim tmp As String = ""
        Dim DirCollection As String() = Directory.GetDirectories(txtdir.Text)
        If DirCollection.Length > 0 Then
            For j As Integer = 0 To DirCollection.Length - 1
                tmp += GetFilesInDir(DirCollection(j))
                Response.Write(DirCollection(j) & "<br>") 
            Next
            For i As Integer = 0 To DirCollection.Length - 1
                Dim Dir2 As String() = Directory.GetDirectories(DirCollection(i))
                For j As Integer = 0 To Dir2.Length - 1
                    tmp += GetFilesInDir(Dir2(j))
                    Response.Write(Dir2(j) & "<br>")
                Next
            Next
        End If
        Return tmp
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub
End Class

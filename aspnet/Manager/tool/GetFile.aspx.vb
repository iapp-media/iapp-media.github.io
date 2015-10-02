Imports System.IO

Partial Class GetFile
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在這裡放置使用者程式碼以初始化網頁
        If Not IsNothing(Request.QueryString("file")) Then
            '  Response.Write(Server.HtmlDecode(Request.QueryString("file")))
            Dim MyFileInfo As FileInfo = New FileInfo(Server.UrlDecode(Request.QueryString("file")))
            If MyFileInfo.Exists Then
                DownloadFile(Me, Request.QueryString("file"))
            End If
        End If
    End Sub

    Shared Function DownloadFile(ByVal WebForm As System.Web.UI.Page, ByVal FilePath As String) As Boolean
        Dim FileName As String
        '取得檔名
        FileName = FilePath
        '取得檔案
        Dim aa As New FileStream(FileName, FileMode.Open)
        Dim buf(aa.Length - 1) As Byte

        If aa.Read(buf, 0, aa.Length) < 1 Then
            WebForm.Response.Write("讀取檔案失敗 檔名：[" & FileName & "]")
            WebForm.Response.End()
        End If
        '準備下載檔案
        WebForm.Response.ClearHeaders()
        WebForm.Response.Clear()
        WebForm.Response.Expires = 0
        WebForm.Response.Buffer = True
        '透過 Header 設定檔名
        FileName = Right(FileName, InStr(StrReverse(FileName), "\") - 1)
        WebForm.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) & Chr(34))
        WebForm.Response.ContentType = "Application/octet-stream"

        aa.Close()
        aa.Dispose()

        '傳出要讓使用者下載的內容
        WebForm.Response.BinaryWrite(buf)
        WebForm.Response.End()
        Return True
    End Function
End Class

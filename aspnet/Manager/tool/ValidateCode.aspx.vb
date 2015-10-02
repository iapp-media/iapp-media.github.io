Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing

Partial Class ValidateCode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        ' 5位數字的驗證碼
        Dim str_ValidateCode As String = GetRandomNumberString(5)
        ' 用於驗證的Session
        Session("imgWord") = str_ValidateCode
        Me.CreateCheckCodeImage(str_ValidateCode)

    End Sub

    Public Function GetRandomNumberString(ByVal int_NumberLength As Integer) As String
        '建管處客製 一個英文、三個數字
        Dim SS As String = ""
        Dim ABC() As String = "q,w,e,r,t,y,u,i,p,a,s,d,f,g,h,j,k,z,x,c,v,b,n,m".Split(",")
        SS = ABC(GetRND(ABC.Length) - 1)

        Dim R123() As String = "2,3,4,5,6,7,8,9".Split(",")
        For i As Integer = 1 To 3
            SS += R123(GetRND(R123.Length) - 1)
        Next
        Return SS
    End Function

    Public Function GetRND(ByVal maxNum As Integer) As Integer
        Dim v As Integer
        Randomize()
        v = Int(Rnd() * maxNum + 1)
        Return v
    End Function

    ' 隨機生成數字字符串 (原始)
    'Public Function GetRandomNumberString(ByVal int_NumberLength As Integer) As String
    '    Dim str_Number As String = String.Empty
    '    Dim theRandomNumber As New Random()
    '    For int_index As Integer = 0 To int_NumberLength - 1
    '        str_Number += theRandomNumber.[Next](10).ToString()
    '    Next
    '    Return str_Number
    'End Function

    '英數合併 (1,0,o,l沒有)
    'Public Function GetRandomNumberString(ByVal int_NumberLength As Integer) As String  
    '    Dim SS As String = ""
    '    Dim ABC() As String = "2,3,4,5,6,7,8,9,q,w,e,r,t,y,u,i,p,a,s,d,f,g,h,j,k,z,x,c,v,b,n,m".Split(",")
    '    For i As Integer = 0 To int_NumberLength - 1
    '        Dim II As Integer = GetRND(ABC.Length) - 1
    '        SS += ABC(II)
    '    Next
    '    Return SS
    'End Function

    Private Sub CreateCheckCodeImage(ByVal checkCode As String)
        If checkCode Is Nothing OrElse checkCode.Trim() = [String].Empty Then
            Return
        End If

        Dim image As New System.Drawing.Bitmap(CInt(Math.Ceiling((checkCode.Length * 13.5))), 25)
        Dim g As System.Drawing.Graphics = Graphics.FromImage(image)

        Try
            '生成隨機生成器
            Dim random As New Random()

            '清空圖片背景色
            g.Clear(Color.White)
            For i As Integer = 0 To 24

                '畫圖片的背景噪音線
                Dim x1 As Integer = random.[Next](image.Width)
                Dim x2 As Integer = random.[Next](image.Width)
                Dim y1 As Integer = random.[Next](image.Height)
                Dim y2 As Integer = random.[Next](image.Height)

                g.DrawLine(New Pen(Color.Silver), x1, y1, x2, y2)
            Next

            Dim font As Font = New System.Drawing.Font("標楷體", 16, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) ' (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic)

            Dim brush As New System.Drawing.Drawing2D.LinearGradientBrush(New Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, True)
            g.DrawString(checkCode, font, brush, 2, 2)
            For i As Integer = 0 To 99

                '畫圖片的前景噪音點
                Dim x As Integer = random.[Next](image.Width)
                Dim y As Integer = random.[Next](image.Height)

                image.SetPixel(x, y, Color.FromArgb(random.[Next]()))
            Next

            '畫圖片的邊框線
            g.DrawRectangle(New Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1)

            Dim ms As New System.IO.MemoryStream()
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            Response.ClearContent()
            Response.ContentType = "image/Gif"
            Response.BinaryWrite(ms.ToArray())
        Finally
            g.Dispose()
            image.Dispose()
        End Try
    End Sub
End Class


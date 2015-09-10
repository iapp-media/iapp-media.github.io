Imports System.Web
Imports System.IO
Imports System.Web.Services

Public Class UserIcon
    Implements System.Web.IHttpHandler
    Dim Main As New JDB()

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If IsNumeric(context.Request.QueryString("i")) Then

            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim conn As New System.Data.SqlClient.SqlConnection
            conn.ConnectionString = Main.ConnStr
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "Select User_Icon from  Users where IDNo=" & context.Request.QueryString("i")
            'context.Response.ContentType = "image/jpeg"
            'Response.Write(dr("sFileName"))
        
            Dim img As Object = cmd.ExecuteScalar
            If Not IsDBNull(img) Then
                Dim MS As MemoryStream = New MemoryStream(CType(img, Byte()))
                context.Response.ContentType = "image/jpeg"
                context.Response.BinaryWrite(MS.ToArray())

            Else
                Dim aa As New FileStream(context.Server.MapPath("img/defaulthead.png"), FileMode.Open)
                Dim buf(aa.Length - 1) As Byte
                If aa.Read(buf, 0, aa.Length) > 1 Then
                    context.Response.ContentType = "image/png"
                    context.Response.BinaryWrite(buf)
                End If
                aa.Close()
                aa.Dispose()
            End If
            conn.Close()

            'Do While byteSeq > 0
            '    context.Response.OutputStream.Write(buffer, 0, byteSeq)
            '    byteSeq = MemoryStream.Read(buffer, 0, 4096)
            'Loop
        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
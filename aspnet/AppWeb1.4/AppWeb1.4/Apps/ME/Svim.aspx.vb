Imports System.IO

Public Class Svim
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Public AppPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("AppPath")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            comm.WriteLog("SVIM")

            If IsNumeric(Request("i").Replace("-", "")) Then
                Dim s As String() = Request("i").Split("-")

                If s.Length <> 2 Then
                    Response.Write("Error s101")
                    Response.End()
                    Exit Sub
                End If
                Dim CurrentId As Integer = comm.Cint2(main.Scalar("Select IDNo from User_Page where IDNo=" & s(0)))
                Dim CoNum As String = "Img0" & s(1)
                If CurrentId = 0 Then
                    Response.Write("Error s102")
                    Response.End()
                    Exit Sub
                End If
                If Request("t") = "" Then
                    Response.Write("Error s103")
                    Response.End()
                    Exit Sub
                End If

                main.ParaClear()
                main.ParaAdd("@PageID", CurrentId, SqlDbType.Int)
                Dim Folder As String = main.Scalar("select a.App_Folder from User_App a inner join User_Page b on a.IDNo=b.User_App_ID" & _
                                                   " where b.IDNo=@PageID")
                Dim FullPath As String = AppPath & Folder & "\pic\" & comm.ImgSerial(CurrentId, s(1)) & ".jpg"
                If File.Exists(FullPath) = True Then File.Delete(FullPath)

                ' comm.WriteLog(Request("t"))
                'comm.WriteLog(FullPath) 
                Try
                    Dim buf As Byte() = Convert.FromBase64String(Request("t"))
                    Dim TYU As New FileStream(FullPath, FileMode.CreateNew)
                    TYU.Write(buf, 0, buf.Length)
                    TYU.Close() 
                Catch ex As Exception 
                    comm.WriteLog(ex.Message)
                End Try 

                main.ParaAdd("@ImgName", Folder & "/pic/" & comm.ImgSerial(CurrentId, s(1)) & ".jpg", SqlDbType.VarChar)
                main.NonQuery("Update User_Page set IsCopy0" & s(1) & "=0," & CoNum & "=@ImgName where IDNo=@PageID")
                
                Response.Write(Folder & "/pic/" & comm.ImgSerial(CurrentId, s(1)) & ".jpg")
                Response.End()

            End If

            If IsNumeric(Request.QueryString("a")) Then

                Dim AppId As Integer = comm.Cint2(main.Scalar("Select IDNo from User_App where IDNo=" & Request.QueryString("a")))
                If AppId = 0 Then
                    Response.Write("Error s202")
                    Response.End()
                    Exit Sub
                End If 
                If Request("t") = "" Then
                    Response.Write("Error s203")
                    Response.End()
                    Exit Sub
                End If

                main.ParaClear()
                main.ParaAdd("@AppId", AppId, SqlDbType.Int)

                Dim Folder As String = comm.CurrentAppFolder(AppId)
                Dim FullPath As String = AppPath & Folder & "\pic\ico_" & AppId & ".jpg"
                If File.Exists(FullPath) = True Then File.Delete(FullPath)

                ' comm.WriteLog(Request("t"))
                '  comm.WriteLog(FullPath)
                Try
                    Dim buf As Byte() = Convert.FromBase64String(Request("t"))
                    Dim TYU As New FileStream(FullPath, FileMode.CreateNew)
                    TYU.Write(buf, 0, buf.Length)
                    TYU.Close()
                Catch ex As Exception
                    comm.WriteLog(ex.Message)
                End Try

                main.ParaAdd("@App_Icon", "ico_" & AppId & ".jpg", SqlDbType.VarChar)
                main.NonQuery("Update User_App set App_Icon=@App_Icon where IDNo=@AppId")

                Response.Write(Folder & "/pic/ico_" & AppId & ".jpg")
                Response.End()


            End If 
        End If
    End Sub

End Class
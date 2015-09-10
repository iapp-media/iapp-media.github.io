Imports System.Data
Imports System.IO
Public Class see
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim str As String
    Dim SortNum As integer = 1    
    Public AppPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("AppPath")
    Dim Allurl As String = System.Configuration.ConfigurationSettings.AppSettings.Get("url")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("ID")) And IsNumeric(Request.QueryString("EDIT")) Then
            str = " select a.URL,b.IDNo PID,b.Theme_id from Pages a inner join User_Page b ON a.IDNo=b.Page_ID where b.IDNo=" & Request.QueryString("ID")
            Dim DT As DataTable = Main.GetDataSet(str)
            If (DT.Rows.Count > 0) Then
                Dim HH As Integer = 1136
                Dim WD As Integer = 640
                Select Case DT.Rows(0).Item("URL")
                    Case "p03.aspx"
                        HH = 378
                    Case "p04.aspx"
                        HH = 568
                End Select
                 
                Response.Redirect("AUL.aspx?UPID=" & Request.QueryString("ID") & "&Page=" & DT.Rows(0).Item("URL") & "&Img=1&w=" & WD & "&h=" & HH & "")
            Else
                'Response.Redirect("login.aspx") 
            End If
            Response.End()
        ElseIf IsNumeric(Request.QueryString("ID")) Then
            str = "Select a.URL from Pages a inner join User_Page b ON a.IDNo=b.Page_ID where b.IDNo=" & Request.QueryString("ID")
            Dim url As String = Main.Scalar(str)
            If url <> "" Then
                'Response.Write("<br/><br/>               " & url & "?ID=" & Request.QueryString("ID"))
                Response.Redirect(url & "?ID=" & Request.QueryString("ID"))
             End If
            Response.End()
        Else
        End If
    End Sub

    Function CheckPath() As String
        Dim i As Integer
        Dim MP As String = ""
        For i = 0 To 10
            MP = AppPath & Format(SortNum, "0#")
            If Directory.Exists(MP) = False Then
                Directory.CreateDirectory(MP)
            Else
                Dim dirinfo As DirectoryInfo = New DirectoryInfo(MP)
                Dim sortList As FileInfo() = dirinfo.GetFiles()
                If sortList.Length() >= 100 Then
                    SortNum += 1
                    i = 0
                End If
            End If
        Next
        Return MP
    End Function
End Class
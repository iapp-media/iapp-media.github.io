Imports System.IO
Imports System.Web.Mail
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Drawing
Imports System.Text
Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports System.Data

Public Class CommTool
    Inherits System.Web.UI.Page
    Private Main As New DBTool
    Public Url As String = System.Configuration.ConfigurationSettings.AppSettings.Get("Url")
    Public MainPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath")
    Public LOGPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("LOGPath")
    Public ImgPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("ImgPath")
    Public FilePath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("FilePath")
    Public MailFrom As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailFrom")
    Public MailSvr As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailServer") 
    Public MailUID As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailUID")
    Public MailPWD As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailPWD")
    Dim str As String

    Public Sub Auth(ByVal CurrPage As UI.Page)
        If Session("User_ID") = "" Or Session("User_ID") = Nothing Then
            CurrPage.Response.Write("<script>alert('登入逾時，請重新登入');window.open('../Login.aspx','_top');</script>")
            CurrPage.Response.End()
        End If
    End Sub

    Public Sub CleanInput(ByVal pAge As Web.UI.Page)
        For i As Integer = 0 To pAge.Controls.Count - 1
            For Each con As UI.Control In pAge.Controls(i).Controls
                If con.ToString = "System.Web.UI.WebControls.TextBox" Then
                    CType(con, TextBox).Text = CleanStr(CType(con, TextBox).Text)
                End If
            Next
        Next
    End Sub

    Public Function CleanStr(ByVal InputString As String) As String
        Dim KW As String() = {"'", "--", "%", "&", "||"}
        For i As Integer = 0 To KW.Length - 1
            InputString = InputString.Replace(KW(i), "※")
        Next
        Return InputString
    End Function

    Function GoodRequest(ByVal page As Web.UI.Page, ByVal RequestName As String, ByVal DataType As String) As Boolean
        Dim KW As String() = {"'", """", "?", "%", "&", "||"}
        Dim tmp As Boolean = True
        If Not IsNothing(page.Request.QueryString(RequestName)) Then
            If page.Request.QueryString(RequestName) <> "" Then
                Select Case DataType
                    Case "Int"
                        Try
                            Dim cc As Integer = CInt(page.Request.QueryString(RequestName))
                            tmp = True
                        Catch ex As Exception
                            tmp = False
                        End Try
                    Case "String"

                        Dim ss As String = page.Request.QueryString(RequestName)
                        If ss.IndexOf("and") > -1 Then tmp = False
                End Select

            Else
                tmp = False
            End If
        Else
            tmp = False
        End If
        Return tmp
    End Function
     
    Public Function CDate0(ByVal xDate As String) As String '西元日期格式轉成民國日期格式例:0970209
        If IsDate(xDate) = True And xDate.Length > 7 Then
            Dim x As Date = DateAdd(DateInterval.Year, -1911, CDate(xDate))
            Dim imonth As String = CStr(Month(x))
            If Month(x) < 10 Then imonth = "0" & imonth

            Dim iday As String = CStr(Day(x))
            If Day(x) < 10 Then iday = "0" & iday

            Dim iYear As String = CStr(Year(x))
            If Year(x) < 100 Then iYear = "0" & iYear

            Return iYear & imonth & iday
        Else
            Return xDate
        End If
    End Function

    Public Function CTime0(ByVal Time As DateTime) As String '抓時間(到毫秒):09113022
        Dim tmp As String = Time
        If IsDate(Time) = True Then
            tmp = GetFullNum(Time.Hour, 2) & GetFullNum(Time.Minute, 2) & GetFullNum(Time.Second, 2) & GetFullNum(Time.Millisecond, 2)
        End If
        Return tmp
    End Function

    Public Overloads Function Chop(ByVal UserID As String, ByVal UserName As String, ByVal Job As String) As String

        Dim tmp As New StringBuilder
        tmp.Append("<table border=""0"" width=""112"" id=""table1"" cellspacing=""1"" height=""37"">" & vbCrLf)
        tmp.Append("	<tr>")
        tmp.Append("		<td background=""../images/in.jpg"" align=""center"">" & vbCrLf)
        tmp.Append("			<table border=""0"" width=""100%"" id=""table2"" style=""margin-top:2px;"">" & vbCrLf)
        tmp.Append("				<tr>" & vbCrLf)
        tmp.Append("					<td width=""40"" align=""center"" valign=""middle"">" & vbCrLf)

        If Job = "" Then
            Job = Main.Scalar("select Unit3_Name from Users where User_ID='" & UserID & "'")
            If Job = "" Then Job = Main.Scalar("select Unit3_Name from Users_Del where User_ID='" & UserID & "'") '沒有的話去歷史找
        End If


        Dim JJ As Integer = 2   '預設長度
        Dim NN As Integer = 3
        If Job <> "" Then JJ = Job.Length
        If UserName <> "" Then NN = UserName.Length

        Select Case JJ
            Case 2
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:18px"">" & Job & "</font></td>" & vbCrLf)
            Case 3
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:12px"">" & Job & "</font></td>" & vbCrLf)
            Case 4
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:11px"">" & Left(Job, 2) & "<br>" & Right(Job, 2) & "</font></td>" & vbCrLf)
            Case 5
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:9px"">" & Left(Job, 2) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
            Case 6
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Job, 3) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
            Case 7
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Job, 4) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
        End Select

        Select Case NN
            Case 3
                tmp.Append("					<td style=""font-size:18px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case 4
                tmp.Append("					<td style=""font-size:14px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case 5
                tmp.Append("					<td style=""font-size:12px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case Else
                tmp.Append("					<td style=""font-size:18px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
        End Select

        tmp.Append("				</tr>" & vbCrLf)
        tmp.Append("			</table>" & vbCrLf)
        tmp.Append("		</td>" & vbCrLf)
        tmp.Append("	</tr>" & vbCrLf)
        tmp.Append("</table>" & vbCrLf)

        Return tmp.ToString()
    End Function


    Public Overloads Function Chop(ByVal UserID As String, ByVal UserName As String) As String

        Dim tmp As New StringBuilder
        tmp.Append("<table border=""0"" width=""112"" id=""table1"" cellspacing=""1"" height=""37"">" & vbCrLf)
        tmp.Append("	<tr>")
        tmp.Append("		<td background=""../images/in.jpg"" align=""center"">" & vbCrLf)
        tmp.Append("			<table border=""0"" width=""100%"" id=""table2"" style=""margin-top:2px;"">" & vbCrLf)
        tmp.Append("				<tr>" & vbCrLf)
        tmp.Append("					<td width=""40"" align=""center"" valign=""middle"">" & vbCrLf)

        Dim Job As String = Main.Scalar("select Unit3_Name from Users where User_ID='" & UserID & "'")
        'If Job = "" Then Job = Main.Scalar("select Job from Users_Del where User_ID='" & UserID & "'") '沒有的話去歷史找

        Dim JJ As Integer = 2   '預設長度
        Dim NN As Integer = 3
        If Job <> "" Then JJ = Job.Length
        If UserName <> "" Then NN = UserName.Length

        Select Case JJ
            Case 2
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:18px"">" & Job & "</font></td>" & vbCrLf)
            Case 3
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:12px"">" & Job & "</font></td>" & vbCrLf)
            Case 4
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:11px"">" & Left(Job, 2) & "<br>" & Right(Job, 2) & "</font></td>" & vbCrLf)
            Case 5
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:9px"">" & Left(Job, 2) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
            Case 6
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Job, 3) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
            Case 7
                tmp.Append("<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Job, 4) & "<br>" & Right(Job, 3) & "</font></td>" & vbCrLf)
        End Select

        Select Case NN
            Case 3
                tmp.Append("					<td style=""font-size:18px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case 4
                tmp.Append("					<td style=""font-size:14px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case 5
                tmp.Append("					<td style=""font-size:12px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
            Case Else
                tmp.Append("					<td style=""font-size:18px""><font face=""標楷體"" color=""#DF0104"">" & UserName & "</font></td>" & vbCrLf)
        End Select

        tmp.Append("				</tr>" & vbCrLf)
        tmp.Append("			</table>" & vbCrLf)
        tmp.Append("		</td>" & vbCrLf)
        tmp.Append("	</tr>" & vbCrLf)
        tmp.Append("</table>" & vbCrLf)

        Return tmp.ToString()
    End Function


    Public Function GetUnit(ByVal UnID As String, ByVal DT As DataTable) As String
        Dim tmp As String = ""
        If DT.Rows.Count > 0 Then
            For i As Integer = 0 To DT.Rows.Count - 1
                If CStr(DT.Rows(i).Item("IDNo")) = CStr(UnID) Then
                    tmp = DT.Rows(i).Item("Name")
                    Exit For
                End If
            Next
        End If
        Return tmp
    End Function

    'Public Function Chop(ByVal UserID As String) As String
    '    Dim tmp As String = ""
    '    str = "Select Job,User_Name from Users where User_ID = '" & UserID & "' or User_Name =  '" & UserID & "'"
    '    Dim DT As DataTable = Main.GetDataSet(str)
    '    If DT.Rows.Count > 0 Then
    '        tmp += "<table border=""0"" width=""112"" id=""table1"" cellspacing=""1"" height=""37"">"
    '        tmp += "	<tr>"
    '        tmp += "		<td background=""../images/in.jpg"" align=""center"">"
    '        tmp += "			<table border=""0"" width=""100%"" id=""table2"" style=""margin-top:5px;"">"
    '        tmp += "				<tr>"
    '        tmp += "					<td width=""40"" align=""center"" valign=""middle"">"
    '        Dim nn As Integer = CStr(DT.Rows(0).Item("Job")).Length
    '        Dim Title As String = DT.Rows(0).Item("Job")

    '        Select Case nn
    '            Case 2
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:18px"">" & Title & "</font></td>"
    '            Case 3
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:12px"">" & Title & "</font></td>"
    '            Case 4
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:9px"">" & Title & "</font></td>"
    '            Case 5
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Title, 2) & "<br>" & Right(Title, 3) & "</font></td>"
    '            Case 6
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Title, 3) & "<br>" & Right(Title, 3) & "</font></td>"
    '            Case 7
    '                tmp += "<font face=""標楷體"" color=""#DF0104"" style=""font-size:8px"">" & Left(Title, 4) & "<br>" & Right(Title, 3) & "</font></td>"
    '        End Select
    '        tmp += "					<td style=""font-size:18px""><font face=""標楷體"" color=""#DF0104"">" & DT.Rows(0).Item("User_Name") & "</font></td>"
    '        tmp += "				</tr>"
    '        tmp += "			</table>"
    '        tmp += "		</td>"
    '        tmp += "	</tr>"
    '        tmp += "</table>"
    '    Else
    '        tmp = UserID
    '    End If
    '    Return tmp
    'End Function
 
    Public Function GetFiles(ByVal TableName As String, ByVal TableID As String, ByVal CBL As CheckBoxList)
        str = "Select FileName,FilePath from Files where xTable='" & TableName & "' and Table_ID = '" & TableID & "'"
        Dim DT As DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim LI As New ListItem
                LI.Text = "<a href=""../" & DT.Rows(i).Item("FilePath") & """ target=""_blank"">" & DT.Rows(i).Item("FileName") & "</a>"
                LI.Value = DT.Rows(i).Item("FilePath") & "," & DT.Rows(i).Item("FileName")
                CBL.Items.Add(LI)
            Next
        End If
        Return True
    End Function

    Public Function SendAlert(ByVal UID As String, ByVal xTab As String, ByVal TabID As String, ByVal TabNa As String, ByVal Title As String, ByVal Cont As String) As String
        str = "insert into Alerts (User_ID,From_Table,Form_ID,Alert_From,Alert_Cont,Alert_Start,Alert_Check,Alert_Pop)"
        str += " values ('" & UID & "','" & xTab & "','" & TabID & "','" & TabNa & "','" & Title & "','" & Cont & "',getdate(),0,0)"
        Return Main.NonQuery(str)
    End Function

    Public Function StrAlert(ByVal UID As String, ByVal xTab As String, ByVal TabID As String, ByVal TabNa As String, ByVal Title As String, ByVal Cont As String) As String
        '傳回str而已(沒執行)
        str = "insert into Alerts (User_ID,From_Table,From_ID,Alert_From,Alert_Cont,Alert_Start,Alert_Check,Alert_Pop)"
        str += " values ('" & UID & "','" & xTab & "','" & TabID & "','" & Title & "','" & Cont & "',getdate(),0,0)"
        Return str
    End Function

    Public Overloads Function FillDDP(ByVal DDP As DropDownList, ByVal strsql As String, ByVal Text As String, ByVal Value As String, Optional ByVal FirstText As String = "")
        DDP.Items.Clear()
        DDP.Items.Add(FirstText)  '即使沒有也將空白加入(防止-1)
        Dim DT As DataTable = Main.GetDataSetNoNull(strsql)
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(Text) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(Text)
                    TT.Value = DT.Rows(i).Item(Value)
                    DDP.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP2(ByVal DDP As DropDownList, ByVal strsql As String, ByVal Text As String, ByVal Value As String, Optional ByVal FirstText As String = "")
        DDP.Items.Clear()
         Dim DT As DataTable = Main.GetDataSetNoNull(strsql)
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(Text) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(Text)
                    TT.Value = DT.Rows(i).Item(Value)
                    DDP.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal DDP As ListBox, ByVal strsql As String, ByVal Text As String, ByVal Value As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        DDP.Items.Clear()
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(Text) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(Text)
                    TT.Value = DT.Rows(i).Item(Value)
                    DDP.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal DDP As RadioButtonList, ByVal strsql As String, ByVal Text As String, ByVal Value As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        DDP.Items.Clear()
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(Text) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(Text)
                    TT.Value = DT.Rows(i).Item(Value)
                    DDP.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal DDP As CheckBoxList, ByVal strsql As String, ByVal Text As String, ByVal Value As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        DDP.Items.Clear()
        If Not IsDBNull(Text) Then
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(Text)
                    TT.Value = DT.Rows(i).Item(Value)
                    DDP.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function GetDDL(ByVal DDL As DropDownList, ByVal strDT As String)
        DDL.SelectedIndex = -1 '解除全部
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To DDL.Items.Count - 1
                If DDL.Items(i).Value = CStr(strDT) Then
                    DDL.Items(i).Selected = True
                    Exit For '防止重複
                End If
            Next
        End If
        Return True
    End Function

    Public Overloads Function GetDDLtext(ByVal DDL As DropDownList, ByVal strDT As String)
        DDL.SelectedIndex = -1 '解除全部
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To DDL.Items.Count - 1
                If DDL.Items(i).Text = CStr(strDT) Then
                    DDL.Items(i).Selected = True
                    Exit For '防止重複
                End If
            Next
        End If
        Return True
    End Function

    Public Overloads Function GetDDL(ByVal RBL As RadioButtonList, ByVal strDT As String)
        RBL.SelectedIndex = -1
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To RBL.Items.Count - 1
                If RBL.Items(i).Value = CStr(strDT) Then
                    RBL.Items(i).Selected = True
                    Exit For '防止重複
                End If
            Next
        End If
        Return True
    End Function

    Public Overloads Function GetDDLtext(ByVal RBL As RadioButtonList, ByVal strDT As String)
        RBL.SelectedIndex = -1
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To RBL.Items.Count - 1
                If RBL.Items(i).Text = CStr(strDT) Then
                    RBL.Items(i).Selected = True
                    Exit For '防止重複
                End If
            Next
        End If
        Return True
    End Function

    Public Overloads Function GetDDL(ByVal CBL As CheckBoxList, ByVal strDT As String)
        'CBL.SelectedIndex = -1  '複選型的 不用解除
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To CBL.Items.Count - 1
                If CBL.Items(i).Value = CStr(strDT) Then
                    CBL.Items(i).Selected = True
                End If
            Next
        End If
        Return True
    End Function

    Public Overloads Function GetDDLtext(ByVal CBL As CheckBoxList, ByVal strDT As String)
        'CBL.SelectedIndex = -1
        If Not IsDBNull(strDT) Then
            For i As Integer = 0 To CBL.Items.Count - 1
                If CBL.Items(i).Text = CStr(strDT) Then
                    CBL.Items(i).Selected = True
                End If
            Next
        End If
        Return True
    End Function

    Public Function GetDate(ByVal ToDate As Date) As String '普通日期格式轉SQL用格式
        Dim xDate As String = ToDate.ToShortDateString()
        Dim xTime As String = Hour(ToDate) & ":" & Minute(ToDate) & ":" & Second(ToDate)
        Dim tmp As String = xDate & " " & xTime
        Return tmp
    End Function

    Public Function GetCCDate(ByVal ToDate As String) As String '普通日期格式轉有年月日的民國年
        If IsDate(ToDate) = True And CStr(ToDate).Length >= 8 Then
            ToDate = Year(ToDate) - 1911 & "年 " & Month(ToDate) & "月 " & Day(ToDate) & "日"
        End If
        Return ToDate
    End Function

    Public Function Chdate(ByVal xDate As String) As String '西元日期格式轉成民國日期格式例:097/02/09
        If IsDate(xDate) = True And xDate.Length > 7 Then
            Dim x As Date = DateAdd(DateInterval.Year, -1911, CDate(xDate))
            Dim imonth As String = CStr(Month(x))
            If Month(x) < 10 Then imonth = "0" & imonth

            Dim iday As String = CStr(Day(x))
            If Day(x) < 10 Then iday = "0" & iday

            Dim iYear As String = CStr(Year(x))
            If Year(x) < 100 Then iYear = "0" & iYear

            Return iYear & "/" & imonth & "/" & iday
        Else
            Return xDate
        End If
    End Function

    Public Function ChkType(ByVal xfile As HttpPostedFile, ByVal xType As String) As Boolean '下方應用
        Dim tmp As String = xfile.ContentType
        If InStr(tmp, xType) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SaveBmp(ByVal afile As HttpPostedFile, ByVal boxwidth As Integer, ByVal boxheight As Integer, ByVal Img As String)
        Dim scale As Double = 0
        Dim filename As String = ""
        Dim file2 As String = ""
        Dim y As DateTime = Now
        Dim tmp As String = ""
        Dim result As String = ""
        If ChkType(afile, "image") = False Then
            Return ""
            Exit Function
        End If
        tmp = (Year(Now) - 1911) & Month(Now) & Day(Now) & Replace(y.TimeOfDay.ToString, ":", "").Substring(0, 6)

        If Not Directory.Exists(MainPath & FilePath & Img) Then
            Directory.CreateDirectory(MainPath & FilePath & Img)
        End If

        If afile.ContentLength <> 0 Then
            filename = MainPath & FilePath & Img & tmp & Path.GetExtension(afile.FileName)
            file2 = MainPath & FilePath & Img & tmp & "_s" & Path.GetExtension(afile.FileName)
            afile.SaveAs(filename)
            result = FilePath & Img & tmp & "_s" & Path.GetExtension(afile.FileName)
        End If

        Dim inbmp As Bitmap = New Bitmap(filename)
        If inbmp.Height < boxheight And inbmp.Width < boxwidth Then
            scale = 1
        Else
            If (inbmp.Width * boxheight / inbmp.Height < boxwidth) Then
                scale = (boxheight) / inbmp.Height
            Else
                scale = (boxwidth) / inbmp.Width
            End If
        End If
        Dim newwidth As Integer = CInt(scale * inbmp.Width)
        Dim newheight As Integer = CInt(scale * inbmp.Height)
        Dim outbmp As Bitmap = New Bitmap(inbmp, newwidth, newheight)
        outbmp.Save(file2)
        outbmp.Dispose()

        If Img = "Photo\" Then  '活動剪影才用
            '做大圖
            boxwidth = 600
            boxheight = 450
            If inbmp.Height < boxheight And inbmp.Width < boxwidth Then
                scale = 1
            Else
                If (inbmp.Width * boxheight / inbmp.Height < boxwidth) Then
                    scale = (boxheight) / inbmp.Height
                Else
                    scale = (boxwidth) / inbmp.Width
                End If
            End If
            newwidth = CInt(scale * inbmp.Width)
            newheight = CInt(scale * inbmp.Height)
            outbmp = New Bitmap(inbmp, newwidth, newheight)
            outbmp.Save(file2.Replace("_s", "_l"))
            outbmp.Dispose()
        End If

        inbmp.Dispose()  '最後再關
        Return result
    End Function

    Public Function GetDateString(ByVal dd As DateTime) As String '抓詳細時間(到秒)
        Dim tmp As String = CStr(dd.Year - 1911)
        tmp += GetFullNum(dd.Month, 2)
        tmp += GetFullNum(dd.Day, 2)
        tmp += GetFullNum(dd.Hour, 2)
        tmp += GetFullNum(dd.Minute, 2)
        tmp += GetFullNum(dd.Second, 2)
        Return tmp
    End Function

    Public Function GetFullNum(ByVal num As Integer, ByVal size As Integer) As String '補0
        Dim tmp As String = num.ToString()

        If size >= tmp.Length Then
            Do Until tmp.Length = size
                tmp = "0" & tmp
            Loop
        End If

        Return tmp
    End Function

    Public Function CMoney(ByVal cc As Integer)
        Dim tmp As String = ""
        Dim aa() As Char = cc.ToString.ToCharArray()
        Dim bb(aa.Length) As String
        For i As Integer = 0 To aa.Length - 1
            bb(aa.Length - 1 - i) = CNUM(aa(i))
        Next
        If bb(0) = "零" Then bb(0) = ""
        If bb.Length > 1 Then If bb(1) <> "" Then bb(1) += "拾"
        If bb.Length > 2 Then If bb(2) <> "" Then bb(2) += "佰"
        If bb.Length > 3 Then If bb(3) <> "" Then bb(3) += "仟"
        If bb.Length > 5 Then bb(4) += "萬"

        If bb.Length > 5 Then
            If bb(5) <> "" Then bb(5) += "拾"
        End If
        If bb.Length > 6 Then
            If bb(6) <> "" Then bb(6) += "佰"
        End If
        If bb.Length > 7 Then
            If bb(7) <> "" Then bb(7) += "仟"
        End If
        If bb.Length > 8 Then
            If bb(8) <> "" Then bb(8) += "億"
        End If
        For i As Integer = 0 To bb.Length - 1
            tmp = bb(i) & tmp
        Next
        Return tmp
    End Function

    Public Function ToMoney(ByVal num As Integer)

        Dim tmp As String = ""
        Dim CC As Char() = num.ToString.ToCharArray()
        Dim c As Integer = 0
        For i As Integer = CC.Length - 1 To 0 Step -1
            c += 1
            If c > 1 And c Mod 3 = 1 Then tmp = "," & tmp
            tmp = CC(i).ToString & tmp
        Next
        Return tmp
    End Function

    Public Function CNUM(ByVal a As Char) As String
        Dim tmp As String = ""
        Select Case CStr(a)
            Case "1"
                tmp = "壹"
            Case "2"
                tmp = "貳"
            Case "3"
                tmp = "參"
            Case "4"
                tmp = "肆"
            Case "5"
                tmp = "伍"
            Case "6"
                tmp = "陸"
            Case "7"
                tmp = "柒"
            Case "8"
                tmp = "捌"
            Case "9"
                tmp = "玖"
            Case "0"
                tmp = ""

        End Select
        Return tmp
    End Function

    Function GetWeek(ByVal Dat As Date) As String
        Dim DD As String = Weekday(Dat)
        Dim tmp As String = ""
        Select Case DD
            Case "1"
                tmp = "星期日"
            Case "2"
                tmp = "星期一"
            Case "3"
                tmp = "星期二"
            Case "4"
                tmp = "星期三"
            Case "5"
                tmp = "星期四"
            Case "6"
                tmp = "星期五"
            Case "7"
                tmp = "星期六"
        End Select
        Return tmp
    End Function

    Public Function ChkPerID(ByVal PerID As String) As Boolean '檢查身分證字號（簡易的
        Dim BL As Boolean = True
        If PerID.Length <> 10 Then BL = False
        If (Left(PerID, 1) < "A" Or Left(PerID, 1) > "Z") Then BL = False
        If IsNumeric(Mid(PerID, 2)) = False Then BL = False
        Return BL
    End Function

    Function GetAMPM(ByVal AMPM As String) As String  '(公務車用)
        Dim tmp As String = ""
        Select Case AMPM
            Case "AM"
                tmp = "上午"
            Case "PM"
                tmp = "下午"
            Case Else
                tmp = ""
        End Select
        Return tmp
    End Function

    Public Function GridViewToDataTable(ByVal GV As GridView) As DataTable
        Dim DT As New DataTable
        If GV.Rows.Count > 0 Then
            For i As Integer = 0 To GV.Columns.Count - 1
                DT.Columns.Add(GV.Columns(i).HeaderText)
            Next
            For i As Integer = 0 To GV.Rows.Count - 1

                Dim rw As DataRow = DT.NewRow()
                For j As Integer = 0 To GV.Columns.Count - 1
                    rw(j) = GV.Rows(i).Cells(j).Text
                Next
                DT.Rows.Add(rw)
            Next
        End If
        Return DT
    End Function

    '簽核用訊息
    Public Function Flow_Alert(ByVal IDNo As String, ByVal Page As String, ByVal xTab As String, ByVal TabID As String, ByVal TabNa As String, ByVal Title As String, ByVal Cont As String)
        str = "select b.Type,b.Who,b.Unit1_ID,b.Unit_ID,b.Role_ID, a.Form_Table,a.Form_Name from Form_Apply a,Flow_Approve b where a.IDNo=b.Apply_ID and a.Flow_Sort=b.Sort and a.IDNo='" & IDNo & "'"
        Me.WriteLog("Flow_Alert:" & str)
        Dim DD As Data.DataTable = Main.GetDataSetNoNull(str)
        If DD.Rows.Count > 0 Then
            Dim UID As String = ""
            Select Case DD.Rows(0).Item("Type")
                Case "1" '主管
                    UID = Main.Scalar("select Boss_ID from _Unit where IDNo='" & DD.Rows(0).Item("Unit1_ID") & "'")
                    str = StrAlert(UID, xTab, TabID, TabNa, Title, Cont)

                Case "2" '股長
                    UID = Main.Scalar("select Boss_ID from _Unit where IDNo='" & DD.Rows(0).Item("Unit_ID") & "'")
                    str = StrAlert(UID, xTab, TabID, TabNa, Title, Cont)

                Case "3" '管理者
                    Dim DT As Data.DataTable = Main.GetDataSetNoNull("select a.Access_User from User_Access a,Access_Group_List b,Menu c where a.Group_ID=b.Group_ID and b.Access_ID=c.IDNo and c.Href like '%" & Page & "'")
                    If DT.Rows.Count > 0 Then
                        For i As Integer = 0 To DT.Rows.Count - 1
                            str += StrAlert(DT.Rows(i).Item("Access_User"), xTab, TabID, TabNa, Title, Cont)
                        Next
                    End If
                Case "4" '特殊
                    Dim DT As Data.DataTable = Main.GetDataSetNoNull("select b.User_ID from Flow_Role a,Flow_Role_User b where a.IDNo=b.Role_ID and a.IDNo='" & DD.Rows(0).Item("Role_ID") & "' and b.User_ID in (select User_ID from Users where Unit1_ID='" & DD.Rows(0).Item("Unit1_ID") & "')")
                    If DT.Rows.Count > 0 Then
                        For i As Integer = 0 To DT.Rows.Count - 1
                            str += StrAlert(DT.Rows(i).Item("User_ID"), xTab, TabID, TabNa, Title, Cont)
                        Next
                    End If
                Case "0" '結案
                    If Page = "NPA_Mana.aspx" Then '完成回寄給管理者 (特殊)
                        UID = Main.Scalar("select a.Access_User from User_Access a,Access_Group_List b,Menu c where a.Group_ID=b.Group_ID and b.Access_ID=c.IDNo and c.Href like '%" & Page & "'")
                        str += StrAlert(UID, xTab, TabID, TabNa, Title, Cont)
                    End If

                    Dim mess As String = ""
                    Select Case DD.Rows(0).Item("Form_Table")
                        Case "Form_Apply"
                            mess = "請至個人申請記錄查詢。"
                        Case "AD_PWD"
                            mess = ""
                        Case Else
                            mess = "請至" & DD.Rows(0).Item("Form_Name") & "管理查詢。"
                    End Select

                    UID = Main.Scalar("select User_ID from Form_Apply where IDNo='" & IDNo & "'")
                    Cont = "您的申請:[" & TabNa & "]已結案。" & mess

                    str += StrAlert(UID, xTab, TabID, TabNa, Title, Cont)
            End Select
        End If

        '都是特殊人員
        If DD.Rows.Count > 0 Then
            Dim DT As Data.DataTable = Main.GetDataSetNoNull("select b.User_ID from Flow_Role a,Flow_Role_User b where a.IDNo=b.Role_ID and a.IDNo='" & DD.Rows(0).Item("Role_ID") & "' and b.User_ID in (select User_ID from Users where Unit1_ID='" & DD.Rows(0).Item("Unit1_ID") & "')")
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    str += StrAlert(DT.Rows(i).Item("User_ID"), xTab, TabID, TabNa, Title, Cont)
                Next
            End If

        End If
        Return str
    End Function

    '簽核輪到誰 (特殊多人的抓無 JBD
    Public Function Flow_User(ByVal IDNo As String, ByVal Page As String) As String
        Dim UID As String = ""
        Dim DD As Data.DataTable = Main.GetDataSetNoNull("select b.Type,b.Who,b.Unit1_ID,b.Unit_ID,b.Role_ID from Form_Apply a,Flow_Approve b where a.Apply_ID=b.Apply_ID and a.Flow_Sort=b.Sort and a.IDNo='" & IDNo & "'")
        If DD.Rows.Count > 0 Then
            Select Case CStr(DD.Rows(0).Item("Type"))
                Case "1" '主管
                    UID = Main.Scalar("select a.User_Name from Users a,_Unit b where a.User_ID=b.Boss_ID and b.IDNo='" & DD.Rows(0).Item("Unit1_ID") & "'")

                Case "2" '股長
                    UID = Main.Scalar("select a.User_Name from Users a,_Unit b where a.User_ID=b.Boss_ID and b.IDNo='" & DD.Rows(0).Item("Unit_ID") & "'")

                Case "3" '管理者
                    Select Case CStr(Page)
                        Case "Agent"
                            Page = "Agent_Mana.aspx"
                        Case "Allowance"
                            Page = "Allowance_Mana.aspx"
                        Case "JBDApply"
                            Dim SS As String = Main.Scalar("select b.Flow_Name from Form_Apply a,Flow_Approve b where a.Apply_ID=b.Apply_ID and a.Flow_Sort=b.Sort and b.Type=3 and a.IDNo=" & IDNo)
                            If SS = "管制員" Then
                                Page = "JBD_Mana.aspx"
                            ElseIf SS = "資訊單位股長" Then
                                Page = "JBD_Mana2.aspx"
                            Else
                                Page = ""
                            End If
                        Case "NPA"
                            Page = "NPA_Mana.aspx"
                        Case "Reward"
                            Page = "Reward_Mana.aspx"
                        Case "ApplyTrain"
                            Page = "Train_Mana.aspx"
                        Case "JBDTPWD"
                            Page = "JBDT_Mana.aspx"
                        Case "TaipeiCT"
                            Page = "TaipeiCT_Mana.aspx"
                            Dim SS As String = Main.Scalar("select b.Flow_Name from Form_Apply a,Flow_Approve b where a.IDNo=b.Apply_ID and a.Flow_Sort=b.Sort and b.Type=3 and a.IDNo=" & IDNo)
                            If SS = "員工愛上網" Then
                                Page = "TaipeiCT_Mana.aspx"
                            ElseIf SS = "市政資料庫" Then
                                Page = "TaipeiCT_Mana2.aspx"
                            Else
                                Page = ""
                            End If

                        Case Else    '表單生成
                            Dim TT As String = Main.Scalar("select a.Title from Form a,Form_Apply where a.IDNo=b.Form_ID and b.IDNo=" & IDNo)
                            Page = "FormApply_Mana.aspx?form=" & IDNo
                    End Select
                    If Page <> "" Then
                        Dim DT As Data.DataTable = Main.GetDataSetNoNull("select d.User_Name from User_Access a,Access_Group_List b,Menu c,Users d where a.Group_ID=b.Group_ID and b.Access_ID=c.IDNo and c.Href like '%" & Page & "' and a.Access_User=d.User_ID")
                        If DT.Rows.Count > 0 Then
                            For i As Integer = 0 To DT.Rows.Count - 1
                                UID += "," & DT.Rows(i).Item("User_Name")
                            Next
                            If UID <> "" Then UID = UID.Substring(1)
                        End If
                    End If

                Case "4" '特殊
                    Dim DT As Data.DataTable = Main.GetDataSetNoNull("select b.User_Name from Flow_Role a,Flow_Role_User b where a.IDNo=b.Role_ID and a.IDNo='" & DD.Rows(0).Item("Role_ID") & "' and b.User_ID in (select User_ID from Users where Unit1_ID='" & DD.Rows(0).Item("Unit1_ID") & "')")
                    If DT.Rows.Count > 0 Then
                        For i As Integer = 0 To DT.Rows.Count - 1
                            UID += "," & DT.Rows(i).Item("User_Name")
                        Next
                        If UID <> "" Then UID = UID.Substring(1)
                    End If
            End Select
        End If
        Return UID
    End Function

    Public Function Flow_Status(ByVal Status As String) As String
        If Status <> "已結案" Then
            If Status <> "不核准" Then
                If Status <> "簽准完畢" Then  'Reward
                    If Status <> "使用者確認" Then 'JBDApply
                        Status = Status & "簽核中"
                    End If
                End If
            End If
        End If
        Return Status
    End Function

    Public Function Flow_Log(ByVal Form_ID As String, ByVal DoIt As String, ByVal IP As String)
        str = "insert into Form_Log (Numbers,Form_Name,Form_ID,Creat_Date,User_ID,User_Name,Do,IP)" & _
              " select Form_Numbers,Form_Name,IDNo,getdate(),'" & Session("User_ID") & "',N'" & Session("User_Name") & "','" & DoIt & "','" & IP & "' from Form_Apply where IDNo='" & Form_ID & "'; "
        Return str
    End Function

    'DataTable 2 Excel CSV
    Public Function DataTableToExcelCSV(ByRef DataTable As DataTable, Optional ByVal separaterWord As String = vbTab) As String
        Dim buffer As String = ""

        '產出表頭
        For Each column As Data.DataColumn In DataTable.Columns
            '輸出表頭，但是匯出時檢查是否有 separaterWord , 因為 separaterWord 是分隔字元
            buffer += Replace(column.ColumnName, separaterWord, "") & separaterWord
        Next
        If buffer <> "" Then
            If Right(buffer, Len(separaterWord)) = separaterWord Then buffer = buffer.Substring(0, Len(buffer) - Len(separaterWord))
        End If
        buffer += vbCrLf
        '依照欄位格式產出表身
        For Each row As DataRow In DataTable.Rows
            '每個欄位
            For i As Integer = 0 To DataTable.Columns.Count - 1
                Dim dat As String = "" & row.Item(i)
                '檢查是否有 separaterWord , 因為 separaterWord 是分隔字元
                dat = Replace(dat, separaterWord, "")
                '如果是字串型態，加一個 char(128)避免值全是 數字時，被轉成數字
                buffer += "" & dat '& IIf(DataTable.Columns(i).DataType.Name = "String" And IsNumeric(dat), Chr(128), "")
                '如果不是最後一欄，則加入分隔符號
                If i <> DataTable.Columns.Count - 1 Then
                    buffer += separaterWord
                End If
            Next
            buffer += vbCrLf
        Next
        '傳回
        DataTableToExcelCSV = buffer
    End Function

    '自動下載某個檔案 (從文字資料)
    '需設定  <globalization requestEncoding="BIG5" responseEncoding="BIG5" /> 

    Public Function GetXLSData2(ByVal FileName As String, ByVal SelectString As String) As Data.DataTable

        ' str = "SELECT Mark,ProductID,ProductNameCHT,NewID,Head3,Head4 FROM [Product_Def$]"
        Dim DataBase As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & MainPath & FileName & ";Extended Properties=""EXCEL 8.0;IMEX=1"""
        Dim xlsDS As Data.DataTable = New Data.DataTable
        Dim xlsConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(DataBase)
        Dim xlsCMD As OleDb.OleDbCommand = New OleDb.OleDbCommand(SelectString, xlsConn)
        Dim xlsADP As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(xlsCMD)
        Try
            xlsConn.Open()
            xlsADP.Fill(xlsDS)
            xlsConn.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            xlsDS.Dispose()
        Finally
            xlsConn.Close()
        End Try
        Return xlsDS
    End Function

    Shared Function DownloadFile(ByVal WebForm As System.Web.UI.Page, ByVal FileNameWhenUserDownload As String, ByVal FileBody As String)
        WebForm.Response.ClearHeaders()
        WebForm.Response.Clear()
        WebForm.Response.Expires = 0
        WebForm.Response.Buffer = True

        WebForm.Response.AddHeader("Accept-Language", "zh-tw")
        WebForm.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(FileNameWhenUserDownload, System.Text.Encoding.UTF8) & Chr(34))
        WebForm.Response.ContentType = "Application/octet-stream"

        'byte [] BB = System.Text.Encoding.GetEncoding("big5").GetBytes(Content);
        Dim buf() As Byte = Encoding.GetEncoding("big5").GetBytes(FileBody) '直接轉big5

        '  WebForm.Response.Write(FileBody)
        WebForm.Response.BinaryWrite(buf)
        WebForm.Response.End()
        Return True
    End Function

    '新的Download
    Shared Function DownloadFile(ByVal WebForm As System.Web.UI.Page, ByVal FilePath As String) As Boolean
        Dim FileName As String
        '取得檔名
        FileName = FilePath
        '取得檔案
        Dim aa As New FileStream(FileName, FileMode.Open)
        Dim buf(aa.Length) As Byte

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
        Shell("taskkill /im EXCEL.EXE")
        WebForm.Response.End()
        Return True
    End Function

    Sub DDLTree(ByVal DDL As DropDownList, ByVal Ref As String, ByVal xTable As String, ByVal xName As String, ByVal xIDNo As String, ByVal xRef As String)
        '起點的值,資料庫內(Table名稱,DDL外面的名稱,DDL裡面的名稱,關連的值)
        If DDL.SelectedValue = "" Then Exit Sub

        '先記住這次DDL變動的直 不然變動後抓不到(皆以此的直為準)
        Dim Text As String = DDL.SelectedItem.Text
        Dim Value As String = DDL.SelectedValue

        '有東西才變換
        str = "select " & xName & "," & xIDNo & " from " & xTable & " where " & xRef & "='" & Value & "' order by " & xName
        Dim DT As DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            Dim RR As String = Main.Scalar("select " & xRef & " from " & xTable & " where " & xIDNo & "='" & Value & "'") '抓自己的Ref
            If RR <> "" Then Ref = RR
            DDL.Items.Clear()

            '下一層的話增加原本點選的內容跟回上一層,碰到起點直的話補上空白  (碰上要選擇單位時有用)
            If Value <> Ref Then

                '從第三層以下上來的名稱需重抓
                If Text <> "回上一層" Then
                    Dim DDLLI As New ListItem
                    DDLLI.Text = Text
                    DDLLI.Value = Value
                    DDL.Items.Add(DDLLI)
                Else
                    Dim DD As String = Main.Scalar("select " & xName & " from " & xTable & " where " & xIDNo & "='" & Value & "'")
                    Dim DDLLI As New ListItem
                    DDLLI.Text = DD
                    DDLLI.Value = Value
                    DDL.Items.Add(DDLLI)
                End If

                Dim LI As New ListItem
                LI.Text = "回上一層"
                LI.Value = Ref
                DDL.Items.Add(LI)
            Else
                Dim LI As New ListItem
                LI.Text = ""
                LI.Value = Ref
                DDL.Items.Add(LI)
            End If

            '最後內容囉~
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim LII As New ListItem
                LII.Text = DT.Rows(i).Item(xName)
                LII.Value = DT.Rows(i).Item(xIDNo)
                DDL.Items.Add(LII)
            Next
        End If
    End Sub

    Sub GetDDLTree(ByVal DDL As DropDownList, ByVal GetID As String, ByVal Ref As String, ByVal xTable As String, ByVal xIDNo As String, ByVal xName As String, ByVal xRef As String)
        str = "select " & xIDNo & "," & xName & "," & xRef & " from " & xTable & " where " & xRef
        str += " in (select " & xRef & " from " & xTable & " where " & xIDNo & "=" & GetID & ") order by " & xName
        Dim DT As DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
            DDL.Items.Clear() '有物件才清除


            If DT.Rows(0).Item(xRef) <> "ref Then" Then
                Dim DD As DataTable = Main.GetDataSetNoNull("select " & xIDNo & "," & xName & "," & xRef & " from " & xTable & " where " & xIDNo & "=" & DT.Rows(0).Item(xRef) & " order by " & xName)
                If DD.Rows.Count > 0 Then
                    Dim LII As New ListItem
                    LII.Text = DD.Rows(0).Item(xName)
                    LII.Value = DD.Rows(0).Item(xIDNo)
                    DDL.Items.Add(LII)

                    Dim LII2 As New ListItem
                    LII2.Text = "回上一層"
                    LII2.Value = DD.Rows(0).Item(xRef)
                    DDL.Items.Add(LII2)
                End If
            Else
                Dim LII As New ListItem
                LII.Text = ""
                LII.Value = DT.Rows(0).Item(xRef)
                DDL.Items.Add(LII)
            End If


            For i As Integer = 0 To DT.Rows.Count - 1
                Dim LI As New ListItem
                LI.Text = DT.Rows(i).Item(xName)
                LI.Value = DT.Rows(i).Item(xIDNo)
                DDL.Items.Add(LI)
            Next
            GetDDL(DDL, GetID)
        End If
    End Sub
 
    Public Function EnCrypTo(ByVal InputString As String) As String '鎖碼
        Dim result As String = ""
        Try
            Dim aa As String = "0123456789abcdefghijklmnopqrstuvwxyz"
            Dim r1 As Char() = aa.ToCharArray()
            Dim r2 As String() = {"ygsu", "v2zf", "cnj9", "3hko", "80at", "lr7e", "m4wp", "xi15", "db6q", "f57q", "lnbe", "vzh0", "a4i1", "wgm9", "8soj", "rtcd", "u2y3", "kp6x", "6n1q", "vkh0", "mydg", "sc38", "oztj", "ifl9", "2ab4", "p7eu", "5rxw", "a942", "1i0x", "octu", "f5pe", "dkgq", "vjlr", "bwyz", "73nm", "f68u"}
            Dim istr As Char() = InputString.ToLower.ToCharArray()
            For i As Integer = 0 To istr.Length - 1
                For j As Integer = 0 To r1.Length - 1
                    If istr(i) = r1(j) Then
                        result += r2(j)
                    End If
                Next
            Next
        Catch ex As Exception
            result = InputString
        End Try
        Return result
    End Function

    Public Function DeCrypTo(ByVal InputString As String) As String '解碼
        Dim result As String = ""
        Try
            Dim aa As String = "0123456789abcdefghijklmnopqrstuvwxyz"
            Dim r1 As Char() = aa.ToCharArray()
            Dim r2 As String() = {"ygsu", "v2zf", "cnj9", "3hko", "80at", "lr7e", "m4wp", "xi15", "db6q", "f57q", "lnbe", "vzh0", "a4i1", "wgm9", "8soj", "rtcd", "u2y3", "kp6x", "6n1q", "vkh0", "mydg", "sc38", "oztj", "ifl9", "2ab4", "p7eu", "5rxw", "a942", "1i0x", "octu", "f5pe", "dkgq", "vjlr", "bwyz", "73nm", "f68u"}
            For i As Integer = 0 To InputString.Length - 1 Step 4
                For j As Integer = 0 To r2.Length - 1
                    If InputString.Substring(i, 4) = r2(j) Then
                        result += r1(j)
                    End If
                Next
            Next
        Catch ex As Exception
            result = InputString
        End Try
        Return result.ToUpper()
    End Function

    Public Function FormTime(ByVal aa As DateTime) As String
        Dim tmp As String
        tmp = Chdate(aa).Replace("/", "")
        If Hour(aa) >= 10 Then
            tmp += " " & Hour(aa)
        Else
            tmp += " 0" & Hour(aa)
        End If
        If Minute(aa) >= 10 Then
            tmp += Minute(aa).ToString()
        Else
            tmp += "0" & Minute(aa)
        End If
        tmp = "<span style=""font-size:12px;padding-left:15px;margin-top:-0.5em;"">" & tmp & "</span>"
        Return tmp
    End Function

    Public Function SendMail(ByVal FromMail As String, ByVal FromUser As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        If MailSvr <> "" Then
            Return SendMailNew(FromMail, FromUser, ToMail, Subj, Bodystr)
        Else
            Return SendMailOld(FromMail, FromUser, ToMail, Subj, Bodystr)
        End If
    End Function


    Public Function SendMailNew(ByVal FromMail As String, ByVal FromUser As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        Dim SS As String = ""
        Try
            Dim msg As New System.Net.Mail.MailMessage
            msg.From = New System.Net.Mail.MailAddress(FromMail, FromUser) '寄件人
            msg.To.Add(New System.Net.Mail.MailAddress(ToMail)) '收件人
            msg.Subject = Subj '主旨
            msg.Body = Bodystr '內容
            msg.IsBodyHtml = True '格式

            Dim smtp As New System.Net.Mail.SmtpClient(MailSvr)
            'smtp.Credentials = New System.Net.NetworkCredential("ha-hsuan@mail.taipei.gov.tw", "9k4539")
            smtp.Send(msg)
        Catch ex As Exception
            SS = FromMail & "," & ToMail & "<br>" & MailSvr & "<br>" & ex.Message
        End Try
        Return SS
    End Function

    Public Function SendMailOld(ByVal FromMail As String, ByVal FromUser As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        Dim SS As String = ""
        Try
            Dim mail As MailMessage = New MailMessage
            mail.To = ToMail
            mail.From = FromUser

            mail.Subject = Subj

            mail.BodyFormat = MailFormat.Html
            mail.Body = Bodystr

            If MailSvr <> "" Then SmtpMail.SmtpServer = MailSvr

            SmtpMail.Send(mail)

        Catch ex As Exception
            SS = FromMail & "," & ToMail & "<br>" & MailSvr & "<br>" & ex.Message
        End Try
        Return SS
    End Function

    Public Function TurnDataTable(ByVal DTable As DataTable) As DataTable
        Dim ND As New DataTable
        For i As Integer = 0 To DTable.Rows.Count - 1
            ND.Columns.Add()
        Next
        For i As Integer = 0 To DTable.Columns.Count - 1
            Dim rw As DataRow = ND.NewRow()
            For j As Integer = 0 To DTable.Rows.Count - 1
                rw(j) = DTable.Rows(j).Item(i)
            Next
            ND.Rows.Add(rw)
        Next
        Return ND
    End Function

    Public Function GetRND(ByVal maxNum As Integer, ByVal howMany As Integer) As ArrayList
        Dim result As New ArrayList
        If howMany >= maxNum + 1 Then
            For i As Integer = 0 To maxNum
                result.Add(i)
            Next
        Else
            Dim v As Integer
            Dim cc As Integer = 0
            Do Until cc >= howMany
                Randomize()
                Randomize()
                Randomize()
                v = Int(Rnd() * maxNum + 1)
                Dim chk As Boolean = False
                For j As Integer = 0 To result.Count - 1
                    If v = result(j) Then chk = True
                Next
                If chk Then
                    chk = False
                Else
                    result.Add(v)
                    cc += 1
                End If
            Loop
        End If

        Return result
    End Function

    Public Sub WriteLog(ByVal Mess As String)
        Dim MP As String = System.Configuration.ConfigurationSettings.AppSettings.Get("LOGPath")
        If MP = "" Then MP = Server.MapPath("/") & "LOGPath\"

        MP = MP & "\" & Year(Today) & GetFullNum(Month(Today), 2) & "\"
        If System.IO.Directory.Exists(MP) = False Then
            System.IO.Directory.CreateDirectory(MP)
        End If

        Dim SW As StreamWriter = New StreamWriter(MP & strDate(Today) & ".log", True, System.Text.Encoding.Default)
        Dim str As String = ""
        Try
            str = "[" & Now & "-" & Session("User_Name") & "]:" + Mess
            SW.WriteLine(str)
            SW.Flush()
            SW.Close()

        Catch ex As Exception
            SW.Flush()
            SW.Close()
        Finally
            SW.Close()
        End Try
    End Sub

    Public Function strDate(ByVal dd As DateTime) As String
        Dim tmp As String = CStr(dd.Year - 1911)
        tmp += GetFullNum(dd.Month, 2)
        tmp += GetFullNum(dd.Day, 2)
        tmp += GetFullNum(dd.Hour, 2)
        Return tmp
    End Function

    Function DoubleAfterDot(ByVal db As Double, ByVal howlong As Integer) As String
        Dim tmp As String = ""
        db = CInt(db * (10 ^ howlong))
        db = db / (10 ^ howlong)
        Try
            tmp = db.ToString.Substring(0, db.ToString.IndexOf(".") + howlong + 1)

        Catch ex As Exception
            tmp = db.ToString
        End Try
        Return tmp
    End Function

    Public Function ImageSlide(ByVal ImageArray As ArrayList, ByVal ImageID As String, Optional ByVal SlideSpeed As Integer = 25) As String
        Dim Result As String = ""
        Dim tmp As String = ""
        Result = "<script type=""text/javascript"" language=""JavaScript"">" & vbCrLf
        For i As Integer = 0 To ImageArray.Count - 1
            tmp += ",""" & ImageArray(i).ToString.Replace("\", "/") & """"
        Next
        If tmp <> "" Then
            Result += "var slideimages=new Array(" & tmp.Substring(1) & ")	        " & vbCrLf
            Result += ImageID & ".src = slideimages[0]; " & vbCrLf
        End If
        Result += "var slidespeed = " & SlideSpeed & ";	" & vbCrLf
        Result += "var b = 2;" & vbCrLf
        Result += "var c = true;" & vbCrLf
        Result += "var whichImage = 0;" & vbCrLf
        Result += "var timerID = null;" & vbCrLf
        Result += "var pp = 0;" & vbCrLf
        Result += "var pauseID = null;" & vbCrLf

        Result += "function pauseTime(){" & vbCrLf
        Result += "    clearTimeout(timerID);" & vbCrLf
        Result += "	   pp += 1;" & vbCrLf
        Result += "    pauseID = setTimeout(""pauseTime()"",400);" & vbCrLf
        Result += "	   if(pp>5){" & vbCrLf
        Result += "		clearTimeout(pauseID);" & vbCrLf
        Result += "     b = b-2;" & vbCrLf    '移動後位置
        Result += "     c = false;" & vbCrLf  '移動後位置
        Result += "     pp = 0;" & vbCrLf
        Result += "	        }" & vbCrLf
        Result += "}" & vbCrLf

        Result += "function fade()" & vbCrLf
        Result += "{" & vbCrLf
        Result += "	if(document.all);" & vbCrLf
        Result += "	if(c == true) {	b++;}" & vbCrLf
        Result += "	if(b==100) {" & vbCrLf
        'Result += "     b = b-2;" & vbCrLf     '原本位置
        'Result += "     c = false;" & vbCrLf   '原本位置
        Result += "     pauseTime();" & vbCrLf  '停止時間後改上移
        Result += "	}" & vbCrLf
        Result += "	if(b==0) {" & vbCrLf

        Result += "	b = b+2;" & vbCrLf
        Result += "	c = true;" & vbCrLf
        Result += "     if(whichImage < slideimages.length-1)" & vbCrLf
        Result += "		{" & vbCrLf
        Result += "			whichImage ++;" & vbCrLf
        Result += "		}		" & vbCrLf
        Result += "     else" & vbCrLf
        Result += "		{" & vbCrLf
        Result += "			whichImage = 0;" & vbCrLf
        Result += "		}" & vbCrLf
        Result += "		" & ImageID & ".src = slideimages[whichImage]; " & vbCrLf
        Result += "	}" & vbCrLf
        Result += "	if(c == false) {" & vbCrLf
        Result += "	b--;" & vbCrLf
        Result += "	}" & vbCrLf
        Result += "	" & ImageID & ".filters.alpha.opacity=0 + b;" & vbCrLf
        Result += "	setTimeout(""fade()"",slidespeed);" & vbCrLf
        Result += "}" & vbCrLf

        Result += "var preloadFlag = false;" & vbCrLf
        Result += "var imageholder=new Array();" & vbCrLf
        Result += "function preloadImages() {" & vbCrLf
        Result += "	if (document.images) {"
        Result += "		for(i=0;i<slideimages.length;i++){" & vbCrLf
        Result += "			imageholder[i] = new Image();" & vbCrLf
        Result += "			imageholder[i].src = slideimages[i];" & vbCrLf
        Result += "		}" & vbCrLf
        Result += "		preloadFlag = true;" & vbCrLf
        Result += "	}" & vbCrLf
        Result += "}" & vbCrLf
        Result += "preloadImages();" & vbCrLf
        Result += "fade(); " & vbCrLf
        Result += "</script>" & vbCrLf
        Return Result
    End Function

    Public Function FindRootID(ByVal TableName As String, ByVal RefColName As String, ByVal CurrID As Integer) As Integer
        Dim CurrRefID As Integer = CurrID
        Do
            CurrID = CurrRefID
            CurrRefID = Main.Scalar("Select Isnull(" & RefColName & ",-1) from " & TableName & " where IDNo=" & CurrID)
        Loop Until CurrRefID = -1
        Return CurrID
    End Function


    Public Function GetBread(ByVal TableName As String, ByVal RefColName As String, ByVal TxtColName As String, ByVal CurrID As Integer) As String
        Dim CurrRefID As Integer = CurrID
        Dim tmp As String = ""
        Do
            CurrID = CurrRefID
            If tmp <> "" Then
                tmp = Main.Scalar("Select " & TxtColName & " from " & TableName & " where IDNo=" & CurrID) & ">" & tmp
            Else
                tmp = Main.Scalar("Select " & TxtColName & " from " & TableName & " where IDNo=" & CurrID)
            End If
            CurrRefID = Main.Scalar("Select Isnull(" & RefColName & ",-1) from " & TableName & " where IDNo=" & CurrID)

        Loop Until CurrRefID = -1
        Return tmp
    End Function

    Public Overloads Function InItems(ByVal ItemValue As String, ByVal LIS As CheckBoxList) As Boolean
        Dim AA As Boolean = False
        For k As Integer = 0 To LIS.Items.Count - 1
            If ItemValue = LIS.Items(k).Value Then AA = True
        Next
        Return AA
    End Function

    Public Overloads Function InItems(ByVal ItemValue As String, ByVal LIS As DropDownList) As Boolean
        Dim AA As Boolean = False
        For k As Integer = 0 To LIS.Items.Count - 1
            If ItemValue = LIS.Items(k).Value Then AA = True
        Next
        Return AA
    End Function

    Public Overloads Function InItems(ByVal ItemValue As String, ByVal LIS As RadioButtonList) As Boolean
        Dim AA As Boolean = False
        For k As Integer = 0 To LIS.Items.Count - 1
            If ItemValue = LIS.Items(k).Value Then AA = True
        Next
        Return AA
    End Function

    Public Overloads Function InItems(ByVal ItemValue As String, ByVal LIS As ListBox) As Boolean
        Dim AA As Boolean = False
        For k As Integer = 0 To LIS.Items.Count - 1
            If ItemValue = LIS.Items(k).Value Then AA = True
        Next
        Return AA
    End Function

    Public Function SearchDel(ByVal SS As String) As Boolean
        Dim AA() As Char = SS.ToCharArray
        Dim II As Integer = 0
        For i As Integer = 0 To AA.Length - 1
            Select Case AA(i)
                Case "'"
                    II += 1
                Case "`"
                    II += 1
                Case "*"
                    II += 1
                Case "&"
                    II += 1
                Case "+"
                    II += 1
                Case "="
                    II += 1
                Case "-"
                    II += 1
                Case "%"
                    II += 1
                Case "<"
                    II += 1
                Case ">"
                    II += 1
                Case "/"
                    II += 1
                Case "#"
                    II += 1
                Case "$"
                    II += 1
                Case "%"
                    II += 1
                Case "!"
                    II += 1
            End Select
        Next

        If II > 0 Then
            Return False
        Else
            Return True
        End If
    End Function



    Public Function SendMailNew(ByVal FromMail As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        Dim SS As String = ""
        Try
            Dim msg As New System.Net.Mail.MailMessage
            msg.From = New System.Net.Mail.MailAddress(FromMail, "臺北區監理所板橋監理站") '寄件人
            msg.To.Add(New System.Net.Mail.MailAddress(ToMail)) '收件人
            msg.Subject = Subj '主旨
            msg.Body = Bodystr '內容
            msg.IsBodyHtml = True '格式
            Dim smtp As New System.Net.Mail.SmtpClient(MailSvr)

            If MailUID <> "" Then
                smtp.Credentials = New System.Net.NetworkCredential(MailUID, MailPWD)
            End If

            smtp.Send(msg)
        Catch ex As Exception
            SS = FromMail & "," & ToMail & "<br>" & MailSvr & "<br>" & ex.Message
        End Try
        Return SS
    End Function

    Public Function SendMailOld(ByVal FromMail As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        Dim SS As String = ""
        Try
            Dim mail As MailMessage = New MailMessage
            mail.To = ToMail
            mail.From = FromMail
            mail.Subject = Subj

            mail.BodyFormat = MailFormat.Html
            mail.Body = Bodystr

            If MailSvr <> "" Then SmtpMail.SmtpServer = MailSvr

            SmtpMail.Send(mail)

        Catch ex As Exception
            SS = FromMail & "," & ToMail & "<br>" & MailSvr & "<br>" & ex.Message
        End Try
        Return SS
    End Function

    Public Function SendMail(ByVal FromMail As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        If MailSvr <> "" Then
            Return SendMailNew(FromMail, ToMail, Subj, Bodystr)
        Else
            Return SendMailOld(FromMail, ToMail, Subj, Bodystr)
        End If
    End Function

End Class



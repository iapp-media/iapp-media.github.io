Imports Microsoft.VisualBasic
Imports System.Web.Mail
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.IO

Public Class CommA
    Inherits System.Web.UI.Page 
    Private Main As New DBTool
    Public URL As String = System.Configuration.ConfigurationSettings.AppSettings.Get("Url")
    Public MailSvr As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailServer")
    Public MailFrom As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailFrom")
    Public MailUID As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailUID")
    Public MailPWD As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MailPWD")
    Public Station As String = System.Configuration.ConfigurationSettings.AppSettings.Get("Station")
    Dim str As String

    Public Sub getLeftMenu(ByVal page As Page, ByVal parentID As Integer, Optional ByVal MenuTitle As String = "")
        Dim ss As New StringBuilder
        If MenuTitle = "" Then MenuTitle = Main.Scalar("Select title from Menu where IDNo=" & parentID)
        ss.Append("<div class=""lefthead"">" & MenuTitle & "</div>" & vbCrLf)
        ss.Append("  <ul>" & vbCrLf)
        Dim d As DataTable = Main.GetDataSetNoNull("select * from Menu where isopen=1 and ref=" & parentID & " order by Sort")
        For j As Integer = 0 To d.Rows.Count - 1
            Dim rw As DataRow = d.Rows(j)
            If rw("Target") = "_self" Then
                ss.Append("       <li><a href=""" & rw("href") & """ title=""" & rw("title") & """>" & LongStr(rw("title"), 10) & "</a></li>")
            Else
                ss.Append("       <li><a href=""" & rw("href") & """ target=""_blank"" title=""" & rw("title") & "(�t�}�s����)"">" & LongStr(rw("title"), 10) & "</a></li>")
            End If
        Next
        ss.Append("  </ul>" & vbCrLf)
        Try

        Catch ex As Exception

        End Try
        Dim LM As Literal = page.Master.Controls(0).Controls(3).FindControl("ConHolder").FindControl("LeftMenu")
        LM.Text = ss.ToString()

    End Sub

    Function LongStr(ByVal S As String, ByVal MaxLenth As Integer) As String
        Dim result = S
        If S.Length > MaxLenth Then
            result = S.Substring(0, MaxLenth) & ".."
            ' result = "<span style=""font-size:12px"">" & S & "</span>"
        End If
        Return result
    End Function

    Public Function Cint2(ByVal obj As Object, Optional value As Integer = 0) As Integer
        If IsNumeric(obj) Then
            Return CInt(obj)
        Else
            Return value
        End If
    End Function

    Public Overloads Function FillDDP(ByVal ddp As DropDownList, ByVal strsql As String, ByVal TEXTField As String, ByVal ValueField As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        ddp.Items.Clear()
        If DT.Rows.Count > 0 Then
            ddp.Items.Add("�п��")
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim TT As ListItem = New ListItem
                TT.Text = DT.Rows(i).Item(TEXTField)
                TT.Value = DT.Rows(i).Item(ValueField)
                ddp.Items.Add(TT)
            Next
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal ddp As ListBox, ByVal strsql As String, ByVal TEXTField As String, ByVal ValueField As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        ddp.Items.Clear()
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(TEXTField) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(TEXTField)
                    TT.Value = DT.Rows(i).Item(ValueField)
                    ddp.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal ddp As RadioButtonList, ByVal strsql As String, ByVal TEXTField As String, ByVal ValueField As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        ddp.Items.Clear()
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(TEXTField) Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(TEXTField)
                    TT.Value = DT.Rows(i).Item(ValueField)
                    ddp.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Overloads Function FillDDP(ByVal ddp As CheckBoxList, ByVal strsql As String, ByVal TEXTField As String, ByVal ValueField As String)
        Dim DT As DataTable = Main.GetDataSet(strsql)
        ddp.Items.Clear()
        If Not IsDBNull(TEXTField) Then
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim TT As ListItem = New ListItem
                    TT.Text = DT.Rows(i).Item(TEXTField)
                    TT.Value = DT.Rows(i).Item(ValueField)
                    ddp.Items.Add(TT)
                Next
            End If
        End If
        Return True
    End Function

    Public Function GetFullNum(ByVal num As Integer, ByVal size As Integer) As String
        Dim tmp As String = num.ToString()
        Do Until tmp.Length = size
            tmp = "0" & tmp
        Loop
        Return tmp
    End Function

    Public Function SendMailNew(ByVal FromMail As String, ByVal ToMail As String, ByVal Subj As String, ByVal Bodystr As String) As String
        Dim SS As String = ""
        Try
            Dim msg As New System.Net.Mail.MailMessage
            msg.From = New System.Net.Mail.MailAddress(FromMail, "�O���Ϻʲz��") '�H��H
            msg.To.Add(New System.Net.Mail.MailAddress(ToMail)) '����H
            msg.Subject = Subj '�D��
            msg.Body = Bodystr '���e
            msg.IsBodyHtml = True '�榡
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


    Public Function SaveBmp(ByVal afile As HttpPostedFile, ByVal boxwidth As Integer, ByVal boxheight As Integer, ByVal Img As String)
        Dim Comm As New CommTool
        Dim scale As Double = 0
        Dim filename As String = ""
        Dim file2 As String = ""
        Dim file3 As String = ""
        Dim y As DateTime = Now
        Dim tmp As String = ""
        Dim result As String = ""
        If Comm.ChkType(afile, "image") = False Then
            Return ""
            Exit Function
        End If
        tmp = (Year(Now) - 1911) & Month(Now) & Day(Now) & Replace(y.TimeOfDay.ToString, ":", "").Substring(0, 6)

        If Directory.Exists(Comm.MainPath & Comm.FilePath & Img) = False Then
            Directory.CreateDirectory(Comm.MainPath & Comm.FilePath & Img)
        End If
        If afile.ContentLength <> 0 Then
            filename = Comm.MainPath & Comm.FilePath & Img & tmp & Path.GetExtension(afile.FileName)
            file2 = Comm.MainPath & Comm.FilePath & Img & tmp & "_s" & Path.GetExtension(afile.FileName)
            file3 = Comm.MainPath & Comm.FilePath & Img & tmp & "_ss" & Path.GetExtension(afile.FileName)
            afile.SaveAs(filename)
            result = Comm.FilePath & Img & tmp & "_s" & Path.GetExtension(afile.FileName)
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
        outbmp = New Bitmap(inbmp, 230, 180)
        outbmp.Save(file3)
        outbmp.Dispose()

        inbmp.Dispose()  '�̫�A��
        Return result
    End Function

    Public Function GetToday() As String
        Dim DD As String
        DD = (Now.Year - 1911) & "." & Now.Month & "." & Now.Day
        Select Case Now.DayOfWeek
            Case DayOfWeek.Monday
                DD += "&nbsp;&nbsp;�P���@"

            Case DayOfWeek.Tuesday
                DD += "&nbsp;&nbsp;�P���G"

            Case DayOfWeek.Wednesday
                DD += "&nbsp;&nbsp;�P���T" 

            Case DayOfWeek.Thursday
                DD += "&nbsp;&nbsp;�P���|"

            Case DayOfWeek.Friday
                DD += "&nbsp;&nbsp;�P����"

            Case DayOfWeek.Saturday
                DD += "&nbsp;&nbsp;�P����"

            Case DayOfWeek.Sunday
                DD += "&nbsp;&nbsp;�P����"
        End Select
        Return DD
    End Function

    Public Overloads Function GetFiles(ByVal TableName As String, ByVal TableID As String, ByVal CBL As CheckBoxList) As Boolean
        If IsNumeric(TableID) = True Then
            Dim DT As DataTable = Main.GetDataSetNoNull("Select FileName,FilePath from Files where xTable='" & TableName & "' and Table_ID='" & TableID & "' and Table_Varchar is null")
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim LI As New ListItem
                    LI.Text = "<a href=""" & HttpUtility.HtmlEncode(URL & DT.Rows(i).Item("FilePath")) & """ target=""_blank"">" & DT.Rows(i).Item("FileName") & "</a>"
                    LI.Value = DT.Rows(i).Item("FilePath") & "," & DT.Rows(i).Item("FileName")
                    CBL.Items.Add(LI)
                Next
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetMeta(ByVal PageName As String, ByVal PageAddTime As String)

        Dim SiteName As String = "��q���O���Ϻʲz�ҥx���Ϻʲz��"

        Dim Path As String = PageName
        If PageName.IndexOf("/") > -1 Then Path = PageName.Substring(PageName.LastIndexOf("/")).Replace("/", "") '�����W�� 
        '  Dim Url As String = CurrPage.Request.Url.ToString()          '����}


        Dim Meta As New StringBuilder
        Dim DT As DataTable = Main.GetDataSetNoNull("select Title,Subject,Des,Type,Theme,Cake,Service,keywords from Search where URL='" & Path & "'")
        If DT.Rows.Count > 0 Then
            If Not IsDBNull(DT.Rows(0).Item("Title")) Then
                If DT.Rows(0).Item("Title") <> "" Then
                    Page.Title = SiteName & "-" & DT.Rows(0).Item("Title")
                    Meta.Append("<meta name=""DC.Title"" content=""" & SiteName & "-" & DT.Rows(0).Item("Title") & """ />" & vbCrLf)
                Else
                    Page.Title = SiteName
                    Meta.Append("<meta name=""DC.Title"" content=""" & SiteName & """ />" & vbCrLf)
                End If
            Else
                Page.Title = SiteName
                Meta.Append("<meta name=""DC.Title"" content=""" & SiteName & """ />" & vbCrLf)
            End If


            '�@��
            Meta.Append("<meta name=""DC.Creator"" content=""" & SiteName & """ />" & vbCrLf)


            '�D��
            If Not IsDBNull(DT.Rows(0).Item("Subject")) Then
                If DT.Rows(0).Item("Subject") <> "" Then
                    Meta.Append("<meta name=""DC.Subject"" content=""" & DT.Rows(0).Item("Subject") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""DC.Subject"" content=""" & SiteName & "�D��"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""DC.Subject"" content=""" & SiteName & "�D��"" />" & vbCrLf)
            End If


            '���e�y�z"
            If Not IsDBNull(DT.Rows(0).Item("Des")) Then
                If DT.Rows(0).Item("Des") <> "" Then
                    Meta.Append("<meta name=""DC.Description"" content=""" & DT.Rows(0).Item("Des") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""DC.Description"" content=""" & SiteName & "���e����"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""DC.Description"" content=""" & SiteName & "���e����"" />" & vbCrLf)
            End If


            '�^�m��
            Meta.Append("<meta name=""DC.Contributor"" content=""" & SiteName & """ />" & vbCrLf)


            '�������"
            If Not IsDBNull(DT.Rows(0).Item("Type")) Then
                If DT.Rows(0).Item("Type") <> "" Then
                    Meta.Append("<meta name=""DC.Type"" content=""" & DT.Rows(0).Item("Type") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""DC.Type"" content=""�A��"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""DC.Type"" content=""�A��"" />" & vbCrLf)
            End If


            Meta.Append("<meta name=""DC.Format"" content=""Text"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Source"" content=""" & SiteName & """ />" & vbCrLf)              '�ӷ�
            Meta.Append("<meta name=""DC.Language"" content=""����"" />" & vbCrLf)                                  '�y��
            Meta.Append("<meta name=""DC.coverage.t.min"" content=""2008-01-02"" />" & vbCrLf)                      '�[�\�d��
            Meta.Append("<meta name=""DC.coverage.t.max"" content=""2009-08-10"" />" & vbCrLf)                      '�[�\�d��
            Meta.Append("<meta name=""DC.Publisher"" content=""" & SiteName & """ />" & vbCrLf)           '��������
            Meta.Append("<meta name=""DC.Date"" content=""" & GetDate(PageAddTime) & """ />" & vbCrLf)                  '�s�@���"
            Meta.Append("<meta name=""DC.Identifier"" content=""300000000A"" />" & vbCrLf)                          'OID+DataID
            Meta.Append("<meta name=""DC.Relation"" content=""GIP-EY-MP01"" />" & vbCrLf)                           '���p
            Meta.Append("<meta name=""DC.Rights"" content=""" & SiteName & """ />" & vbCrLf)              '�ۧ@�v����


            '�D�D�����N�X1"
            If Not IsDBNull(DT.Rows(0).Item("Theme")) Then
                If DT.Rows(0).Item("Theme") <> "" Then
                    Meta.Append("<meta name=""Category.Theme"" content=""" & DT.Rows(0).Item("Theme") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""Category.Theme"" content=""610"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""Category.Theme"" content=""610"" />" & vbCrLf)
            End If


            '�D�D�����N�X2"
            If Not IsDBNull(DT.Rows(0).Item("Cake")) Then
                If DT.Rows(0).Item("Cake") <> "" Then
                    Meta.Append("<meta name=""Category.Cake"" content=""" & DT.Rows(0).Item("Cake") & """ />" & vbCrLf)        '�D�D�����N�X2"
                Else
                    Meta.Append("<meta name=""Category.Cake"" content=""812"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""Category.Cake"" content=""812"" />" & vbCrLf)
            End If


            '�A�Ȥ����N�X3"
            If Not IsDBNull(DT.Rows(0).Item("Service")) Then
                If DT.Rows(0).Item("Cake") <> "" Then
                    Meta.Append("<meta name=""Category.Service"" content=""" & DT.Rows(0).Item("Service") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""Category.Service"" content=""A50"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""Category.Service"" content=""A50"" />" & vbCrLf)
            End If


            '����r"
            If Not IsDBNull(DT.Rows(0).Item("Keywords")) Then
                If DT.Rows(0).Item("Cake") <> "" Then
                    Meta.Append("<meta name=""Keywords"" content=""" & DT.Rows(0).Item("Keywords") & """ />" & vbCrLf)
                Else
                    Meta.Append("<meta name=""Keywords"" content=""��q���O���Ϻʲz��,�x���Ϻʲz��,�ʲz"" />" & vbCrLf)
                End If
            Else
                Meta.Append("<meta name=""Keywords"" content=""��q���O���Ϻʲz��,�x���Ϻʲz��,�ʲz"" />" & vbCrLf)
            End If
        Else
            Page.Title = SiteName
            Meta.Append("<meta name=""DC.Title"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Creator"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Subject"" content=""" & SiteName & "�D��"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Description"" content=""" & SiteName & "���e����"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Contributor"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Type"" content=""�A��"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Format"" content=""Text"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Source"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Language"" content=""����"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.coverage.t.min"" content=""2008-01-02"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.coverage.t.max"" content=""2009-08-10"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Publisher"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Date"" content=""" & GetDate(PageAddTime) & """ />" & vbCrLf)
            Meta.Append("<meta name=""DC.Identifier"" content=""300000000A"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Relation"" content=""GIP-EY-MP01"" />" & vbCrLf)
            Meta.Append("<meta name=""DC.Rights"" content=""" & SiteName & """ />" & vbCrLf)
            Meta.Append("<meta name=""Category.Theme"" content=""610"" />" & vbCrLf)
            Meta.Append("<meta name=""Category.Cake"" content=""812"" />" & vbCrLf)
            Meta.Append("<meta name=""Category.Service"" content=""A50"" />" & vbCrLf)
            Meta.Append("<meta name=""Keywords"" content=""" & SiteName & "," & SiteName & ",�ʲz"" />" & vbCrLf)
        End If
        Return Meta.ToString
    End Function

    Public Function GetDate(ByVal DA As Date) As String
        Dim Comm As New CommTool
        Dim tmp As String = ""
        If IsDate(DA) = False Then DA = Today
        tmp = Comm.GetFullNum(Year(DA), 4) & "-" & Comm.GetFullNum(Month(DA), 2) & "-" & Comm.GetFullNum(Day(DA), 2)
        Return tmp
    End Function

    Public Function GetMenu()
        Dim ss As New StringBuilder
        Dim d1 As DataTable = Main.GetDataSetNoNull("Select * from Menu where isopen=1 and ref=-1 order by Sort")
        If d1.Rows.Count > 0 Then
            Dim cc As Integer = 0
            ss.Append("<ul class=""Mlist"">" & vbCrLf)
            For Each rw As DataRow In d1.Rows
                Dim TG As String = "><font>"
                Dim d2 As DataTable = Main.GetDataSetNoNull("Select * from Menu where isopen=1 and ref=" & rw("IDNo") & " order by sort ")
                If d2.Rows.Count > 0 Then
                    cc += 1
                    Dim s2 As String = " onmouseover=""openMenu(" & cc & ")"" onmouseout=""openMenu(" & cc & ")""" & _
                                       " onfocus=""openMenu(" & cc & ")"" onblur=""openMenu(" & cc & ")"""
                    ss.Append("  <li><a href=""SubIndex.aspx?entry=" & rw("IDNo") & """ " & s2 & " " & TG & "" & rw("Title") & "</font></a>" & vbCrLf)
                    ss.Append("<ul class=""secondmenu"" id=""sub" & cc & """ " & s2 & ">" & vbCrLf)
                    For Each rw2 As DataRow In d2.Rows
                        TG = "><font>"
                        Dim MC As Integer = Main.Scalar("Select Count(*) from Menu where ref=" & rw2("IDNo"))
                        If MC > 0 Then
                            ss.Append("  <li><a href=""SubIndex.aspx?entry=" & rw2("IDNo") & """ " & TG & "" & rw2("Title") & "</font></a></li>" & vbCrLf)
                        Else
                            If rw2("target") = "_blank" Then
                                TG += "(�t�}�s����)"" target=""_blank"
                                ss.Append("  <li><a href=""" & rw2("Href") & """ " & TG & "" & rw2("Title") & "</font></a></li>" & vbCrLf)
                            Else
                                ss.Append("  <li><a href=""" & rw2("Href") & """ " & TG & "" & rw2("Title") & "</font></a></li>" & vbCrLf)
                            End If
                        End If
                    Next
                    ss.Append("</ul>" & vbCrLf)
                Else
                    TG = "><font>"
                    If rw("target") = "_blank" Then
                        TG += "(�t�}�s����)"" target=""_blank"
                        ss.Append("  <li><a href=""" & rw("Href") & """ " & TG & "" & rw("Title") & "</font></a></li>" & vbCrLf)
                    Else
                        ss.Append("  <li><a href=""" & rw("Href") & """ " & TG & "" & rw("Title") & "</font></a></li>" & vbCrLf)
                    End If
                End If
                ss.Append("</li>" & vbCrLf)
            Next
            ss.Append("</ul>" & vbCrLf)

            ss.Append("<script>" & vbCrLf)
            ss.Append("    function openMenu(active) " & vbCrLf)
            ss.Append("    {" & vbCrLf)
            ss.Append("    for (i=1; i < " & cc + 1 & "; i++)" & vbCrLf)
            ss.Append("        {" & vbCrLf)
            ss.Append("        if (i!= active)  " & vbCrLf)
            ss.Append("            {" & vbCrLf)
            ss.Append("            document.all(""sub"" + i).style.display = 'NONE';" & vbCrLf)
            ss.Append("            }" & vbCrLf)
            ss.Append("            else" & vbCrLf)
            ss.Append("            {" & vbCrLf)
            ss.Append("            if (document.all(""sub"" + active).style.display=='block')  " & vbCrLf)
            ss.Append("                 {" & vbCrLf)
            ss.Append("                     document.all(""sub"" + active).style.display = 'NONE';" & vbCrLf)
            ss.Append("                 }" & vbCrLf)
            ss.Append("                 else" & vbCrLf)
            ss.Append("                 {" & vbCrLf)
            ss.Append("                     document.all(""sub"" + active).style.display = 'BLOCK';" & vbCrLf)
            ss.Append("                 }" & vbCrLf)
            ss.Append("            }" & vbCrLf)
            ss.Append("        }" & vbCrLf)
            ss.Append("    }" & vbCrLf)
            ss.Append("</script>" & vbCrLf)
        End If
        Return ss.ToString()
    End Function

    Public Function GetMenuNoSub()
        Dim ss As New StringBuilder
        Dim d1 As DataTable = Main.GetDataSetNoNull("Select * from Menu where isopen=1 and ref=-1 order by Sort")
        If d1.Rows.Count > 0 Then
            Dim cc As Integer = 0
            ss.Append("<ul class=""Mlist"">" & vbCrLf)
            For Each rw As DataRow In d1.Rows

                Dim TG As String = "><font>"

                TG = "><font>"
                If rw("target") = "_blank" Then
                    TG += "(�t�}�s����)"" target=""_blank"
                    ss.Append("  <li><a href=""" & rw("Href") & """ " & TG & "" & rw("Title") & "</font></a></li>" & vbCrLf)
                Else
                    Dim d2 As DataTable = Main.GetDataSetNoNull("Select * from Menu where isopen=1 and ref=" & rw("IDNo") & " order by sort ")
                    If d2.Rows.Count > 0 Then
                        ss.Append("  <li><a href=""SubIndex.aspx?entry=" & rw("IDNo") & """ " & TG & "" & rw("Title") & "</font></a></li>" & vbCrLf)
                    Else
                        ss.Append("  <li><a href=""" & rw("Href") & """ " & TG & "" & rw("Title") & "</font></a></li>" & vbCrLf)
                    End If
                End If

                ss.Append("</li>" & vbCrLf)
            Next
            ss.Append("</ul>" & vbCrLf)
        End If
        Return ss.ToString()
    End Function

    Public Function CutString(ByVal OriginString As String, ByVal StartIndex As Integer, ByVal CutLength As Integer) As String
        OriginString += "  "
        Dim result As String = ""
        Dim BB As Byte() = System.Text.Encoding.GetEncoding("big5").GetBytes(OriginString)
        '��X�s���_�I>>��X�s���r��>>�b�h���o���� 
        ' Response.Write("--" & OriginString & "--<br>--" & OriginString.Length & "--" & StartIndex & "--" & CutLength & "--<br>")
        Try
            If BB.Length > StartIndex And OriginString.Length > StartIndex Then
                Dim tmp As String = ""
                Dim i As Integer = 1
                '==��u�����_�I
                Dim realStartIndex As Integer = 0
                If StartIndex > 0 Then
                    Do

                        tmp = OriginString.Substring(0, i)
                        BB = System.Text.Encoding.GetEncoding("big5").GetBytes(tmp) 'big5
                        If BB.Length + 1 > StartIndex Then
                            realStartIndex = i
                            Exit Do
                        End If
                        i += 1
                    Loop While i < OriginString.Length

                End If
                '==������
                i = 1
                Do

                    tmp = OriginString.Substring(realStartIndex, i)
                    '  Response.Write(realStartIndex & "-" & tmp & "<br>")
                    BB = System.Text.Encoding.GetEncoding("big5").GetBytes(tmp) 'big5
                    If BB.Length + 1 > CutLength Then
                        result = tmp

                        Exit Do
                    End If
                    i += 1
                Loop While i < OriginString.Length
                If result = "" Then result = OriginString
            End If

        Catch ex As Exception
            '  Response.Write("--" & OriginString & "--<br>--" & OriginString.Length & "--" & StartIndex & "--" & CutLength & "--<br>")
        End Try
        '  Response.Write(result & "--<br>")
        Return result
    End Function

    Function ClearHTML(ByVal inStr As String) As String
        Do While inStr.IndexOf("<") > -1
            inStr = inStr.Substring(0, inStr.IndexOf("<")) & inStr.Substring(inStr.IndexOf(">") + 1)
        Loop
        Return inStr
    End Function
End Class

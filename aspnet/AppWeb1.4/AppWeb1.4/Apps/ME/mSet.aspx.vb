Imports System.IO

Public Class mSet
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Dim Allurl As String = System.Configuration.ConfigurationSettings.AppSettings.Get("url")
    Public AppPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("AppPath") '主路徑+Apps+01~XX

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("i")) Then
                CurrentId.Text = Request.QueryString("i")
                Dim d As DataTable = main.GetDataSetNoNull("Select * from User_App where IDNo=" & Request.QueryString("i"))
                If d.Rows.Count > 0 Then

                    TAppName.Text = d.Rows(0).Item("App_Name")
                    TAppMemo.Text = d.Rows(0).Item("App_Memo")
                    If d.Rows(0).Item("App_Icon") <> "" Then
                        p1.ImageUrl = "../" & d.Rows(0).Item("App_Folder") & "/pic/" & d.Rows(0).Item("App_Icon")
                    End If
                Else

                    Response.Write("<Script>alert('參數錯誤');window.open('" & comm.URL.Replace(comm.Theme, "portal") & "','_top')</Script>")
                    Response.End()
                End If

            Else
                Response.Write("<Script>alert('參數錯誤');window.open('" & comm.URL.Replace(comm.Theme, "portal") & "','_top')</Script>")
                Response.End()
            End If
        End If
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If IsNumeric(Request.QueryString("i")) Then
    '        Dim tmp As String = ""

    '        If TAppName.Text.Trim = "" Then
    '            tmp += ",iApp名稱"
    '        End If
    '        If tmp <> "" Then
    '            Response.Write("<Script>alert('請填入" & tmp.Substring(1) & "');</Script>")
    '            Exit Sub
    '        End If

    '        str = "Update User_App set App_Icon=@App_Icon where IDNo=@App_id"
    '        main.NonQuery(str)



    '        main.ParaClear()
    '        main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)
    '        main.ParaAdd("@App_Name", TAppName.Text.Trim(), System.Data.SqlDbType.NVarChar)
    '        main.ParaAdd("@App_Memo", TAppMemo.Text.Trim(), System.Data.SqlDbType.NVarChar)

    '        If Tbase64.Text.Trim <> "" Then
    '            Dim ImgName As String = "ico_" & Request.QueryString("i") & ".jpg"
    '            Dim ImgPath As String = comm.CurrentAppFolder(Request.QueryString("i")) & "\pic\"
    '            If File.Exists(ImgPath & ImgName) = True Then File.Delete(ImgPath & ImgName)
    '            If System.IO.Directory.Exists(ImgPath) = False Then System.IO.Directory.CreateDirectory(ImgPath)
    '            Dim buf As Byte() = Convert.FromBase64String(Tbase64.Text.Trim)
    '            Dim TYU As New FileStream(ImgPath & ImgName, FileMode.CreateNew)
    '            TYU.Write(buf, 0, buf.Length)
    '            TYU.Close()
    '            main.ParaAdd("@App_Icon", ImgName, System.Data.SqlDbType.NVarChar)
    '            main.NonQuery("Update User_App set App_Icon=@App_Icon where IDNo=@App_id")
    '        End If


    '        str = "Update User_App set App_Name=@App_Name,App_Memo=@App_Memo where IDNo=@app_id"
    '        Dim c As Integer = main.NonQuery(str)
    '        If c > 0 Then
    '            Dim newURl As String = MakeHtml()
    '            Response.Write("<Script>window.open('" & newURl & "','_self');</Script>")
    '            Response.End()
    '        Else
    '            Response.Write("<Script>alert('上傳失敗，請稍後再試');</Script>")
    '            '  System.Web.UI.ScriptManager.RegisterStartupScript(Me, Me.GetType(), "KeyName", "alert('上傳失敗，請稍後再試');", True)
    '        End If
    '    End If
    'End Sub


    Function MakeHtml()                                                                 '產生使用者的APP HTML

        Dim LAppPath As String = comm.CurrentAppFolder(Request.QueryString("i")) & "\" & Request.QueryString("i") & ".html"

        main.ParaClear()
        main.ParaAdd("@User_ID", comm.User_ID, System.Data.SqlDbType.Int)            'User 的IDNO
        main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)            'User_App 的IDNO
        main.ParaAdd("@Theme_ID", main.Scalar("Select Theme_ID from User_App where IDNo=" & Request.QueryString("i")), System.Data.SqlDbType.Int)
        Dim ss As New StringBuilder
        Dim TotalPages As Integer = 0

        str = "Select Html,b.Img01,b.Img02,b.Img03,b.h1,b.h2 from Pages a inner join User_Page b on a.IDNo=b.Page_ID where b.User_App_ID=@app_id order by sort"
        Dim url As String = "Select Theme_head,Theme_foot from Theme where IDNo=@Theme_ID"      '選擇主題 帶入App上下兩段HTML
        Dim themeTable As DataTable = main.GetDataSet(url)
        Dim TheHead As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_head"))
        Dim Thefoot As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_foot"))
        Dim d As DataTable = main.GetDataSet(str)
        ss.Append(TheHead & vbCrLf)  '.Replace("css/", "../css/").Replace("js/", "../js/")

        ss.Append("<div>" & vbCrLf)                                                     '第一頁公司LOGO 一定會有 
        ss.Append("<div class=""page page-1-1 page-current"">" & vbCrLf)
        ss.Append("<img class=""logo animated bounceInDownrubberBand"" src=""../img/logo.png"" />" & vbCrLf)
        ss.Append(" <img class=""up moveIconUp"" src=""../img/icon_up.png"" />" & vbCrLf)
        ss.Append("</div>" & vbCrLf)
        ss.Append("</div>" & vbCrLf)

        If d.Rows.Count > 0 Then '動態產生的DIV 內頁
            For i As Integer = 0 To d.Rows.Count - 1
                Dim dw As DataRow = d.Rows(i)
                Dim html As String = HttpUtility.HtmlDecode(dw("Html"))
                ss.Append("<div class=""page page-" & i + 2 & "-1 hide"">" & vbCrLf)
                If dw("Img01").ToString() <> "" And dw("Img02").ToString() <> "" And dw("Img03").ToString() <> "" Then
                    ss.Append(html.Replace("[img01]", "../" & dw("Img01")).Replace("[img02]", "../" & dw("Img02")).Replace("[img03]", "../" & dw("Img03")) & vbCrLf) '出來兩層賦予圖片路徑
                Else
                    ss.Append(html.Replace("[img01]", "../" & dw("Img01")).Replace("[text1]", dw("h1")).Replace("[text2]", dw("h2")) & vbCrLf)
                End If
                ss.Append("</div>" & vbCrLf)
            Next
            TotalPages = d.Rows.Count + 2
        End If

        Dim newUrl As String = comm.CurrentAppFolder(Request.QueryString("i")).Replace(AppPath, "Apps/") & "/" & Request.QueryString("i") '回傳javaScript AJAX !!!!網址!!!!

        ss.Append("<div class=""page page-" & d.Rows.Count + 2 & "-1 hide""> " & vbCrLf) '最後一段分享的網頁
        ss.Append("<div class=""bg""></div>" & vbCrLf)
        ss.Append("<img class=""logo2 animated bounceInRight1"" src=""../img/logo2.png"" />" & vbCrLf)
        ss.Append("<img class=""qr animated fadeIn2"" src=""../../QRcode.ashx?t=" & Allurl & newUrl & """/>")
        ss.Append("<img class=""share animated fadeIn2"" src=""../img/share.png"" />" & vbCrLf)
        ss.Append("<a href=""../me/capp.aspx?i=" & Request.QueryString("i") & """><img class=""create animated fadeIn2"" src=""../img/create.png"" /></a>" & vbCrLf)
        ss.Append("<a href=""../me/FBShare.aspx?i=" & Request.QueryString("i") & """><img class=""lastpg animated fadeIn"" src=""../img/lastpg-word.png"" /></a>" & vbCrLf)
        'ss.Append("<a href=""Maker.aspx?i=" & Request.QueryString("i") & """>返回修改</a>" & vbCrLf)
        ss.Append("</div>" & vbCrLf)
        ss.Append("<input type=""hidden"" value=""" & (d.Rows.Count + 2) & """ id=""MaxNum"">" & vbCrLf)
        ' ss.Append("<script>var maxPage=8;</script>" & vbCrLf)
        ss.Append(Thefoot & vbCrLf)  '.Replace("css/", "../css/").Replace("js/", "../js/")

        Dim AppUrl As String = Allurl & newUrl
        main.ParaAdd("@gg", AppUrl, System.Data.SqlDbType.NVarChar) '產生網址之後把 路徑寫入App資料庫

        str = "Update User_App set App_URL=@gg where IDNo=@app_id And User_ID=@User_ID"
        main.NonQuery(str)

        'If Directory.Exists(MP) = False Then Directory.CreateDirectory(MP) '沒有資料夾主動建立
        Dim SW As StreamWriter = New StreamWriter(LAppPath, False, System.Text.Encoding.UTF8) '寫成檔案存成 Encoding.UTF8 避免亂碼 

        Try
            SW.WriteLine(ss.ToString())
            SW.Flush()
            SW.Close()
        Catch ex As Exception
            SW.Flush()
            SW.Close()
        Finally
            SW.Close()
        End Try
        Return AppUrl
    End Function

    Private Sub LK1_Click(sender As Object, e As EventArgs) Handles LK1.Click

        If IsNumeric(Request.QueryString("i")) Then
            Dim tmp As String = ""

            If TAppName.Text.Trim = "" Then
                tmp += ",iApp名稱"
            End If
            If tmp <> "" Then
                Response.Write("<Script>alert('請填入" & tmp.Substring(1) & "');</Script>")
                Exit Sub
            End If

            str = "Update User_App set App_Icon=@App_Icon where IDNo=@App_id"
            main.NonQuery(str)



            main.ParaClear()
            main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)
            main.ParaAdd("@App_Name", TAppName.Text.Trim(), System.Data.SqlDbType.NVarChar)
            main.ParaAdd("@App_Memo", TAppMemo.Text.Trim(), System.Data.SqlDbType.NVarChar)

            If Tbase64.Text.Trim <> "" Then
                Dim ImgName As String = "ico_" & Request.QueryString("i") & ".jpg"
                Dim ImgPath As String = comm.CurrentAppFolder(Request.QueryString("i")) & "\pic\"
             
                If File.Exists(ImgPath & ImgName) = True Then File.Delete(ImgPath & ImgName)
                If System.IO.Directory.Exists(ImgPath) = False Then System.IO.Directory.CreateDirectory(ImgPath)
                Dim buf As Byte() = Convert.FromBase64String(Tbase64.Text.Trim)
                'comm.WriteLog(ImgPath & ImgName)

                Dim TYU As New FileStream(ImgPath & ImgName, FileMode.CreateNew)
                TYU.Write(buf, 0, buf.Length)
                TYU.Close()
                ' main.ParaAdd("@App_Icon", ImgName, System.Data.SqlDbType.NVarChar)
                main.NonQuery("Update User_App set App_Icon='" & ImgName & "' where IDNo=@App_id")
            End If


            str = "Update User_App set App_Name=@App_Name,App_Memo=@App_Memo where IDNo=@app_id"
            Dim c As Integer = main.NonQuery(str)
            If c > 0 Then
                Dim newURl As String = main.Scalar("Select App_Url from User_App where IDNo=@App_id")
                Response.Write("<Script>window.open('" & newURl & "','_self');</Script>")
                Response.End()
            Else
                Response.Write("<Script>alert('上傳失敗，請稍後再試');</Script>")
                '  System.Web.UI.ScriptManager.RegisterStartupScript(Me, Me.GetType(), "KeyName", "alert('上傳失敗，請稍後再試');", True)
            End If
        End If
    End Sub
End Class
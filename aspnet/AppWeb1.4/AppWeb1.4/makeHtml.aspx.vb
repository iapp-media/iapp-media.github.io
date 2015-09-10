Imports System.Data
Imports System.IO
Public Class MakeHtml
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Comm.IsNumeric(Request.QueryString("i")) Then
                Session("Ap_id") = Request.QueryString("i")
            End If

            Dim preUrl As String = MakeHtml()
            Response.Write(preUrl)
            Response.End()

        End If
    End Sub

    Function MakeHtml()                                                                 '產生使用者的APP HTML
        Dim LAppPath As String = comm.CurrentAppFolder(Session("Ap_id")) & "\" & Session("Ap_id") & ".html"                   '產生App的主{{{路徑}}}
        Dim newUrl As String = Comm.CurrentAppFolder(Session("Ap_id")).Replace(Comm.AppPath, "Apps/") & "/" & Session("Ap_id") '回傳javaScript AJAX !!!!網址!!!!
        Dim url As String = "Select Theme_head,Theme_foot from Theme where IDNo=@Theme_ID"      '選擇主題 帶入App上下兩段HTML
        Dim AppUrl As String = Comm.URL & newUrl
        Main.ParaClear()
        Main.ParaAdd("@User_ID", Comm.User_ID, System.Data.SqlDbType.Int)            'User 的IDNO
        Main.ParaAdd("@app_id", Session("Ap_id"), System.Data.SqlDbType.Int)            'User_App 的IDNO
        Main.ParaAdd("@Theme_ID", Comm.Theme_ID, System.Data.SqlDbType.Int)
        Dim ss As New StringBuilder

        Main.ParaAdd("@gg", AppUrl, System.Data.SqlDbType.NVarChar) '產生網址之後把 路徑寫入App資料庫
        str = "Update User_App set App_URL=@gg where IDNo=@app_id And User_ID=@User_ID And Theme_ID=@Theme_ID"
        Main.NonQuery(str)


        str = "Select a.Page_Type,Html,b.Img01,b.Img02,b.Img03,b.h1,b.h2 from Pages a inner join User_Page b on a.IDNo=b.Page_ID where b.User_App_ID=@app_id and b.Theme_ID=@Theme_ID order by sort"
        Dim themeTable As DataTable = Main.GetDataSet(url)
        Dim TheHead As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_head"))
        Dim Thefoot As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_foot"))
        Dim d As DataTable = Main.GetDataSet(str)
        Dim AppName As String = "iApp Mobile We-Media"
        Dim AppMemo As String = "我的媒體我做主，行動時代，行動自媒體"
        Dim ShareImg As String = ""
        Dim DtApp As DataTable = Main.GetDataSet("Select * from User_App where IDNo=@app_id")
        If DtApp.Rows.Count > 0 Then
            AppName = DtApp.Rows(0).Item("App_Name")
            AppMemo = DtApp.Rows(0).Item("App_Memo").ToString().Replace(vbCrLf, " ")
            If DtApp.Rows(0).Item("Share_Img") <> "" Then ShareImg = Comm.URL & "Apps/" & DtApp.Rows(0).Item("App_Folder") & "/pic/" & DtApp.Rows(0).Item("Share_Img")
        End If
        TheHead = TheHead.Replace("[AppName]", AppName).Replace("[AppMemo]", AppMemo).Replace("[ShareImg]", ShareImg).Replace("[AppUrl]", AppUrl)


        ss.Append(TheHead & vbCrLf)  '.Replace("css/", "../css/").Replace("js/", "../js/")

        '以下這一段放到Theme.Theme_head
        'ss.Append("<div>" & vbCrLf)                                                     '第一頁公司LOGO 一定會有 
        'ss.Append("<div id=""firstpage"" class=""page page-1-1 page-current"">" & vbCrLf)
        'ss.Append(" <img class=""logo animated bounceInDownrubberBand"" src=""../img/logo.png"" />" & vbCrLf)
        'ss.Append(" <img class=""up moveIconUp"" src=""../img/icon_up.png"" />" & vbCrLf)
        'ss.Append("</div>" & vbCrLf)
        'ss.Append("</div>" & vbCrLf)

        If d.Rows.Count > 0 Then '動態產生的DIV 內頁
            For i As Integer = 0 To d.Rows.Count - 1
                Dim dw As DataRow = d.Rows(i)
                Dim html As String = HttpUtility.HtmlDecode(dw("Html"))
                ss.Append("<div id=""page-" & i + 2 & "-1"" class=""page page-" & Comm.Cint2(dw("Page_Type")) & "-1 hide"">" & vbCrLf)
                If dw("Img01").ToString() <> "" And dw("Img02").ToString() <> "" And dw("Img03").ToString() <> "" Then
                    ss.Append(html.Replace("[img01]", "../" & dw("Img01")).Replace("[img02]", "../" & dw("Img02")).Replace("[img03]", "../" & dw("Img03")) & vbCrLf) '出來兩層賦予圖片路徑
                Else
                    ss.Append(html.Replace("[img01]", "../" & dw("Img01")).Replace("[text1]", dw("h1")).Replace("[text2]", dw("h2")) & vbCrLf)
                End If
                ss.Append("</div>" & vbCrLf)
            Next

        End If
        ss.Append("<input type=""hidden"" value=""" & (d.Rows.Count + 2) & """ id=""MaxNum"">" & vbCrLf)
        ss.Append("<div id=""page-" & d.Rows.Count + 2 & "-1"" class=""page pagelast hide""> " & vbCrLf) '最後一段分享的網頁
        Thefoot = Thefoot.Replace("[QR]", "../../QRcode.ashx?t=" & Comm.URL & newUrl)
        ss.Append(Thefoot & vbCrLf)


        '以下這一段放到Theme.Theme_foot
        'ss.Append("<div class=""page pagelast page-" & d.Rows.Count + 2 & "-1 hide""> " & vbCrLf) '最後一段分享的網頁
        'ss.Append("<div class=""bg""></div>" & vbCrLf)
        'ss.Append("<img class=""logo2 animated bounceInRight1"" src=""../img/logo2.png"" />" & vbCrLf)
        'ss.Append("<img class=""qr animated fadeIn2"" src=""../../QRcode.ashx?t=" & Comm.URL & newUrl & """/>")
        'ss.Append("<a href=""" & Comm.URL.Replace("/" & Comm.Theme, "") & "Share.aspx"" target=""_blank""><img class=""share animated fadeIn2"" src=""../img/share.png"" /></a>" & vbCrLf)
        'ss.Append("<a href=""../Me/capp.aspx?i=" & Session("Ap_id") & """><img class=""create animated fadeIn2"" src=""../img/create.png"" /></a>" & vbCrLf)
        'ss.Append("<img class=""lastpg animated fadeIn"" src=""../img/lastpg-word.png"" />" & vbCrLf)
        'ss.Append("</div>" & vbCrLf)

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

End Class
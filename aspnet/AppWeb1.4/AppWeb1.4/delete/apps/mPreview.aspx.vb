Public Class mPreview
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Dim Allurl As String = System.Configuration.ConfigurationSettings.AppSettings.Get("url")
    Public AppPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("AppPath") '主路徑+Apps+01~XX

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MakeHtml()
        End If 
    End Sub

    Sub MakeHtml()                                                                 '產生使用者的APP HTML
        Main.ParaClear()
        ' Main.ParaAdd("@User_ID", Session("IDNo"), System.Data.SqlDbType.Int)            'User 的IDNO
        Main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)            'User_App 的IDNO
        Main.ParaAdd("@Theme_ID", Main.Scalar("Select Theme_ID from User_App where IDNo=" & Request.QueryString("i")), System.Data.SqlDbType.Int)
        Dim ss As New StringBuilder
        Dim TotalPages As Integer = 0

        str = "Select Html,b.Img01,b.Img02,b.Img03,b.h1,b.h2 from Pages a inner join User_Page b on a.IDNo=b.Page_ID where b.User_App_ID=@app_id order by sort"
        Dim url As String = "Select Theme_head,Theme_foot from Theme where IDNo=@Theme_ID"      '選擇主題 帶入App上下兩段HTML
        Dim themeTable As DataTable = Main.GetDataSet(url)
        Dim TheHead As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_head"))
        Dim Thefoot As String = HttpUtility.HtmlDecode(themeTable.Rows(0).Item("Theme_foot"))
        Dim d As DataTable = Main.GetDataSet(str)
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

        ss.Append("<div class=""page page-" & d.Rows.Count + 1 & "-1 hide""> " & vbCrLf) '最後一段分享的網頁
        ss.Append("<div class=""bg""></div>" & vbCrLf)
        ss.Append("<img class=""logo2 animated bounceInRight1"" src=""../img/logo2.png"" />" & vbCrLf)
        ss.Append("<img class=""qr animated fadeIn2"" src=""../../QRcode.ashx?t=" & Allurl & """/>")
        ss.Append("<img class=""share animated fadeIn2"" src=""../img/share.png"" />" & vbCrLf)
        ss.Append("<a href=""Maker.aspx?i=" & Request.QueryString("i") & """><img class=""create animated fadeIn2"" src=""../img/create.png"" /></a>" & vbCrLf)
        ss.Append("<img class=""lastpg animated fadeIn"" src=""../img/lastpg-word.png"" />" & vbCrLf)
        ss.Append("<a href=""Maker.aspx?i=" & Request.QueryString("i") & """>返回修改</a>" & vbCrLf)
        'ss.Append("</div>" & vbCrLf)
        '  ss.Append("<script>var maxPage=8;</script>" & vbCrLf)
        ss.Append(Thefoot & vbCrLf)  '.Replace("css/", "../css/").Replace("js/", "../js/")

        Response.Write(ss.ToString())
        Response.End()
    End Sub
     
End Class
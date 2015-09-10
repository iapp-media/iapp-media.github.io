Imports System.IO

Public Class Maker
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Dim Allurl As String = System.Configuration.ConfigurationSettings.AppSettings.Get("url")
    Public AppPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("AppPath")
    Dim SortNum As Integer = 1
    Dim MP As String = CheckPath() '主路徑+Apps+01~XX

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If IsNumeric(Request.QueryString("i")) Then
                'LPreview.Text = "<a href=""mPreview.aspx?i=" & Request.QueryString("i") & """>" & _
                '                "<img src=""img/preview-1.png"" class=""share animated pulse"" /></a>"
                'LSet.Text = "<a href=""mSet.aspx?i=" & Request.QueryString("i") & """>" & _
                '                "<img src=""img/send-1.png"" class=""create animated pulse"" /></a>"
                Dim ss As New StringBuilder
                str = "Select a.*, b.Page_Type from User_Page a inner join Pages b on a.Page_ID=b.IDNo " &
                      " where a.User_App_ID=" & Request.QueryString("i") & " order by sort"
                Dim d As DataTable = main.GetDataSet(str)
                If d.Rows.Count > 0 Then
                    Dim Inputs As String = ""
                    For i As Integer = 0 To d.Rows.Count - 1
                        Dim dw As DataRow = d.Rows(i)

                        ss.Append(vbCrLf)
                        ss.Append("<!--   page " & (i + 2) & "   ----------------------------------------------->" & vbCrLf)
                        ss.Append("<div class=""page page-" & i + 2 & "-1 hide"">" & vbCrLf)
                        ss.Append("<img class=""up moveIconUp"" src=""img/icon_up.png"" />" & vbCrLf)
                        Select Case CInt(dw("Page_Type"))
                            Case 1

                                '說明：img的id是  p+[User_Page.IDNo]+[-]+n，n=1代表是img01這個欄位，n=2代表img02
                                ss.Append(" <div class=""takeimage1"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,960)"">" & vbCrLf)
                                ss.Append("         <img src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""bg animated zoomIn"">" & vbCrLf)
                                ss.Append("    <img id=""p" & dw("IDNo") & "-1"" class=""bg"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                            Case 2

                                '說明：文字的id是  t+[User_Page.IDNo]+[-]+n，n=1代表是h1這個欄位，n=2代表h2

                                ss.Append(" <div class=""takeimage2"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,960)"">" & vbCrLf)
                                ss.Append("         <img src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""bg animated zoomInDown"">" & vbCrLf)
                                ss.Append("     <img id=""p" & dw("IDNo") & "-1"" class=""bg"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""bar1 animated fadeIn1"">" & vbCrLf)
                                ss.Append("     <p class=""text1 animated fadeInLeft1"">" & vbCrLf)
                                ss.Append("         <input type=""text"" value=""" & dw("h1") & """ name=""t" & dw("IDNo") & "-1"" id=""t" & dw("IDNo") & "-1""> <br>" & vbCrLf)
                                ss.Append("         <input type=""text"" value=""" & dw("h2") & """ name=""t" & dw("IDNo") & "-2"" id=""t" & dw("IDNo") & "-2"">" & vbCrLf)
                                ss.Append("     </p>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                Inputs += ",t" & dw("IDNo") & "-1"
                                Inputs += ",t" & dw("IDNo") & "-2"

                            Case 3
                                ss.Append(" <div class=""takeimage3-1"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,320)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""border bg1"">" & vbCrLf)
                                ss.Append("     <img id=""p" & dw("IDNo") & "-1"" class=""bg animated slideInLeft1"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                ss.Append(" <div class=""takeimage3-2"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-2',640,320)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append("<div class=""border bg2"">" & vbCrLf)
                                ss.Append("    <img id=""p" & dw("IDNo") & "-2"" class=""bg animated slideInRight1"" src=""../" & dw("Img02") & """>" & vbCrLf)
                                ss.Append("</div>" & vbCrLf)

                                ss.Append(" <div class=""takeimage3-3"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-3',640,320)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append("`</div>" & vbCrLf)
                                ss.Append("<div class=""border bg3"">" & vbCrLf)
                                ss.Append("    <img id=""p" & dw("IDNo") & "-3"" class=""bg animated slideInLeft2"" src=""../" & dw("Img03") & """>" & vbCrLf)
                                ss.Append("</div>" & vbCrLf)
                            Case 4
                                ss.Append(" <div class=""takeimage4-1"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,480)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append("<div class=""border bg4"">" & vbCrLf)
                                ss.Append("    <img id=""p" & dw("IDNo") & "-1"" class=""bg animated slideInDown1"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append("</div>" & vbCrLf)

                                ss.Append(" <div class=""takeimage4-2"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-2',320,480)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""border bg5"">" & vbCrLf)
                                ss.Append("     <img id=""p" & dw("IDNo") & "-2"" class=""bg animated slideInLeft1"" src=""../" & dw("Img02") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                ss.Append(" <div class=""takeimage4-3"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-3',320,480)"">" & vbCrLf)
                                ss.Append("         <img class=""uploadicon-s"" src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""border bg6"">" & vbCrLf)
                                ss.Append("     <img id=""p" & dw("IDNo") & "-3"" class=""bg animated slideInRight1"" src=""../" & dw("Img03") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                            Case 5
                                ss.Append(" <div class=""takeimage5"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,960)"">" & vbCrLf)
                                ss.Append("         <img src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""bg"">" & vbCrLf)
                                ss.Append("     <img id=""p" & dw("IDNo") & "-1"" class=""bg"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                ss.Append(" <div class=""bar2 animated fadeIn1"">" & vbCrLf)
                                ss.Append("     <p class=""text2 animated fadeInUp1"">" & vbCrLf)
                                ss.Append("         <input type=""text"" value=""" & dw("h1") & """ size=""24"" name=""t" & dw("IDNo") & "-1"" id=""t" & dw("IDNo") & "-1"">" & vbCrLf)
                                ss.Append("     </p>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                Inputs += ",t" & dw("IDNo") & "-1"

                            Case 6
                                ss.Append(" <div class=""takeimage6"">" & vbCrLf)
                                ss.Append("     <label for=""inputImage"" onclick=""setCurrent('" & dw("IDNo") & "-1',640,960)"">" & vbCrLf)
                                ss.Append("         <img src=""img/uploadicon.png"" />" & vbCrLf)
                                ss.Append("     </label>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)
                                ss.Append(" <div class=""bg"">" & vbCrLf)
                                ss.Append("    <img id=""p" & dw("IDNo") & "-1"" class=""bg"" src=""../" & dw("Img01") & """>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                ss.Append(" <div>" & vbCrLf)
                                ss.Append("     <div class=""textbox"">" & vbCrLf)
                                ss.Append("         <p class=""text3 animated swing1"" style=""color: white"">" & vbCrLf)
                                ss.Append("             <input type=""text"" value=""" & dw("h1") & """ size=""12"" name=""t" & dw("IDNo") & "-1"" id=""t" & dw("IDNo") & "-1""></p>" & vbCrLf)
                                ss.Append("     </div>" & vbCrLf)
                                ss.Append("     <div class=""shadow""></div>" & vbCrLf)
                                ss.Append(" </div>" & vbCrLf)

                                Inputs += ",t" & dw("IDNo") & "-1"

                        End Select
                        ss.Append("</div>" & vbCrLf)
                    Next

                    MaxNum.Value = d.Rows.Count + 2
                    ss.Append("<div class=""page page-" & (d.Rows.Count + 2) & "-1 hide"">" & vbCrLf)
                    Literal1.Text = ss.ToString()
                    IIDs.Value = Inputs

                End If
            End If
        End If
    End Sub

    Function MakeHtml()                                                                 '產生使用者的APP HTML
        Dim LAppPath As String = MP & "\" & Request.QueryString("i") & ".html"                   '產生App的主{{{路徑}}}
        main.ParaClear()
        main.ParaAdd("@User_ID", comm.User_ID, System.Data.SqlDbType.Int)            'User 的IDNO
        main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)            'User_App 的IDNO
        main.ParaAdd("@Theme_ID", comm.Theme_ID, System.Data.SqlDbType.Int)
        Dim ss As New StringBuilder

        str = "Select Html,b.Img01,b.Img02,b.Img03,b.h1,b.h2 from Pages a inner join User_Page b on a.IDNo=b.Page_ID where User_ID=@User_ID and b.User_App_ID=@app_id and b.Theme_ID=@Theme_ID order by sort"
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

        End If


        Dim newUrl As String = CheckPath().Replace(AppPath, "Apps/") & "/" & Request.QueryString("i") '回傳javaScript AJAX !!!!網址!!!!

        ss.Append("<div class=""page page-" & d.Rows.Count + 2 & "-1 hide last-page""> " & vbCrLf) '最後一段分享的網頁
        ss.Append("<div class=""bg""></div>" & vbCrLf)
        ss.Append("<img class=""logo2 animated bounceInRight1"" src=""../img/logo2.png"" />" & vbCrLf)
        ss.Append("<img class=""qr animated fadeIn2"" src=""../../QRcode.ashx?t=" & Allurl & newUrl & """/>")
        ss.Append("<img class=""share animated fadeIn2"" src=""../img/share.png"" />" & vbCrLf)
        ss.Append("<img class=""create animated fadeIn2"" src=""../img/create.png"" />" & vbCrLf)
        ss.Append("<img class=""lastpg animated fadeIn"" src=""../img/lastpg-word.png"" />" & vbCrLf)
        ss.Append("</div>" & vbCrLf)
        ss.Append(Thefoot & vbCrLf)  '.Replace("css/", "../css/").Replace("js/", "../js/")

        Dim AppUrl As String = Allurl & newUrl
        main.ParaAdd("@gg", AppUrl, System.Data.SqlDbType.NVarChar) '產生網址之後把 路徑寫入App資料庫

        str = "Update User_App set App_URL=@gg where IDNo=@app_id And User_ID=@User_ID And Theme_ID=@Theme_ID"
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

    Function CheckPath() As String  '檢查資料夾 是否存在 以及是否滿100筆 
        Dim i As Integer
        Dim MP As String = ""
        For i = 0 To 10
            MP = AppPath & Format(SortNum, "0#")
            If Directory.Exists(MP) = False Then
                Directory.CreateDirectory(MP)
                Exit For
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
   
    Private Sub IBSend_Click(sender As Object, e As ImageClickEventArgs) Handles IBSend.Click
        If IsNumeric(Request.QueryString("i")) Then
            Dim tmp As String = ""
            '----檢查IsCopy
            str = "select count(*) from User_Page where (IsCopy01=1 or IsCopy02=1 or IsCopy03=1) and User_App_ID=" & Request.QueryString("i")
            If comm.Cint2(main.Scalar(str)) > 0 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "forcusTOP", "alert('為尊重圖像版權，敬請全面更換圖片！ 為您的iApp填加色彩，有利於完善發佈。');", True)
                Exit Sub
            End If

            If IIDs.Value <> "" Then
                Dim ss As String() = IIDs.Value.Substring(1).Split(",")
                For Each s As String In ss
                    Dim col As String() = s.Split("-")
                    If col(0).Substring(0, 1) = "t" And col.Length = 2 Then
                        Dim valu As String = Request(s)
                        'Response.Write(s & " = " & valu & "<br>")
                        main.ParaClear()
                        main.ParaAdd("@IDNo", col(0).Substring(1), SqlDbType.Int)
                        main.ParaAdd("@Value", valu, SqlDbType.NVarChar)
                        str = "Update User_Page set h" & col(1) & "=@Value where IDNo=@IDNo"
                        main.NonQuery(str)
                        main.WriteCMD()

                    End If
                Next
            End If



            Response.Redirect("mSet.aspx?i=" & Request.QueryString("i"))
            Response.End()


        End If
    End Sub
End Class
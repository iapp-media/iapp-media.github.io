Imports System.Data
Imports System.IO
Imports System.Drawing
Imports Facebook
Imports System.Dynamic

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""
    Dim pageTopID As Integer 
    Dim SubPath As String = "img/" '使用者所選擇版型，的預設圖片存入資料庫
    Dim sort As Integer = 0

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        If Not IsPostBack Then

            If Not IsNumeric(Request.QueryString("i")) Then   '===首次進入
                Response.Redirect("Default.aspx?i=" & Comm.MyLastApp())
            Else
                If Comm.ThemeConflict(Request.QueryString("i")) Then Exit Sub '====檢查有沒有進錯主題
                Session("Ap_id") = Request.QueryString("i")

                show()
                LFrame2.Text = "<iframe id=""iframe-set"" class=""iframe-set"" src=""Setting2.aspx?i=" & Request.QueryString("i") & """ scrolling=""no""></iframe>"
                Dim userid As String = Main.Scalar("select User_ID from User_App where IDNo=" & Request.QueryString("i") & "")
                Dim userico As String = Main.Scalar("select 1 from users where  IDNo='" & userid & "' and User_Icon is not null ")
                If userico = "1" Then userico = "UserIcon.ashx?i=" & userid & "" Else userico = "img/defaulthead.jpg"
                 
                Lprofile.Text = "<a class='iframe-info' href=""http://www.iapp-media.com/Login/profile.aspx?i=" & userid & """>" & _
                   " <img class=""head"" src=""" & userico & """ /></a>"

                Dim AppUrl As String = Main.Scalar("Select App_Url from User_App where IDNo=" & Request.QueryString("i"))
                If IsNothing(Session("AccessToken")) Then
                    FBShare.OnClientClick() = "window.open('https://www.facebook.com/sharer.php?u=" & AppUrl.Replace(".html", "") & "','_blank','width=500,height=400,status=no');return false;"
                End If

                NewApps.Attributes.Add("onclick", "if(confirm('創建一個全新的iApp')){return true;}else{return false;}")

            End If

            MySub(0)

        End If
    End Sub

    Sub myImageButton(PageIDNo As Integer)
        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        Dim ss As New StringBuilder()
        Main.ParaClear()
        str = "Select ISNULL(MAX(Sort),0) from User_Page where User_ID =" & Comm.User_ID & " and User_App_ID=" & Request.QueryString("i")
        sort = Convert.ToInt32(Main.Scalar(str))
        Main.ParaAdd("@User_ID", Comm.User_ID, Data.SqlDbType.Int)
        Main.ParaAdd("@SessionID", "", System.Data.SqlDbType.VarChar)
        Main.ParaAdd("@User_App_ID", Request.QueryString("i"), SqlDbType.Int)
        Main.ParaAdd("@Theme_ID", Comm.Cint2(Comm.Theme_ID), SqlDbType.Int)
        'End If
        sort = sort + 1
        Main.ParaAdd("@Page_ID", PageIDNo, Data.SqlDbType.Int)
        Main.ParaAdd("@Sort", sort, Data.SqlDbType.Int)
        Dim sq11 As String = "select Img01_b,Img02_b,Img03_b,ImgNum,h1,h2 from Pages where IDNo=@Page_ID and Theme_ID=@Theme_ID" '找出pages基礎圖片寫入 User_Page
        Dim d As DataTable = Main.GetDataSet(sq11)
        Comm.WriteLog(sq11)

        If d.Rows(0).Item("ImgNum") = 1 Then
            Main.ParaAdd("@Img01", SubPath & d.Rows(0).Item("Img01_b"), System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@Img02", "", System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@Img03", "", System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@h1", d.Rows(0).Item("h1"), System.Data.SqlDbType.NVarChar)
            Main.ParaAdd("@h2", d.Rows(0).Item("h2"), System.Data.SqlDbType.NVarChar)
        ElseIf d.Rows(0).Item("ImgNum") = 3 Then
            Main.ParaAdd("@Img01", SubPath & d.Rows(0).Item("Img01_b"), System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@Img02", SubPath & d.Rows(0).Item("Img02_b"), System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@Img03", SubPath & d.Rows(0).Item("Img03_b"), System.Data.SqlDbType.VarChar)
            Main.ParaAdd("@h1", d.Rows(0).Item("h1"), System.Data.SqlDbType.NVarChar)
            Main.ParaAdd("@h2", d.Rows(0).Item("h2"), System.Data.SqlDbType.NVarChar)
        End If

        Dim sql As String = "Insert into User_Page(User_ID,Page_ID,User_App_ID,Sort,SessionID,Img01,Img02,Img03,h1,h2,Theme_ID) Values(@User_ID,@Page_ID,@User_App_ID,@Sort,@SessionID,@Img01,@Img02,@Img03,@h1,@h2,@Theme_ID)"
        Main.NonQuery(sql)
        MySub(0)
    End Sub

    Sub MySub(x As Integer) '建立左側小頁面

        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        Dim ss As New StringBuilder()
        Main.ParaClear()
        If IsNumeric(Comm.User_ID) Then
            Main.ParaAdd("@User_IDNo", Comm.User_ID, System.Data.SqlDbType.Int)
            Main.ParaAdd("@User_App_ID", Request.QueryString("i"), SqlDbType.Int)
            Main.ParaAdd("@Theme_ID", Comm.Cint2(Comm.Theme_ID), SqlDbType.Int)
            'str = "Select b.IDNo PID,a.* from Pages a inner join User_Page b ON a.IDNo=b.Page_ID and b.User_ID=@User_IDNo  where User_App_ID=@User_App_ID  order by Sort"
            str = "Select b.IDNo PID,a.* from Pages a inner join User_Page b ON a.IDNo=b.Page_ID and b.User_ID=@User_IDNo  where b.User_App_ID=@User_App_ID And b.Theme_ID=@Theme_ID  order by Sort"
        End If
        Dim dr As DataTable = Main.GetDataSet(str)
        Main.WriteCMD()

        Dim btnId As Integer = 0

        If (dr.Rows.Count > 0) Then
            For i = 0 To dr.Rows.Count - 1
                ss.Append("<li id=""s" & dr.Rows(i).Item("PID") & """>" & vbCrLf)
                ss.Append(" <a href=""javascript: void(0)"" onclick=""show('Pages/see.aspx?ID=" & dr.Rows(i).Item("PID").ToString().Replace("#", "") & "'," & dr.Rows(i).Item("PID").ToString() & ")"">" & vbCrLf)
                ss.Append(" <img class=""border active"" src=""img/border-small1.png""/></a>" & vbCrLf)
                ss.Append(" <a href=""javascript: void(0)"" onclick=""putDELE('" & dr.Rows(i).Item("PID") & "');__doPostBack('DELE1','')"">" & vbCrLf)
                ss.Append(" <img  class=""delete"" src=""img/delete.png""/></a>" & vbCrLf)
                ss.Append(" <img class=""pic"" src=""img/" & dr.Rows(i).Item("Img01") & """/>" & vbCrLf)
                ss.Append(" <div class=""num"">第" & (i + 1) & "頁</div>" & vbCrLf)
                ss.Append("</li>" & vbCrLf)
                'T3.Text = dr.Rows(i).Item("PID")
                If x = 1 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "forcusTOP", "forcusTOP()", True)
                ElseIf x = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "forcus", "forcus()", True)
                End If
            Next
        End If
        L.Text = ss.ToString()
    End Sub

    'Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    '  AA.Text = comm.Cint2(AA.Text) + 1
    '    'Comm.WriteLog("Timer1_Tick:" & Now.ToLongTimeString())
    '    'If AA.Text <> "" Then
    '    '    Dim s() As String = AA.Text.Split(",")
    '    '    For i As Integer = 0 To s.Length - 1
    '    '        str = "Update User_Page set sort=" & (i + 1) & " where IDNo=" & s(i).Replace("s", "")
    '    '        Main.NonQuery(str)
    '    '        Comm.WriteLog("Timer1_Tick:" & str)
    '    '    Next
    '    'End If
    '    'AA.Text = ""
    'End Sub

    Private Sub DELE1_Click(sender As Object, e As EventArgs) Handles DELE1.Click
        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        Dim Folder As String = ""
        Folder = Main.Scalar("select App_Folder from User_App where IDNo in (select User_App_ID from User_Page where idno=" & DELEID.Text & ")")
        If Folder <> "" Then
            Folder = Folder & "/"
            Dim DT As DataTable = Main.GetDataSetNoNull("select * from User_Page where IDNo=" & DELEID.Text)
            If DT.Rows.Count > 0 Then
                Dim dw As DataRow = DT.Rows(0)
                If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & dw("Img01").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & dw("Img01").ToString().Replace(Folder, ""))
                If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & dw("Img02").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & dw("Img02").ToString().Replace(Folder, ""))
                If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & dw("Img03").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & dw("Img03").ToString().Replace(Folder, ""))
            End If
        End If

        Main.NonQuery("delete from User_Page where IDNo=" & DELEID.Text)
        MySub(1)

        '要刪資料夾圖片 
    End Sub

    'Sub FBPO()
    '    If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

    '    str = "select * from User_App where IDNo=" & Request.QueryString("i") & "And User_ID=" & Comm.User_ID
    '    Dim d As DataTable = Main.GetDataSetNoNull(str)
    '    If d.Rows.Count > 0 Then
    '        Dim dw As DataRow = d.Rows(0)

    '        If Not IsNothing(Session("AccessToken")) Then
    '            Dim result As Object = New System.Dynamic.ExpandoObject()
    '            Dim accessToken = Session("AccessToken").ToString()
    '            Dim client = New FacebookClient(accessToken)
    '            result = client.[Get]("me", New With {Key .fields = "name,id"})
    '            Dim name As String = result.name
    '            Dim UserId As String = result.id
    '            Try
    '                Dim messagePost As Object = New System.Dynamic.ExpandoObject()
    '                'messagePost.picture = "http://w ww.iapp-media.com/basic/Apps/Img/p04-1.jpg"
    '                Dim fbpic As String = "http://www.iapp-media.com/basic/Apps/" & dw("App_Folder") & "/pic/" & dw("Share_Img")
    '                messagePost.picture = fbpic
    '                messagePost.link = dw("App_Url")
    '                messagePost.name = dw("App_Name")
    '                messagePost.description = dw("App_Memo")
    '                ' messagePost.caption = "this is caption"
    '                'messagePost.description = "這是季軒的FB整合測試 for description";//圖片描述
    '                'messagePost.message = dw("App_Memo")
    '                client.Post(UserId & Convert.ToString("/feed"), messagePost)
    '            Catch ex As FacebookOAuthException
    '                Response.Write(ex.Message)
    '            End Try
    '        End If
    '    End If
    '    '  Response.Write("<Script>alert('" & Fburl & "');</Script>")
    'End Sub

    Sub show()
        str = "Select *,'img/'+img01 img from Pages where Theme_ID =" & Comm.Theme_ID
        SD1.SelectCommand = str
        SD1.ConnectionString = Main.ConnStr
        RP1.DataSourceID = SD1.ID
    End Sub

    Protected Sub RP1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RP1.ItemCommand
        Dim LK As Literal = e.Item.FindControl("L1")
        Dim Key As Integer = Convert.ToInt32(LK.Text)
        If e.CommandName = "addPage" Then
            myImageButton(Key)
        End If
    End Sub

    Private Sub RP1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RP1.ItemDataBound
        Dim L2 As Literal = e.Item.FindControl("L2")
        Dim LK As Literal = e.Item.FindControl("L1")
        L2.Text = "<div class=""pic" & (e.Item.ItemIndex + 1) & """>"
    End Sub

    'Private Sub FBShare_Click(sender As Object, e As EventArgs) Handles FBShare.Click
    '    If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

    '    If Not IsNothing(Session("AccessToken")) Then
    '        FBPO()
    '        'Response.Write("<Script language='JavaScript'>alert('成功發佈在FB!!');window.open('" & Request.RawUrl & "','_top')</Script>")
    '        'Response.End()
    '    End If
    'End Sub

    Private Sub NewApps_Click(sender As Object, e As EventArgs) Handles NewApps.Click
        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        Response.Write("<Script>window.open('Default.aspx?i=" & Comm.CreateNewApp("我的iApp") & "','_top')</Script>")
        Response.End()
    End Sub

    Private Sub SavSort_Click(sender As Object, e As EventArgs) Handles SavSort.Click
        If AA.Text <> "" Then
            Dim s() As String = AA.Text.Split(",")
            For i As Integer = 0 To s.Length - 1
                str = "Update User_Page set sort=" & (i + 1) & " where IDNo=" & s(i).Replace("s", "")
                Main.NonQuery(str)
                ' Comm.WriteLog("SavSort_Click:" & str)
            Next
        End If
        AA.Text = ""
    End Sub
End Class

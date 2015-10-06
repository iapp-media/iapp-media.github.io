Imports System.IO
Imports System.Drawing
Imports Facebook

Public Class list
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            show()
        End If
    End Sub
    Private Sub RP1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RP1.ItemCommand
        Dim LK As Literal = e.Item.FindControl("LKey")
        If e.CommandName = "CN2" Then
            Dim Folder As String = ""
            Folder = Main.Scalar("select App_Folder from User_App where IDNo =" & LK.Text)
            If Folder <> "" Then
                Folder = Folder & "/"
                Dim DT As DataTable = Main.GetDataSetNoNull("select * from User_Page where User_App_ID=" & LK.Text)
                If DT.Rows.Count > 0 Then
                    For Each DTRow As DataRow In DT.Rows
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img01").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img01").ToString().Replace(Folder, ""))
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img02").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img02").ToString().Replace(Folder, ""))
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img03").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow("Img03").ToString().Replace(Folder, ""))
                    Next
                End If
                Dim DT2 As DataTable = Main.GetDataSetNoNull("select *  from User_App where IDNo =" & LK.Text)
                If DT2.Rows.Count > 0 Then
                    Folder = Folder & "/pic/"
                    For Each DTRow2 As DataRow In DT2.Rows
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("App_Icon").ToString()) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("App_Icon").ToString())
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("App_Cover").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("App_Cover").ToString())
                        If System.IO.File.Exists(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("Share_Img").ToString().Replace(Folder, "")) = True Then System.IO.File.Delete(Comm.AppPath & Folder.Replace("/", "\") & DTRow2("Share_Img").ToString())
                    Next
                End If
            End If

            str = "Delete from User_Page where User_App_ID =" & LK.Text & ";" & "Delete from User_App where IDNo=" & LK.Text
            Main.NonQuery(str)
            show()
        ElseIf e.CommandName = "CN3" Then

            Dim AppUrl As String = Main.Scalar("Select ISNULL(App_Url,'') from User_App where IDNo=" & LK.Text)
            If AppUrl = "" Then
                Response.Write("<Script language='JavaScript'>alert('請先發布!!');</Script>")
                Return 
            End If

            If IsNothing(Session("AccessToken")) Then
                Response.Write("<Script language='JavaScript'>window.open('https://www.facebook.com/sharer.php?u=" & AppUrl.Replace(".html", "") & "','_SELF','width=500,height=400,status=no');</Script>")
            End If

            If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub
            If Not IsNothing(Session("AccessToken")) Then
                FBPO(LK.Text)
                Response.Write("<Script language='JavaScript'>alert('成功發佈在FB!!');window.open('" & Request.RawUrl & "','_SELF')</Script>")
                Response.End()
            End If
        End If
        'Response.Write("CN2")
    End Sub
    Sub FBPO(APID As String)
        If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub

        str = "select * from User_App where IDNo=" & APID & "And User_ID=" & Comm.User_ID
        Dim d As DataTable = Main.GetDataSetNoNull(str)
        If d.Rows.Count > 0 Then
            Dim dw As DataRow = d.Rows(0)

            If Not IsNothing(Session("AccessToken")) Then
                Dim result As Object = New System.Dynamic.ExpandoObject()
                Dim accessToken = Session("AccessToken").ToString()
                Dim client = New FacebookClient(accessToken)
                result = client.[Get]("me", New With {Key .fields = "name,id"})
                Dim name As String = result.name
                Dim UserId As String = result.id
                Try
                    Dim messagePost As Object = New System.Dynamic.ExpandoObject()
                    messagePost.picture = "http://www.iapp-media.com/basic/Apps/Img/p04-1.jpg"

                    messagePost.link = dw("App_Url")
                    messagePost.name = dw("App_Name")
                    messagePost.description = dw("App_Memo")
                    ' messagePost.caption = "this is caption"
                    'messagePost.description = "這是季軒的FB整合測試 for description";//圖片描述
                    'messagePost.message = dw("App_Memo")
                    client.Post(UserId & Convert.ToString("/feed"), messagePost)
                Catch ex As FacebookOAuthException
                    Response.Write(ex.Message)
                End Try
            End If
        End If
        '  Response.Write("<Script>alert('" & Fburl & "');</Script>")
    End Sub

    Private Sub RP1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RP1.ItemDataBound
        If e.Item.ItemIndex > -1 Then
            Dim LK As Literal = e.Item.FindControl("LKey")
            Dim LL As Literal = e.Item.FindControl("L2")
            Dim LL3 As Literal = e.Item.FindControl("L3")
            str = "Select Theme_ID from User_App where IDNo=" & LK.Text
            Dim Theme_ID As String = Main.Scalar(str)
            LL.Text = "<a href=""default.aspx?i=" & LK.Text & """ target=""_top"" class=""edit-1"">編輯</a>" '編輯
            LL3.Text = "<a href=""setting1.aspx?i=" & LK.Text & """ class=""setting-1"">設定</a>" '設定
        End If
    End Sub

    Sub show()
        str = "Select * from User_App where User_ID=" & comm.User_ID
        SD1.SelectCommand = str
        SD1.ConnectionString = Main.ConnStr
        RP1.DataSourceID = SD1.ID
    End Sub

    Protected Sub LBNew_Click(sender As Object, e As EventArgs) Handles LBNew.Click
        Main.ParaClear()
        Main.ParaAdd("@User_Id", Comm.User_ID, SqlDbType.Int)
        Main.ParaAdd("@Theme_ID", Comm.Theme_ID, Data.SqlDbType.VarChar)
        Comm.CreateNewApp(" ")
        str = "Select Top 1 IDNo from User_App where Theme_ID=@Theme_ID And User_ID=@User_Id order by IDNo Desc"
        Dim AP_id As String = Main.Scalar(str)
        Response.Write("<Script>window.open('Default.aspx?i=" & AP_id & "','_top')</Script>")
        Response.End()
    End Sub
End Class
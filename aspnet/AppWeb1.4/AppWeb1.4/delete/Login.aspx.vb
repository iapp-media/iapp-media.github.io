Imports System.Data
Partial Class Login
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""
    Dim CookieDays As Integer = 30   '設定Cookie存留時間

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Comm.ChkLoginStat("Login.aspx") Then
            '    Response.Write("<Script>window.open('Default.aspx','_top')</Script>")
            '    Response.End()
            'End If
            If IsNumeric(Request.QueryString("c")) Then
                If Comm.ThemeConflict(Request.QueryString("c")) Then Exit Sub '====檢查有沒有進錯主題
            End If
        End If
    End Sub

    Protected Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If Comm.UserLogin(accBox.Text, pwBox.Text) Then
            Dim NewApId As String
            If IsNumeric(Request.QueryString("c")) Then
                NewApId = Comm.CreateNewApp("我的iApp", Request.QueryString("c"))
                '>>>這裡沒有複製圖片，之後參考capp來修改
                str = "Insert into User_Page (User_ID,Page_ID,User_App_ID,Sort,SessionID,Img01,Img02,Img03,h1,h2,Theme_ID,IsCopy) " & _
                      "Select @User_Id,Page_ID," & NewApId & ",Sort,SessionID,Img01,Img02,Img03,h1,h2,Theme_ID,1 from User_Page where User_App_ID=@Ref_App_ID"
                Main.NonQuery(str)
            Else

                NewApId = Comm.MyLastApp()
                'Response.Write(">>" & NewApId & ">>" & Comm.User_Name())
            End If
             

            Response.Write("<Script>window.open('Default.aspx?i=" & NewApId & "','_top')</Script>")
            Response.End()
        Else

            Response.Write("<script>alert('帳號或密碼錯誤')</script>")
        End If

 
    End Sub
End Class

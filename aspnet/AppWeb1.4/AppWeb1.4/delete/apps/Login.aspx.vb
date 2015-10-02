Public Class Login1
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNumeric(Session("IDNo")) Then

        End If
        CID.Value = Request.QueryString("c")


    End Sub

    'Protected Sub LoginBtn1_Click(sender As Object, e As ImageClickEventArgs) Handles LoginBtn1.Click

    'End Sub

    Protected Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
    
        Main.ParaClear()
        Main.ParaAdd("@Account", accBox.Text, System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@Pw", pwBox.Text, System.Data.SqlDbType.NVarChar)
        Dim sql As String = "Select * from Users where Account=@Account And Password=@Pw"
        Dim dr As DataTable = Main.GetDataSet(sql)
        If (dr.Rows.Count > 0) Then
            Session("IDNo") = dr.Rows(0).Item("IDNo")
            Session("User_Name") = dr.Rows(0).Item("User_Name")
            'comm.SaveCookie(Me, "ThisPC", Session("IDNo"))
            'Session("OK") = "OK"
            ' Response.Redirect("Default.aspx")

            If IsNumeric(Request.QueryString("c")) Then
                Response.Write("<Script>window.open('capp.aspx?i=" & Request.QueryString("c") & "','_self')</Script>")
            Else
                Response.Write("<Script>window.open('../../../portal/portal.aspx','_self')</Script>")
            End If
            Response.End()
        Else
            Response.Write("<script>alert('帳號密碼錯誤')</script>")
        End If
    End Sub
End Class

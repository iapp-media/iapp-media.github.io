Imports System.Data
Partial Class Login
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub LoginBtn1_Click(sender As Object, e As ImageClickEventArgs) Handles LoginBtn1.Click
        Main.ParaClear()
        Main.ParaAdd("@Account", accBox.Text, System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@Pw", pwBox.Text, System.Data.SqlDbType.NVarChar)
        Dim sql As String = "Select * from Users where Account=@Account And Password=@Pw"
        Dim dr As DataTable = Main.GetDataSet(sql)
        If (dr.Rows.Count > 0) Then
            Session("IDNo") = dr.Rows(0).Item("IDNo")
            Session("User_Name") = dr.Rows(0).Item("User_Name")
            Session("OK") = "OK"
            ' Response.Redirect("Default.aspx")
            Response.Write("<Script>window.open('Default.aspx')</Script>")
        Else

            Response.Write("<script>alert('帳號密碼錯誤')</script>")
        End If
    End Sub

End Class

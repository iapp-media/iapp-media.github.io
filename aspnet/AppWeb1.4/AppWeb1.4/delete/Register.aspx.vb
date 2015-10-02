Imports System.Data
Partial Class Register
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub regBtn1_Click(sender As Object, e As EventArgs) Handles regBtn1.Click
        Main.ParaClear()
        Main.ParaAdd("@Account", Email.Text, System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@Pw", Pw.Text, System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@User_Name", User_Name.Text, System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@User_Type", 1, System.Data.SqlDbType.Int)
        Dim sql As String = "Insert into Users(Account,Password,User_Name,User_Type) Values (@Account,@Pw,@User_Name,@User_Type)"
        If (Main.NonQuery(sql)) Then
            Response.Write("<script>alert('寫入成功');location.href='login.aspx'</script>")
        Else
            Response.Write("<script>alert('寫入失敗檢查欄位')</script>")
        End If
    End Sub

    
End Class

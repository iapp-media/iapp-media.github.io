
Partial Class Mana_Message_Detail
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("p")) Then
                L.Text = "select * from message where Product_ID = " & Request.QueryString("p") & " order by creat_Date DESC"
            End If
        End If

        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TB_Message.Text = "" Then Exit Sub

        str = "insert into message(store_ID,Product_ID,cont,leave_ID) values(" & Request.QueryString("s") & "," & Request.QueryString("p") & ",'" & TB_Message.Text & "','賣家')"

        If Main.NonQuery(str) Then
            TB_Message.Text = ""
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');</script>")
        Else
            ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>")
            Response.Write(str)
        End If
    End Sub
End Class

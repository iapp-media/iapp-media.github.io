
Partial Class MessageBoard
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim comm As New CommTool
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("p")) Then
                L.Text = "select * from Message where Product_ID =" & Request.QueryString("p") & " order by creat_Date desc"

                str = "select Product_Name from Product where idno =" & Request.QueryString("p") & ""
                Dim t As String = Main.Scalar(str)
                If t <> "" Then
                    LTitle.Text = t
                End If
            End If
        End If
        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TB_Message.Text = "" Then Exit Sub

        If Session("Store_ID") Then
            str = "insert into message(store_ID,Product_ID,cont,leave_ID) values(" & Request.QueryString("s") & "," & Request.QueryString("p") & ",'" & TB_Message.Text & "','" & Session("User_ID") & "')"

            If Main.NonQuery(str) Then
                ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入成功');</script>")
            Else
                ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('寫入失敗');</script>")
                Response.Write(str)
            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub BT_Back_Click(sender As Object, e As EventArgs) Handles BT_Back.Click
        Response.Redirect("product_Detail.aspx?p=" & Request.QueryString("p") & "")
    End Sub
End Class

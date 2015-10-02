
Partial Class Mana_Message_Mana
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If IsNumeric(Request.QueryString("s")) Then
                L.Text = "select * from message where Store_ID=" & Request.QueryString("s") & " and Leave_ID not in('賣家') order by Creat_Date desc"
            End If
        End If

        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub GV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GV.RowCommand
        Dim i As Integer = e.CommandArgument
        If e.CommandName = "CN" Then
            Response.Redirect("Message_Detail.aspx?s=" & Request.QueryString("s") & "&p=" & GV.DataKeys(i).Item(1) & "&m=" & GV.DataKeys(i).Item(0) & "")
        End If
    End Sub

    Protected Sub BT_S_Click(sender As Object, e As System.EventArgs) Handles BT_S.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            'L.Text = "select * from message where store_ID =" & Request.QueryString("s") & " order by creat_date desc"
        Else
            L.Text = "select * from message where store_ID =" & Request.QueryString("s") & ""
            If TextBox1.Text <> "" Then L.Text += " and Leave_ID= '" & TextBox1.Text & "'"
            If TextBox2.Text <> "" Then L.Text += " and Product_ID= '" & TextBox2.Text & "'"
            L.Text += " order by creat_Date Desc"
        End If

        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub BT_R_Click(sender As Object, e As System.EventArgs) Handles BT_R.Click
        L.Text = "select * from message where store_ID =" & Request.QueryString("s") & " order by creat_date desc"
        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub
End Class

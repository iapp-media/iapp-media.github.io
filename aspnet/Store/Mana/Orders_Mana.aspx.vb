
Partial Class Mana_Orders_Mana
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            If IsNumeric(Request.QueryString("s")) Then
                L.Text = "select * from orders where store_ID =" & Request.QueryString("s") & " order by Creat_Date DESC"
            End If
        End If
        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID
    End Sub

    Protected Sub BT_S_Click(sender As Object, e As System.EventArgs) Handles BT_S.Click

        If TextBox1.Text = "" And TextBox2.Text = "" And DropDownList1.SelectedValue = "" Then
            'L.Text = "select * from orders where store_ID =" & Request.QueryString("s") & " order by creat_Date Desc"
        Else
            L.Text = "select * from orders where store_ID =" & Request.QueryString("s") & ""
            If TextBox1.Text <> "" Then L.Text += " and Contact_ID= '" & TextBox1.Text & "'"
            If TextBox2.Text <> "" Then L.Text += " and Order_No= '" & TextBox2.Text & "'"
            'If TextBox3.Text <> "" Then L.Text += " and Contact_ID= '" & TextBox3.Text & "'"
            If DropDownList1.SelectedValue <> "" Then L.Text += " and status= '" & DropDownList1.SelectedValue & "'"
            L.Text += " order by creat_Date Desc"
        End If

        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID

        'Response.Write(L.Text)
    End Sub

    Protected Sub BT_R_Click(sender As Object, e As System.EventArgs) Handles BT_R.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        DropDownList1.SelectedIndex = 0

        L.Text = "select * from orders where store_ID =" & Request.QueryString("s") & ""
        SD.ConnectionString = Main.ConnStr
        SD.SelectCommand = L.Text
        GV.DataSourceID = SD.ID

    End Sub

    Protected Sub GV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GV.RowCommand
        Dim i As Integer = e.CommandArgument
        If e.CommandName = "CN" Then
            Response.Redirect("Order_Detail.aspx?s=" & Request.QueryString("s") & "&o=" & GV.DataKeys(i).Item(0))
        End If
    End Sub

    Protected Sub GV_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GV.RowDataBound
        If e.Row.RowIndex > -1 Then
            Select Case e.Row.Cells(2).Text
                Case "1"
                    e.Row.Cells(2).Text = "未付款"
                Case "2"
                    e.Row.Cells(2).Text = "未發貨"
                Case "3"
                    e.Row.Cells(2).Text = "已發貨"
                Case "4"
                    e.Row.Cells(2).Text = "交易完成"
                Case "5"
                    e.Row.Cells(2).Text = "交易取消"
            End Select
        End If
    End Sub
End Class

Imports System.Data
Imports System.Web.Configuration
Imports System.Web.UI
Imports System.Data.SqlClient
Imports System.IO


Partial Class Search_Sqltool
    Inherits System.Web.UI.Page
    Dim str As String
    Public ConnStr As String = System.Configuration.ConfigurationSettings.AppSettings.Get("Database")
    Public CMD As New SqlClient.SqlCommand
    Public ADP As New SqlClient.SqlDataAdapter


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            If Session("secu") <> "ok" Then
                Response.Redirect("secu.aspx")
            Else

                TT.Text = ConnStr

                TT.Visible = True
                TB.Visible = True
                Button1.Visible = True
                Button2.Visible = True
            End If

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TB.Text = "" Then Exit Sub
        Try
            L.Text = NonQuery(TB.Text)
        Catch ex As Exception
            L.Text = ex.Message
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TB.Text = "" Then Exit Sub
        Try
            SD.ConnectionString = TT.Text
            SD.SelectCommand = TB.Text
            GV.DataSourceID = SD.ID
        Catch ex As Exception
            L.Text = ex.Message
        End Try
    End Sub

    Public Function NonQuery(ByVal sqlstr As String) As Integer

        Dim CONN As SqlClient.SqlConnection = New SqlClient.SqlConnection(TT.Text)
        Dim CMD As New SqlClient.SqlCommand
        Dim ADP As New SqlClient.SqlDataAdapter
        Dim result As Integer = 0
        Try
            CONN.Open()
            CMD = New SqlClient.SqlCommand(sqlstr, CONN)
            result = CMD.ExecuteNonQuery()
            CONN.Close()
        Catch ex As Exception
            result = ex.Message
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function
   
End Class

Imports System.Web.Configuration
Imports System.Web.UI
Imports System.IO
Imports System.Data

Public Class DBTool
    Inherits System.Web.UI.Page
    Public ConnStr As String = System.Configuration.ConfigurationSettings.AppSettings.Get("Database")
    Public CONN As SqlClient.SqlConnection = New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("Database"))
    Public CMD As New SqlClient.SqlCommand
    Public ADP As New SqlClient.SqlDataAdapter 
     
    Public Function Scalar(ByVal sqlstr As String) As String
        Dim result As String = ""

        Try
            CONN.Open()
            CMD = New SqlClient.SqlCommand(sqlstr, CONN)
            result = CMD.ExecuteScalar()
            CONN.Close()
            'WriteLog(sqlstr)
        Catch ex As Exception
            result = ""
            'WriteLog("[Main.Scalar.Error]:" & ex.Message & sqlstr)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function

    Public Function NonQuery(ByVal sqlstr As String) As Integer
        Dim result As Integer = 0
        Try
            CONN.Open()
            CMD = New SqlClient.SqlCommand(sqlstr, CONN)
            result = CMD.ExecuteNonQuery()
            CONN.Close()
            'WriteLog(sqlstr)
        Catch ex As Exception
            result = 0
            'WriteLog("[Main.NonQuery.Error]:" & ex.Message & ":" & sqlstr)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function

    Public Function GetDataSet(ByVal sqlstr As String) As DataTable
        Dim DS As New DataTable
        Try
            ADP = New SqlClient.SqlDataAdapter(sqlstr, CONN)
            ADP.Fill(DS)
            'WriteLog(sqlstr)
        Catch ex As Exception
            'WriteLog(sqlstr & "[Main.GetDataSet.Error]:" & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return DS
    End Function

    Public Function GetDataSetNoNull(ByVal sqlstr As String) As DataTable
        Dim ComTool As New CommTool
        Dim DS As New DataTable
        Dim ADP As SqlClient.SqlDataAdapter

        Try
            ADP = New SqlClient.SqlDataAdapter(sqlstr, CONN)
            ADP.Fill(DS)
            'WriteLog(sqlstr)
        Catch ex As Exception
            'WriteLog(sqlstr & "[Main.GetDataSetNoNull.Error]:" & ex.Message)

        End Try

        Dim NewDT As New DataTable
        If DS.Rows.Count > 0 Then
            For Each DC As DataColumn In DS.Columns
                NewDT.Columns.Add(DC.ColumnName)
            Next
            For Each rw As DataRow In DS.Rows
                Dim Nrw As DataRow = NewDT.NewRow()
                For i As Integer = 0 To DS.Columns.Count - 1
                    If rw(i).GetType.ToString() = "System.DBNull" Then
                        Nrw(i) = ""
                    Else
                        Nrw(i) = rw(i)
                    End If
                Next
                NewDT.Rows.Add(Nrw)
            Next
        End If
        Return NewDT
    End Function

    Public Function PrepareSQL(ByVal sqlstr As String) As String
        Dim result As String = ""
        CONN.Open()
        CMD = New SqlClient.SqlCommand(sqlstr, CONN)
        Try
            CMD.Prepare()
        Catch ex As Exception
            result = ex.Message
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        CONN.Close()
        Return result
    End Function 

    Public Sub CleanInput(ByVal pAge As Web.UI.Page)
        For i As Integer = 0 To pAge.Controls.Count - 1
            For Each con As Web.UI.Control In pAge.Controls(i).Controls
                If con.ToString = "System.Web.UI.WebControls.TextBox" Then
                    CType(con, WebControls.TextBox).Text = CleanStr(CType(con, WebControls.TextBox).Text)
                End If
            Next
        Next
    End Sub

    Public Function CleanStr(ByVal InputString As String) As String
        Dim KW As String() = {"'", "--", "%", "&", "||"}
        For i As Integer = 0 To KW.Length - 1
            InputString = InputString.Replace(KW(i), "¡°")
        Next
        Return InputString
    End Function

    Function GoodRequest(ByVal page As Web.UI.Page, ByVal RequestName As String, ByVal DataType As String) As Boolean
        Dim KW As String() = {"'", """", "?", "%", "&", "||"}
        Dim tmp As Boolean = True
        If Not IsNothing(page.Request.QueryString(RequestName)) Then
            If page.Request.QueryString(RequestName) <> "" Then
                Select Case DataType
                    Case "Int"
                        Try
                            Dim cc As Integer = CInt(page.Request.QueryString(RequestName))
                            tmp = True
                        Catch ex As Exception
                            tmp = False
                        End Try
                    Case "String"

                        Dim ss As String = page.Request.QueryString(RequestName)
                        If ss.IndexOf("and") > -1 Then tmp = False
                End Select

            Else
                tmp = False
            End If
        Else
            tmp = False
        End If
        Return tmp
    End Function

    Public Sub WriteLog(ByVal Mess As String)
        Dim MP As String = System.Configuration.ConfigurationSettings.AppSettings.Get("LOGPath")
        If MP = "" Then MP = Server.MapPath("./") & "LOGPath\"

        MP = MP & "\" & Year(Today) & GetFullNum(Month(Today), 2) & "\"
        If System.IO.Directory.Exists(MP) = False Then
            System.IO.Directory.CreateDirectory(MP)
        End If

        Dim SW As StreamWriter = New StreamWriter(MP & strDate(Today) & ".log", True, System.Text.Encoding.Default)
        Dim str As String = ""
        Try
            str = "[" & Now & "-" & Session("User_Name") & "]:" + Mess
            SW.WriteLine(str)
            SW.Flush()
            SW.Close()

        Catch ex As Exception
            SW.Flush()
            SW.Close()
        Finally
            SW.Close()
        End Try
    End Sub

    Public Function strDate(ByVal dd As DateTime) As String
        Dim tmp As String = CStr(dd.Year - 1911)
        tmp += GetFullNum(dd.Month, 2)
        tmp += GetFullNum(dd.Day, 2)
        tmp += GetFullNum(dd.Hour, 2)
        Return tmp
    End Function

    Public Function GetFullNum(ByVal num As Integer, ByVal size As Integer) As String '¸É0
        Dim tmp As String = num.ToString()
        If size >= tmp.Length Then
            Do Until tmp.Length = size
                tmp = "0" & tmp
            Loop
        End If
        Return tmp
    End Function
End Class

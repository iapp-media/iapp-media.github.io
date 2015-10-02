Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO

Public Class JDB
    Inherits System.Web.UI.Page
    Public ConnStr As String = System.Configuration.ConfigurationSettings.AppSettings.Get("DataBase")
    Public CONN As SqlClient.SqlConnection = New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("DataBase"))
    Public CMD As New SqlClient.SqlCommand
    Public ADP As New SqlClient.SqlDataAdapter
    Public LogStat As Integer = 0

    Sub New(Optional ByVal ConnectionString As String = "")
        If ConnectionString <> "" Then
            CONN = New SqlClient.SqlConnection(ConnectionString)
        Else
            CONN = New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("DataBase"))
        End If
        If IsNumeric(System.Configuration.ConfigurationSettings.AppSettings.Get("LogStat")) Then
            LogStat = System.Configuration.ConfigurationSettings.AppSettings.Get("LogStat")
        End If
    End Sub

    Public Sub ParaClear()
        CMD = New SqlClient.SqlCommand
    End Sub

    Public Sub ParaAdd(ByVal ParameterName As String, ByVal Valu As Object, ByVal DaType As SqlDbType)
        Dim sp As New SqlClient.SqlParameter(ParameterName, DaType)
        ' sp.ParameterName = ParameterName
        sp.Value = Valu
        '  sp.DbType = DaType
        CMD.Parameters.Add(sp)
    End Sub

    Public Function NonQuery(ByVal sqlstr As String, Optional ByVal CloseConn As Boolean = True, Optional ByVal CmdType As Data.CommandType = CommandType.Text) As Integer
        Dim result As Integer = 0
        Try
            If CONN.State <> ConnectionState.Open Then CONN.Open()
            CMD.Connection = CONN
            CMD.CommandText = sqlstr
            CMD.CommandType = CmdType
            result = CMD.ExecuteNonQuery()
            If LogStat >= 1 Then WriteCMD()
            If CloseConn = True Then CONN.Close()
        Catch ex As Exception
            result = 0
            WriteLog("[" & Now & "-" & Session("User_Name") & "][Main.NonQuery.Error]:" & ex.Message & ":" & sqlstr)
            WriteCMD()
        Finally
            If CONN.State = ConnectionState.Open Then
                If CloseConn = True Then CONN.Close()
            End If
        End Try
        Return result
    End Function

    Public Function Scalar(ByVal sqlstr As String, Optional ByVal CmdType As Data.CommandType = CommandType.Text) As String
        Dim result As String = ""

        Try
            CONN.Open()
            CMD.Connection = CONN
            CMD.CommandText = sqlstr
            CMD.CommandType = CmdType
            result = CMD.ExecuteScalar()
            If LogStat >= 1 Then WriteCMD()
            CONN.Close()
        Catch ex As Exception
            result = ""
            WriteLog("[" & Now & "-" & Session("User_Name") & "][Main.Scalar.Error]:" & ex.Message & sqlstr)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function


    Public Function GetDataSet(ByVal sqlstr As String, Optional ByVal CmdType As Data.CommandType = CommandType.Text) As DataTable
        Dim DS As New DataTable
        Try
            CMD.Connection = CONN
            CMD.CommandText = sqlstr
            CMD.CommandType = CmdType
            ADP = New SqlClient.SqlDataAdapter(CMD)
            ADP.Fill(DS)
            If LogStat >= 2 Then WriteCMD()
        Catch ex As Exception
            WriteLog("[" & Now & "-" & Session("User_Name") & "][Main.GetDataSet.Error]:" & ex.Message)
            WriteCMD()
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return DS
    End Function

    Public Function GetDataSetNoNull(ByVal sqlstr As String) As DataTable
        Dim DS As DataTable = GetDataSet(sqlstr)
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

    Sub WriteCMD()
        WriteLog("[" & Now & "-" & Session("User_Name") & "]")
        For Each sp As SqlClient.SqlParameter In CMD.Parameters
            WriteLog("Declare " & sp.ParameterName & "  " & sp.SqlDbType.ToString.Replace("NVarChar", "nvarchar(500)").Replace("Int", "int") & " = '" & sp.Value & "'")
        Next
        WriteLog(CMD.CommandText)
    End Sub

    Public Overloads Function DelData(ByVal TableName As String, ByVal KeyColName As String, ByVal value As Integer) As Integer
        Dim result As Integer = 0
        Dim str As String = "Delete from " & TableName & " where " & KeyColName & " = @" & KeyColName
        Try
            CONN.Open()
            CMD.Connection = CONN
            CMD.CommandText = str
            ParaAdd("@" & KeyColName, value, SqlDbType.Int)
            result = CMD.ExecuteNonQuery()
            CONN.Close()
        Catch ex As Exception
            result = 0
            ' WriteLog("[Main.NonQuery.Error]:" & ex.Message & ":" & sqlstr)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function

    Public Overloads Function DelData(ByVal TableName As String, ByVal KeyColName As String, ByVal value As String) As Integer
        Dim result As Integer = 0
        Dim str As String = "Delete from " & TableName & " where " & KeyColName & " = @" & KeyColName
        Try
            CONN.Open()
            CMD.Connection = CONN
            CMD.CommandText = str
            ParaAdd("@" & KeyColName, value, SqlDbType.NVarChar)
            result = CMD.ExecuteNonQuery()
            CONN.Close()
        Catch ex As Exception
            result = 0
            ' WriteLog("[Main.NonQuery.Error]:" & ex.Message & ":" & sqlstr)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
        Return result
    End Function

    Public Function GetInsertString(ByVal TableName As String) As String
        '~~~~~~~~~尚未完成，也尚未測試
        Dim result As String = ""
        Dim str As String = "Select * from syscolumns where id=(Select id from sysobjects where name=@name ) and name<>'idno'"
        ParaAdd("@name", TableName, SqlDbType.NVarChar)
        Dim d As DataTable = GetDataSet(str)
        If d.Rows.Count > 0 Then
            Dim s As String = ""
            Dim s2 As String = ""
            For Each dw As DataRow In d.Rows
                s += "," & dw("name")
                s2 += ",@" & dw("name")
            Next
            result = "Insert into " & TableName & " (" & s.Substring(1) & ") values (" & s2.Substring(1) & ")"
        End If
        Return result
    End Function

    Public Function GetUpdateString(ByVal TableName As String, ByVal KeyColName As String) As String
        '~~~~~~~~~尚未完成，也尚未測試
        Dim result As String = ""
        Dim str As String = "Select * from syscolumns where id=(Select id from sysobjects where name=@name ) and name<>'idno'"
        ParaAdd("@name", TableName, SqlDbType.NVarChar)
        Dim d As DataTable = GetDataSet(str)
        If d.Rows.Count > 0 Then
            Dim s As String = ""
            For Each dw As DataRow In d.Rows
                s += "," & dw("name") & "=@" & dw("name")
            Next
            result = "Update " & TableName & " Set " & s.Substring(1) & " where " & KeyColName & " = @" & KeyColName
        End If
        Return result
    End Function

    Public Sub WriteLog(ByVal Mess As String)
        Dim MP As String = System.Configuration.ConfigurationSettings.AppSettings.Get("LOGPath")
        If MP = "" Then MP = Server.MapPath("~/") & "\LOGPath\"

        MP = MP & "\" & Year(Today) & GetFullNum(Month(Today), 2) & "\"
        If System.IO.Directory.Exists(MP) = False Then
            System.IO.Directory.CreateDirectory(MP)
        End If

        Dim SW As StreamWriter = New StreamWriter(MP & strDate(Today) & ".log", True, System.Text.Encoding.Default)
        Dim str As String = ""
        Try
            str = Mess
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
        'tmp += GetFullNum(dd.Hour, 2)
        Return tmp
    End Function

    Public Function GetFullNum(ByVal num As Integer, ByVal size As Integer) As String '補0
        Dim tmp As String = num.ToString()
        If size >= tmp.Length Then
            Do Until tmp.Length = size
                tmp = "0" & tmp
            Loop
        End If
        Return tmp
    End Function

End Class

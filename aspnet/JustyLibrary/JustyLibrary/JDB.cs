using System;
using System.Collections.Generic; 
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Configuration;

public class JDB : System.Web.UI.Page
{
    public string ConnStr = System.Configuration.ConfigurationManager.AppSettings.Get("Database");
    public System.Data.SqlClient.SqlConnection CONN = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("Database"));
    public System.Data.SqlClient.SqlCommand CMD = new System.Data.SqlClient.SqlCommand();
    public System.Data.SqlClient.SqlDataAdapter ADP = new System.Data.SqlClient.SqlDataAdapter();
    public int LogStat = 0;

    public JDB()
    {
        CONN = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DataBase"));

        if (IsNumeric(System.Configuration.ConfigurationManager.AppSettings.Get("LogStat")))
        {
            LogStat = Cint2(System.Configuration.ConfigurationManager.AppSettings.Get("LogStat"));//
        }

    }

    public JDB(string ConnectionString)
    {
        if (ConnectionString != "")
        {
            CONN = new SqlConnection(ConnectionString);
        }
        else
        {
            CONN = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DataBase"));
        }

        if (IsNumeric(System.Configuration.ConfigurationManager.AppSettings.Get("LogStat")))
        {
            LogStat = Cint2(System.Configuration.ConfigurationManager.AppSettings.Get("LogStat"));
        }

    }

    public void ParaClear()
    {
        CMD = new SqlCommand();
    }

    public void ParaAdd(string ParameterName, object Valu, SqlDbType DaType)
    {
        SqlParameter sp = new SqlParameter(ParameterName, DaType);
        sp.Value = Valu;
        CMD.Parameters.Add(sp);
    }
    public void ParaAdd(string ParameterName, object Valu, SqlDbType DaType, int DataSize)
    {
        SqlParameter sp = new SqlParameter(ParameterName, DaType, DataSize);
        sp.Value = Valu;
        CMD.Parameters.Add(sp);
    }


    public int NonQuery(string sqlstr)
    {
        int result = 0;
        if (CONN.State != ConnectionState.Open) { CONN.Open(); }
        CMD.Connection = CONN;
        CMD.CommandText = sqlstr;
        CMD.CommandType = CommandType.Text;
        SqlTransaction trans = CONN.BeginTransaction();
        CMD.Transaction = trans;

        try
        {
            result = CMD.ExecuteNonQuery();
            trans.Commit();
            if (LogStat >= 1) { WriteCMD(); }
            CONN.Close();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            result = 0;
            WriteCMD();
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.NonQuery.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            } 
            trans.Dispose(); 
        }
        return result;
    }


    public int NonQuery(string sqlstr, CommandType CmdType)
    {
        int result = 0;
        try
        {
            if (CONN.State != ConnectionState.Open) { CONN.Open(); }
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CmdType;
            result = CMD.ExecuteNonQuery();
            if (LogStat >= 1) { WriteCMD(); }
            CONN.Close();
        }
        catch (Exception ex)
        {
            result = 0;
            WriteCMD();
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.NonQuery.ErrorRGRGRG]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return result;
    }

    public int NonQuery(string sqlstr, CommandType CmdType, bool CloseConn)
    {
        int result = 0;
        try
        {
            if (CONN.State != ConnectionState.Open) { CONN.Open(); }
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CmdType;
            result = CMD.ExecuteNonQuery();
            if (LogStat >= 1) { WriteCMD(); }
            if (CloseConn == true) { CONN.Close(); }
        }
        catch (Exception ex)
        {
            result = 0;
            WriteCMD();
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.Scalar.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return result;
    }


    public DataTable GetDataSet(string sqlstr)
    {
        DataTable DS = new DataTable();
        try
        {

            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CommandType.Text;
            ADP = new SqlDataAdapter(CMD);
            ADP.Fill(DS);
        }
        catch (Exception ex)
        {
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.GetDataSet.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return DS;
    }

    public DataTable GetDataSet(string sqlstr, CommandType CmdType)
    {
        DataTable DS = new DataTable();
        try
        {
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CmdType;
            ADP = new SqlDataAdapter(CMD);
            ADP.Fill(DS);
        }
        catch (Exception ex)
        {
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.GetDataSet.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return DS;
    }

    public DataTable GetDataSetNoNull(string sqlstr)
    {
        DataTable DS = GetDataSet(sqlstr);
        DataTable NewDT = new DataTable();
        if (DS.Rows.Count > 0)
        {
            foreach (DataColumn DC in DS.Columns)
            {
                NewDT.Columns.Add(DC.ColumnName);
            }
            foreach (DataRow rw in DS.Rows)
            {
                DataRow Nrw = NewDT.NewRow();
                for (int i = 0; i <= DS.Columns.Count - 1; i++)
                {
                    if (rw[i].GetType().ToString() == "System.DBNull")
                    {
                        Nrw[i] = "";
                    }
                    else
                    {
                        Nrw[i] = rw[i];
                    }
                }
                NewDT.Rows.Add(Nrw);
            }
        }
        return NewDT;
        return GetDataSet(sqlstr);
    }

    public DataTable GetDataSetNoNull(string sqlstr, CommandType CmdType)
    {
        DataTable DS = GetDataSet(sqlstr, CmdType);
        DataTable NewDT = new DataTable();
        if (DS.Rows.Count > 0)
        {
            foreach (DataColumn DC in DS.Columns)
            {
                NewDT.Columns.Add(DC.ColumnName);
            }
            foreach (DataRow rw in DS.Rows)
            {
                DataRow Nrw = NewDT.NewRow();
                for (int i = 0; i <= DS.Columns.Count - 1; i++)
                {
                    if (rw[i].GetType().ToString() == "System.DBNull")
                    {
                        Nrw[i] = "";
                    }
                    else
                    {
                        Nrw[i] = rw[i];
                    }
                }
                NewDT.Rows.Add(Nrw);
            }
        }
        return NewDT;
        //return GetDataSet(sqlstr);
    }

    public string Scalar(string sqlstr)
    {
        string result = "";
        try
        {
            if (CONN.State != ConnectionState.Open) { CONN.Open(); }
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CommandType.Text;
            result = CMD.ExecuteScalar().ToString();
            //if (LogStat >= 1) { WriteCMD(); }
            CONN.Close();
        }
        catch (Exception ex)
        {
            result = "";
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.Scalar.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return result;
    }

    public string Scalar(string sqlstr, CommandType CmdType)
    {
        string result = "";

        try
        {
            if (CONN.State != ConnectionState.Open) { CONN.Open(); }
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CmdType;
            result = CMD.ExecuteScalar().ToString();
            //if (LogStat >= 1) { WriteCMD(); }
            CONN.Close();
        }
        catch (Exception ex)
        {
            result = "";
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.Scalar.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return result;
    }

    public string Scalar(string sqlstr, CommandType CmdType, bool CloseConn)
    {
        string result = "";
        try
        {
            if (CONN.State != ConnectionState.Open) { CONN.Open(); }
            CMD.Connection = CONN;
            CMD.CommandText = sqlstr;
            CMD.CommandType = CmdType;
            result = CMD.ExecuteScalar().ToString();
            if (LogStat >= 1) { WriteCMD(); }
            if (CloseConn == true) { CONN.Close(); }
        }
        catch (Exception ex)
        {
            result = "";
            WriteLog("[" + DateTime.Now.ToLongTimeString() + "][Main.Scalar.Error]:" + ex.Message + sqlstr);
        }
        finally
        {
            if (CONN.State == ConnectionState.Open)
            {
                CONN.Close();
            }
        }
        return result;
    }

    public string GetInsertString(string TableName)
    {
        string result = "";
        string str = "Select * from syscolumns where id=(Select id from sysobjects where name=@name ) and name<>'idno'";
        ParaAdd("@name", TableName, SqlDbType.NVarChar);
        DataTable d = GetDataSet(str);
        if (d.Rows.Count > 0)
        {
            string s = "";
            string s2 = "";
            for (int i = 0; i < d.Rows.Count; i++)
            {
                s += "," + d.Rows[i]["name"];
                s2 += ",@" + d.Rows[i]["name"];
            }
            result = "Insert into " + TableName + " (" + s.Substring(1) + ") values (" + s2.Substring(1) + ")";

        }
        return result;
    }

    public string GetUpdateString(string TableName, string KeyColName)
    {
        string result = "";
        string str = "Select * from syscolumns where id=(Select id from sysobjects where name=@name ) and name<>'idno'";
        ParaAdd("@name", TableName, SqlDbType.NVarChar);
        DataTable d = GetDataSet(str);
        if (d.Rows.Count > 0)
        {
            string s = "";
            for (int i = 0; i < d.Rows.Count; i++)
            {
                s += "," + d.Rows[i]["name"] + "=@" + d.Rows[i]["name"];
            }
            result = "Update " + TableName + " Set " + s.Substring(1) + " where " + KeyColName + " = @" + KeyColName;

        }
        return result;
    }


    public string strDate(DateTime dd)
    {
        string tmp = Convert.ToString(dd.Year - 1911);
        tmp += GetFullNum(dd.Month, 2);
        tmp += GetFullNum(dd.Day, 2);
        //tmp += GetFullNum(dd.Hour, 2)
        return tmp;
    }

    public void WriteCMD()
    {
        WriteLog("[" + DateTime.Now.ToLongTimeString() + "]");
        if (CMD.Parameters.Count > 0)
        {
            for (int i = 0; i < CMD.Parameters.Count; i++)
            {
                WriteLog("Declare " + CMD.Parameters[i].ParameterName.ToString() + "  " + CMD.Parameters[i].SqlDbType.ToString().Replace("NVarChar", "nvarchar(500)").Replace("Int", "int") + " = '" + CMD.Parameters[i].Value.ToString() + "'");
            }
            WriteLog(CMD.CommandText);
        }
    }

    public void WriteLog(string Mess)
    {
        string MP = System.Configuration.ConfigurationManager.AppSettings.Get("LOGPath");
        if (string.IsNullOrEmpty(MP))
            MP = Server.MapPath("~/") + "LOGPath\\";

        MP = MP + "\\" + DateTime.Now.Year.ToString() + GetFullNum(DateTime.Now.Month, 2) + "\\";
        if (System.IO.Directory.Exists(MP) == false)
        {
            System.IO.Directory.CreateDirectory(MP);
        }

        StreamWriter SW = new StreamWriter(MP + strDate(DateTime.Today) + ".log", true, System.Text.Encoding.Default);
        string str = "";
        try
        {
            str = Mess;
            SW.WriteLine(str);
            SW.Flush();
            SW.Close();

        }
        catch (Exception ex)
        {
            SW.Flush();
            SW.Close();
        }
        finally
        {
            SW.Close();
        }
    }

    public string GetFullNum(int num, int size)
    {
        //補0
        string tmp = num.ToString();
        if (size >= tmp.Length)
        {
            while (!(tmp.Length == size))
            {
                tmp = "0" + tmp;
            }
        }
        return tmp;
    }

    public bool IsNumeric(object Expression)
    {
        bool isNum;
        double retNum;
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    public bool IsDate(string sdate)
    {
        DateTime dt;
        bool isDate = true;

        try
        {
            dt = DateTime.Parse(sdate);
        }
        catch
        {
            isDate = false;
        }
        return isDate;
    }

    public int Cint2(object s)
    {
        int tmp = 0;
        try
        {
            if (s != null)
            {
                tmp = Convert.ToInt32(s);
            }
        }
        catch { }
        finally
        {
        }

        return tmp;
    }


    public bool FillDDP(DropDownList DDP, string strsql, string Text, string Value)
    {
        DDP.Items.Clear();
        DDP.Items.Add("");
        //即使沒有也將空白加入(防止-1)
        DataTable DT = GetDataSet(strsql);
        if (DT.Rows.Count > 0)
        {
            if (Text != null)
            {
                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    ListItem TT = new ListItem();
                    TT.Text = HttpUtility.JavaScriptStringEncode(DT.Rows[i][Text].ToString().Trim());
                    TT.Value = HttpUtility.JavaScriptStringEncode(DT.Rows[i][Value].ToString().Trim());
                    DDP.Items.Add(TT);
                }
            }
        }
        return true;
    }

    public bool FillDDP(ListBox DDP, string strsql, string Text, string Value)
    {
        DDP.Items.Clear();
        DataTable DT = GetDataSet(strsql);
        DDP.Items.Clear();
        if (DT.Rows.Count > 0)
        {
            if (Text != null)
            {
                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    ListItem TT = new ListItem();
                    TT.Text = HttpUtility.JavaScriptStringEncode(ClearHTML(DT.Rows[i][Text].ToString()));
                    TT.Value = HttpUtility.JavaScriptStringEncode(DT.Rows[i][Value].ToString());
                    DDP.Items.Add(TT);
                }
            }
        }
        return true;
    }

    public bool FillDDP(RadioButtonList DDP, string strsql, string Text, string Value)
    {
        DDP.Items.Clear();
        DataTable DT = GetDataSet(strsql);
        DDP.Items.Clear();
        if (DT.Rows.Count > 0)
        {
            if (Text != null)
            {
                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    ListItem TT = new ListItem();
                    TT.Text = HttpUtility.JavaScriptStringEncode(ClearHTML(DT.Rows[i][Text].ToString()));
                    TT.Value = HttpUtility.JavaScriptStringEncode(DT.Rows[i][Value].ToString());
                    DDP.Items.Add(TT);
                }
            }
        }
        return true;
    }

    public bool FillDDP(CheckBoxList DDP, string strsql, string Text, string Value)
    {
        DDP.Items.Clear();
        DataTable DT = GetDataSet(strsql);
        DDP.Items.Clear();
        if (Text != null)
        {
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    ListItem TT = new ListItem();
                    TT.Text = HttpUtility.JavaScriptStringEncode(ClearHTML(DT.Rows[i][Text].ToString()));
                    TT.Value = HttpUtility.JavaScriptStringEncode(DT.Rows[i][Value].ToString());
                    DDP.Items.Add(TT);
                }
            }
        }
        return true;
    }
    public string ClearHTML(string inStr)
    {
        while (inStr.IndexOf("[") > 0)
        {
            inStr = inStr.Substring(0, inStr.IndexOf("[")) + inStr.Substring(inStr.IndexOf("]") + 1);
        }
        return inStr;
    }


}
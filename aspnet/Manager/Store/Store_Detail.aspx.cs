using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class Store_Store_Detail : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    CommTool Comm = new CommTool();
    string str = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["entry"] == null) { Response.Redirect("Store_Mana.aspx"); }
            Main.FillDDP(DL_Cate, "Select IDNo,Cate_Name from Product_Cate where Store_ID=0 and Ref=-1", "Cate_Name", "IDNo");
            Main.FillDDP(DL_Lv, "select Status,Memo from def_Status where Col_Name='lv' ", "Memo", "Status");
            Main.FillDDP(DL_View, "select Status,Memo from def_Status where Col_Name='layout' ", "Memo", "Status");
            BT_info.Attributes.Add("onclick", "if(confirm('確定要修改嗎？')){return true;}else{return false;}");
            BT_save.Attributes.Add("onclick", "if(confirm('確定要修改費率嗎？')){return true;}else{return false;}");
            DataIN();
        }
    }
    void DataIN()
    {
        Main.ParaClear();
        Main.ParaAdd("@IDNo", Main.Cint2(Request.QueryString["entry"]), SqlDbType.Int);
        str = "select *,isnull(layout,'0') layoutID from store_info where IDNo=@IDNo";
        DataTable DT = Main.GetDataSetNoNull(str);
        if (DT.Rows.Count > 0)
        {
            DataRow Rw = DT.Rows[0];
            TB_Name.Text = Rw["Store_Name"].ToString();
            Comm.GetDDL(DL_Cate, Rw["Store_Cate"].ToString());
            Comm.GetDDL(DL_View, Rw["layout"].ToString());
            Comm.GetDDL(DL_Lv, Rw["Lv"].ToString());
            L_scate_id.Text = Rw["Store_Cate"].ToString();
            L_view_id.Text = Rw["layoutID"].ToString();
            L_lv_id.Text = Rw["Lv"].ToString();
            DataTable sDT = new DataTable();
            if (Rw["Delivery"].ToString() != "")
            {
                sDT = Main.GetDataSetNoNull("select Memo from def_Status where  Col_Name='Payment' and Status in ('" + Rw["Delivery"].ToString().Substring(1).Replace(",", "','") + "')");
                if (sDT.Rows.Count > 0)
                {
                    for (int i = 0; i < sDT.Rows.Count; i++)
                    {
                        TB_Delivery.Text += "、" + sDT.Rows[i]["Memo"].ToString();
                    }
                    TB_Delivery.Text = TB_Delivery.Text.Substring(1);
                }
            }
            if (Rw["Payment"].ToString() != "")
            {
                sDT = Main.GetDataSetNoNull("select Memo from def_Status where  Col_Name='Payment' and Status in ('" + Rw["Payment"].ToString().Substring(1).Replace(",", "','") + "')");
                if (sDT.Rows.Count > 0)
                {
                    for (int i = 0; i < sDT.Rows.Count; i++)
                    {
                        TB_Payment.Text += "、" + sDT.Rows[i]["Memo"].ToString();
                    }
                    TB_Payment.Text = TB_Payment.Text.Substring(1);
                }
            }
            TB_Bank_Name.Text = Rw["Bank_Name"].ToString();
            TB_Bank_No.Text = Rw["Bank_No"].ToString();
            TB_Bank_ACC.Text = Rw["Bank_ACC"].ToString();
            TB_Bank_ACName.Text = Rw["Bank_ACName"].ToString();
            TB_TEL.Text = Rw["TEL"].ToString();
            TB_Addr.Text = Rw["Addr"].ToString();
            TB_CEOName.Text = Rw["CEOName"].ToString();
            L_Fee.Text = Rw["Fee"].ToString();
            TB_Fee.Text = Rw["Fee"].ToString();
            StringBuilder SB = new StringBuilder();
            sDT = Main.GetDataSetNoNull("select top 2 *,CONVERT(varchar(12), Creat_Date, 111) Cdate,(select COUNT(1) from Store_info_Record where Sinfo_ID=@IDNo and Action='info' ) as CC from Store_info_Record where Action='info' and Sinfo_ID=@IDNo order by Creat_Date desc");
            if (sDT.Rows.Count > 0)
            {
                for (int i = 0; i < sDT.Rows.Count; i++)
                {
                    str = "";
                    SB.Append("<li>");
                    SB.Append("      <div class=\"message-block\">");
                    SB.Append("         <div>");
                    SB.Append("             <span class=\"username\">" + sDT.Rows[i]["Creat_UName"].ToString() + "-</span> <span class=\"message-datetime\">" + sDT.Rows[i]["Cdate"].ToString() + " updated</span>");
                    SB.Append("         </div>");
                    if (sDT.Rows[i]["ref_store_cate_id"].ToString() != sDT.Rows[i]["store_cate_id"].ToString())
                    {
                        str += "商店類別:" + Main.Scalar("select Cate_Name from Product_Cate where IDNo=" + sDT.Rows[i]["ref_store_cate_id"].ToString() + "") + "→" + Main.Scalar("select Cate_Name from Product_Cate where IDNo=" + sDT.Rows[i]["store_cate_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    if (sDT.Rows[i]["ref_layout_id"].ToString() != sDT.Rows[i]["layout_id"].ToString())
                    {
                        str += "選購情境:" + Main.Scalar("select Memo from def_Status where Col_Name='layout' and Status=" + sDT.Rows[i]["ref_layout_id"].ToString() + "") + "→" + Main.Scalar("select Memo from def_Status where Col_Name='layout' and Status=" + sDT.Rows[i]["layout_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    if (sDT.Rows[i]["ref_lv_id"].ToString() != sDT.Rows[i]["lv_id"].ToString())
                    {
                        str += "會員等級:" + Main.Scalar("select Memo from def_Status where Col_Name='lv' and Status=" + sDT.Rows[i]["ref_lv_id"].ToString() + "") + "→" + Main.Scalar("select Memo from def_Status where Col_Name='lv' and Status=" + sDT.Rows[i]["lv_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    SB.Append("         <div class=\"message\">" + str + "</div>");
                    SB.Append("      </div>");
                    SB.Append("</li>");

                    if (i == sDT.Rows.Count - 1 && Main.Cint2(sDT.Rows[i]["CC"].ToString()) > 2)
                    {

                        SB.Append("     <li class=\"text-center load-more\">");
                        SB.Append("<a href=\"javascript:void(0)\" data-toggle=\"modal\" data-target=\"#modalInfo\">");
                        SB.Append("     <i class=\"fa fa-refresh\"></i>load more..");
                        SB.Append("</a>");
                        SB.Append("     </li>");

                    }
                }
                L_info_Record.Text = SB.ToString();
            }
            SB.Clear();
            sDT = Main.GetDataSetNoNull("select  *,CONVERT(varchar(12), Creat_Date, 111) Cdate from Store_info_Record where Action='info' and Sinfo_ID=@IDNo order by Creat_Date desc");
            if (sDT.Rows.Count > 0)
            {
                for (int i = 0; i < sDT.Rows.Count; i++)
                {
                    str = "";
                    SB.Append("<li>");
                    SB.Append("      <div class=\"message-block\">");
                    SB.Append("         <div>");
                    SB.Append("             <span class=\"username\">" + sDT.Rows[i]["Creat_UName"].ToString() + "-</span> <span class=\"message-datetime\">" + sDT.Rows[i]["Cdate"].ToString() + " updated</span>");
                    SB.Append("         </div>");
                    if (sDT.Rows[i]["ref_store_cate_id"].ToString() != sDT.Rows[i]["store_cate_id"].ToString())
                    {
                        str += "商店類別:" + Main.Scalar("select Cate_Name from Product_Cate where IDNo=" + sDT.Rows[i]["ref_store_cate_id"].ToString() + "") + "→" + Main.Scalar("select Cate_Name from Product_Cate where IDNo=" + sDT.Rows[i]["store_cate_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    if (sDT.Rows[i]["ref_layout_id"].ToString() != sDT.Rows[i]["layout_id"].ToString())
                    {
                        str += "選購情境:" + Main.Scalar("select Memo from def_Status where Col_Name='layout' and Status=" + sDT.Rows[i]["ref_layout_id"].ToString() + "") + "→" + Main.Scalar("select Memo from def_Status where Col_Name='layout' and Status=" + sDT.Rows[i]["layout_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    if (sDT.Rows[i]["ref_lv_id"].ToString() != sDT.Rows[i]["lv_id"].ToString())
                    {
                        str += "會員等級:" + Main.Scalar("select Memo from def_Status where Col_Name='lv' and Status=" + sDT.Rows[i]["ref_lv_id"].ToString() + "") + "→" + Main.Scalar("select Memo from def_Status where Col_Name='lv' and Status=" + sDT.Rows[i]["lv_id"].ToString() + "") + ".&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                    SB.Append("         <div class=\"message\">" + str + "</div>");
                    SB.Append("      </div>");
                    SB.Append("</li>");
                }
                L_info_ALL.Text = SB.ToString();
            }


            SB.Clear();
            sDT = Main.GetDataSetNoNull("select Memo,ref_fee, fee,CONVERT(varchar(12), Creat_Date, 111) Cdate,Creat_UName from Store_info_Record where Action='Fee' and Sinfo_ID=@IDNo order by Creat_Date desc");
            if (sDT.Rows.Count > 0)
            {
                for (int i = 0; i < sDT.Rows.Count; i++)
                { 
                    SB.Append("<li>");
                    SB.Append("      <div class=\"message-block\">");
                    SB.Append("         <div>");
                    SB.Append("             <span class=\"username\">" + sDT.Rows[i]["Creat_UName"].ToString() + "-</span> <span class=\"message-datetime\">" + sDT.Rows[i]["Cdate"].ToString() + " updated</span>");
                    SB.Append("         </div>");
                    if (sDT.Rows[i]["ref_fee"].ToString() != sDT.Rows[i]["fee"].ToString())
                    {
                        str = "處理費率:" + sDT.Rows[i]["ref_fee"].ToString() + "% →" + sDT.Rows[i]["fee"].ToString() + "%. <br/>" +
                            "備註:" + sDT.Rows[i]["Memo"].ToString() + "";
                    }
                    SB.Append("         <div class=\"message\">" + str + "</div>");
                    SB.Append("      </div>");
                    SB.Append("</li>");
                }
                L_Fee_Record.Text = SB.ToString();
            } 

        }
    }
    protected void BT_info_Click(object sender, EventArgs e)
    {

        Main.ParaClear();
        str = ""; 
        string str2="";
        if (DL_Cate.SelectedValue.ToString() == "")
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('請選擇商店類別');", true);
            return;
        }
        if (DL_Lv.SelectedValue.ToString() != L_lv_id.Text)
        { 
            Main.ParaAdd("@ref_lv_id", Main.Cint2(L_lv_id.Text), SqlDbType.Int);
            Main.ParaAdd("@lv_id", Main.Cint2(DL_Lv.SelectedValue.ToString()), SqlDbType.Int);   
            str += " ,ref_lv_id=@ref_lv_id ,lv_id=@lv_id ";
            str2+= " ,lv=@lv_id";
        }
        if (DL_Cate.SelectedValue.ToString() != L_scate_id.Text)
        {
            Main.ParaAdd("@ref_store_cate_id", Main.Cint2(L_scate_id.Text), SqlDbType.Int);
            Main.ParaAdd("@store_cate_id", Main.Cint2(DL_Cate.SelectedValue.ToString()), SqlDbType.Int);
            str += " ,ref_store_cate_id=@ref_store_cate_id ,store_cate_id=@store_cate_id ";
               str2+= " ,store_cate=@store_cate_id";
        }
        if (DL_View.SelectedValue.ToString() != L_view_id.Text)
        { 
            Main.ParaAdd("@ref_layout_id", Main.Cint2(L_view_id.Text), SqlDbType.Int);
            Main.ParaAdd("@layout_id", Main.Cint2(DL_View.SelectedValue.ToString()), SqlDbType.Int);
            str += " ,ref_layout_id=@ref_layout_id ,layout_id=@layout_id ";
             str2+= " ,layout=@layout_id";
        }
        if (str != "" && str2!="")
        {
            Main.ParaAdd("@Action", "-1", SqlDbType.NVarChar);
            Main.ParaAdd("@Sinfo_ID", Main.Cint2(Request.QueryString["entry"].ToString()), SqlDbType.Int);
            Main.NonQuery("insert into Store_info_Record(Action, Sinfo_ID, Creat_Date, Creat_UName) values" +
                "( @Action, @Sinfo_ID, getdate(), 'Admin')");
            Main.NonQuery("update Store_info_Record set Action='Info' " + str + " where Action='-1' and Sinfo_ID=@Sinfo_ID ");

            Main.NonQuery("update store_info set ckStep=ckStep " + str2 + " where idno=@Sinfo_ID");
        }

        DataIN();

    }
    protected void BT_save_Click(object sender, EventArgs e)
    {
        if (Main.Cint2(TB_Fee.Text) > 0)
        {
            Main.ParaClear();
            Main.ParaAdd("@Fee", Main.Cint2(TB_Fee.Text), SqlDbType.Int);
            Main.ParaAdd("@ref_fee", Main.Cint2(L_Fee.Text), SqlDbType.Int);
            Main.ParaAdd("@SinfoID",Main.Cint2(Request.QueryString["entry"].ToString()),SqlDbType.Int);
            Main.ParaAdd("@Memo", TB_Memo.Text, SqlDbType.NVarChar);

            Main.NonQuery("update store_info set Fee=@Fee where idno=@SinfoID ");
            Main.NonQuery("insert into Store_info_Record(Action, Sinfo_ID, Creat_Date, Creat_UName, ref_fee, fee,Memo) values" +
               "( 'Fee', @SinfoID, getdate(), 'Admin',@ref_fee,@Fee,@Memo)");
            DataIN();
        }
        else {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String", "alert('費率格式有誤');", true);
            return;
        }
    }
    protected void BTFile_Click(object sender, EventArgs e)
    {
        if (FU.HasFile)
        {
            string FileName = FU.FileName.Replace(",", "");
            string TimeString = Comm.GetDateString(DateTime.Now);
            string FilePath = Path.Combine(Comm.FilePath, TimeString + Path.GetExtension(FU.FileName));

            if (File.Exists(FilePath))
            {
                int x = 1;
                do
                {
                    FilePath = Path.Combine(Comm.FilePath, TimeString + "-" + x.ToString() + Path.GetExtension(FU.FileName));
                    x++;
                } while (File.Exists(FilePath));
            }

            FU.SaveAs(FilePath);
           // Main.NonQuery("");
            ListItem Li = new ListItem();
            Li.Text = "<a href=\"../GetFile.aspx?file=" + FilePath + "\" target=\"_blank\">" + FileName + "</a>";
            Li.Value = FilePath + "," + FileName;
            Filelist.Items.Add(Li);
          
        }
    }
}
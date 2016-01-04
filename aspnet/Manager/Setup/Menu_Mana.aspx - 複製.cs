using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Setup_Menu_Mana : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
    string str = "";
    StringBuilder SB = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTreeView("-1", "0");
            Lmenu.Text = SB.ToString();
        }
    }
     
    public void GONon()
    {
        int aa = Main.NonQuery(str);
        if (aa > 0)
        {
            Response.Redirect("Menu_Mana.aspx");
        }
        else
        {
            Response.Write(str);
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "KeyName", "alert('儲存時發生錯誤，請與系統管理者確認。');", true);
        }
    }
    void GetTreeView(string refID, string uid)
    {
        str = "Select Title,IDNo,Ref from Menu where Ref=" + refID + " and isnull(Form,'')<>'KM'  order by Sort ";
        //  StringBuilder SB = new StringBuilder();
        DataTable DT = Main.GetDataSetNoNull(str);
        if (DT.Rows.Count > 0)
        {
            int a = DT.Rows.Count - 1;
            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                if (refID != "-1")
                {
                    if (i == 0)
                    {
                        SB.Append("<ul>");
                    }
                    SB.Append("<li><a href=\"#\" onclick=\"setUid('" + DT.Rows[i]["IDNo"] + "');setRef('" + DT.Rows[i]["Ref"] + "');\"> " + DT.Rows[i]["Title"] + " </a>");
                    if (Main.Scalar("select count(1) from Menu where Ref=" + DT.Rows[i]["IDNo"] + "") != "0")
                    {
                        GetTreeView(DT.Rows[i]["IDNo"].ToString(), "0");
                    }
                    else
                    {
                        SB.Append("<ul>");
                        SB.Append(" <li><a href=\"#\" onclick=\"setUid('0');setRef('" + DT.Rows[i]["IDNo"] + "');\">新增選單</a> </li>");
                        SB.Append(" </ul>");
                    }
                    SB.Append("  </li> ");
                    if (i == a)
                    {
                        SB.Append(" <li><a href=\"#\" onclick=\"setUid('0');setRef('" + DT.Rows[i]["Ref"] + "');\"> 新增選單</a> </li>");
                        SB.Append(" </ul>");
                    }
                }
                else
                {
                    SB.Append(" <li><a href=\"#\" onclick=\"setUid('" + DT.Rows[i]["IDNo"] + "');setRef('" + DT.Rows[i]["Ref"] + "');\"> " + DT.Rows[i]["Title"] + "</a> ");
                    GetTreeView(DT.Rows[i]["IDNo"].ToString(), "0");
                    SB.Append("  </li>");
                    if (i == a)
                    {
                        SB.Append(" <li><a href=\"#\" onclick=\"setUid('0');setRef('" + DT.Rows[i]["Ref"] + "');\"> 新增選單</a> </li>");
                    }
                }
            }
        }
        else
        {
            SB.Append("<ul> <li><a href=\"#\" onclick=\"setUid('0');setRef('" + refID + "');\"> 新增選單 </a></li></ul>");
        }

    }
    protected void BDel_Click(object sender, EventArgs e)
    { 
        str = "delete from Menu where IDNo=" + Uid.Text;
        GONon();
    }
    protected void BEdit_Click(object sender, EventArgs e)
    {
        string tmp = "";
        if (TName.Text=="")
            tmp += "，請輸入選單名稱";
        if (string.IsNullOrEmpty(TPath.Text))
            tmp += "，請輸入路徑";
        if (Main.IsNumeric(TSort.Text) == false)
            tmp += "，排序請輸入數字";
        if (!string.IsNullOrEmpty(tmp))
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "KeyName", "alert('" + tmp.Substring(1) + "');", true);
            return;
        }
        string Form = "null"; 

        int CC = 0;
        if (CB.Checked == true)
            CC = 1;

        str = "Update Menu Set Title='" + TName.Text + "',Href='" + TPath.Text + "',Target='" + RBLtarget.SelectedValue + "',ImgPath='" + RBLPic.SelectedValue + "',Sort='" + TSort.Text + "',IsRoot=" + CC + ",Form=" + Form + " where IDNo=" + Uid.Text;
        GONon();
    }
    protected void BAdd_Click(object sender, EventArgs e)
    {

        string tmp = "";
        if (TName.Text == "")
            tmp += "，請輸入選單名稱";
        if (string.IsNullOrEmpty(TPath.Text))
            tmp += "，請輸入路徑";
        if (Main.IsNumeric(TSort.Text) == false)
            tmp += "，排序請輸入數字";
        if (!string.IsNullOrEmpty(tmp))
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "KeyName", "alert('" + tmp.Substring(1) + "');", true);
            return;
        }
        string Form = "null";
        

        int CC = 0;
        if (CB.Checked == true)
            CC = 1;

        str = "Insert Into Menu (Ref,Title,Href,Target,ImgPath,Sort,IsRoot,IsControl,Form) values (" + Ref.Text + ",'" + TName.Text + "','" + TPath.Text + "','" + RBLtarget.SelectedValue + "','" + RBLPic.SelectedValue + "','" + TSort.Text + "'," + CC + ",0," + Form + ")";
        GONon();
    }
}
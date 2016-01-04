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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeIN();

        }
    }
    void TreeIN()
    {
        SD.ConnectionString = Main.ConnStr;
        View1.Nodes.Clear();
        GetTreeView(View1.Nodes, "-1");
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
    private void GetTreeView(TreeNodeCollection nodes, String uid)
    {
        str = "Select Title,IDNo,Ref from Menu where Ref=" + uid + " and isnull(Form,'')<>'KM'  order by Sort ";
        DataTable dv = Main.GetDataSetNoNull(str);
        if (dv.Rows.Count > 0)
        {

            for (int i = 0; i <= dv.Rows.Count - 1; i++)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = dv.Rows[i]["Title"].ToString();
                NewNode.Value = dv.Rows[i]["IDNo"].ToString();

                GetTreeView(NewNode.ChildNodes, dv.Rows[i]["IDNo"].ToString());

                nodes.Add(NewNode);

            }
            TreeNode aNode = new TreeNode();
            aNode.Text = "[新增類別]";
            aNode.Value = uid;
            nodes.Add(aNode);
        }
        else
        {
            if (Main.Scalar("select ref from Menu where IDNo=" + uid) == "-1")
            {
                TreeNode aNode = new TreeNode();
                aNode.Text = "[新增類別]";
                aNode.Value = uid;
                nodes.Add(aNode);
            }

        }
    }
    protected void View1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TName.Text = "";
        TSort.Text = "";


        if (View1.SelectedNode.Text == "[新增類別]")
        {
            // Literal1.Text = "新增類別";
            BT_ADD.Visible = true;
            L_IDNo.Text = "";
            Ref.Text = View1.SelectedNode.Value;
        }
        else
        {
            View1.SelectedNode.Expand();
            // Literal1.Text = "類別編輯";
            BT_Del.Visible = true;
            BT_Update.Visible = true;
            L_IDNo.Text = View1.SelectedNode.Value;

            str = "select * from Menu where IDNo=" + View1.SelectedNode.Value;
            DataTable d = Main.GetDataSetNoNull(str);
            if (d.Rows.Count > 0)
            {
                TName.Text = d.Rows[0]["Title"].ToString();
                TPath.Text = d.Rows[0]["Href"].ToString();
                TSort.Text = d.Rows[0]["Sort"].ToString();
                Ref.Text = d.Rows[0]["Ref"].ToString();
            }
        }
        Panel1.Visible = true;
        if (L_IDNo.Text == "")
        {
            Ltitle.Text = "新增選單";
            BT_Del.Visible = false;
            BT_Update.Visible = false;
            BT_ADD.Visible = true;
        }
        else
        {
            Ltitle.Text = "選單修改";
            BT_Del.Visible = true;
            BT_Update.Visible = true;
            BT_ADD.Visible = false;
        }
    }
    protected void BT_ADD_Click(object sender, EventArgs e)
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
    protected void BT_Update_Click(object sender, EventArgs e)
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

        str = "Update Menu Set Title='" + TName.Text + "',Href='" + TPath.Text + "',Target='" + RBLtarget.SelectedValue + "',ImgPath='" + RBLPic.SelectedValue + "',Sort='" + TSort.Text + "',IsRoot=" + CC + ",Form=" + Form + " where IDNo=" + L_IDNo.Text;
        GONon();
    }
     
    protected void BT_Del_Click(object sender, EventArgs e)
    {
        str = "delete from Menu where IDNo=" + L_IDNo.Text;
        GONon();
    }
   
    
}
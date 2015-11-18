﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class  cate_mana : System.Web.UI.Page
{
    JDB Main = new JDB("Data Source=192.168.11.12;Initial Catalog=AppWeb2;user id=sa;password=`1qa~!QA");
    CommTool Comm = new CommTool();
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            TreeIN();

        }
    }
    void TreeIN()
    {
        SD.ConnectionString = Main.ConnStr;
        View1.Nodes.Clear();
        GetTreeView(View1.Nodes, "-1");
    }

    private void GetTreeView(TreeNodeCollection nodes, String uid)
    {
        str = "Select Cate_Name,IDNo from Product_Cate where Ref=" + uid + " and store_id=0 order by sort";

        DataTable dv = Main.GetDataSetNoNull(str);
        if (dv.Rows.Count > 0)
        {

            for (int i = 0; i <= dv.Rows.Count - 1; i++)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = dv.Rows[i]["Cate_Name"].ToString();
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
            if (Main.Scalar("select ref from Product_Cate where IDNo=" + uid) == "-1")
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
        BDel.Visible = false;
        BEdit.Visible = false;
        BAdd.Visible = false;
        Panel1.Visible = true;

        if (View1.SelectedNode.Text == "[新增類別]")
        {
            Literal1.Text = "新增類別";
            BAdd.Visible = true;
            strNo.Text = "";
            RefNO.Text = View1.SelectedNode.Value;
        }
        else
        {
            View1.SelectedNode.Expand();
            Literal1.Text = "類別編輯";
            BDel.Visible = true;
            BEdit.Visible = true;
            strNo.Text = View1.SelectedNode.Value;
            str = "select * from Product_Cate where IDNo=" + View1.SelectedNode.Value;
            DataTable d = Main.GetDataSetNoNull(str);
            if (d.Rows.Count > 0)
            {
                TName.Text = d.Rows[0]["Cate_Name"].ToString();
                TSort.Text = d.Rows[0]["Sort"].ToString();
            }
        }
    }
    protected void BAdd_Click(object sender, EventArgs e)
    {
        if (strNo.Text == "")
        {
            Main.ParaClear();
            Main.ParaAdd("@Ref", RefNO.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Cate_Name", TName.Text, SqlDbType.NVarChar);
            Main.ParaAdd("@Sort", TSort.Text, SqlDbType.NVarChar);
            Main.NonQuery("insert into Product_Cate (Ref, Cate_Name, Sort, Store_ID) values (@Ref, @Cate_Name, @Sort, 0)");
            TreeIN();
            Panel1.Visible = false;
        }
    }
    protected void BEdit_Click(object sender, EventArgs e)
    {
        Main.ParaClear();
        Main.ParaAdd("@strNo", strNo.Text, SqlDbType.NVarChar);
        Main.ParaAdd("@Cate_Name", TName.Text, SqlDbType.NVarChar);
        Main.ParaAdd("@Sort", TSort.Text, SqlDbType.NVarChar);
        Main.NonQuery("update Product_Cate set Cate_Name=@Cate_Name, Sort=@Sort where idno =@strNo");
        TreeIN();
        Panel1.Visible = false;
    }
    protected void BDel_Click(object sender, EventArgs e)
    {
        Main.ParaClear();
        Main.ParaAdd("@strNo", strNo.Text, SqlDbType.NVarChar); 
        Main.NonQuery("delete Product_Cate where idno =@strNo");
        TreeIN();
        Panel1.Visible = false;

    }
}
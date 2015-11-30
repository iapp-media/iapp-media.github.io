using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StoreMana
{
    public partial class Setting : System.Web.UI.Page
    {
        JDB Main = new JDB();
        CommTool Comm = new CommTool();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 getdate(); 
            }
        }

        protected void BTplus_Click(object sender, EventArgs e)
        {
            if (TB_Cate.Text != "")
            {
                Main.ParaClear();
                Main.ParaAdd("@Ref", -1, System.Data.SqlDbType.Int);
                Main.ParaAdd("@Cate_Name", TB_Cate.Text, System.Data.SqlDbType.NVarChar);
                Main.ParaAdd("@Store_ID",  Comm.Store_ID()  , System.Data.SqlDbType.Int);
                Main.NonQuery("insert into Product_Cate (Ref, Cate_Name,Store_ID) values (@Ref, @Cate_Name,@Store_ID)");
                getdate();
            }
        }

        protected void BTDEL_Click(object sender, EventArgs e)
        {
            if (CBL_Cate.SelectedValue != "")
            {
                string strCate = "";
                for (int i = 0; i < CBL_Cate.Items.Count; i++)
                {
                    if (CBL_Cate.Items[i].Selected)
                    {
                        strCate += ",'" + CBL_Cate.Items[i].Value + "'";
                    }

                }
                if (Main.Scalar("select 1 from Product where Cate_ID in (" + strCate.Substring(1) + ")") != "1")
                {
                    Main.NonQuery("delete Product_Cate where idno in (" + strCate.Substring(1) + ")");
                    getdate();
                }
                else
                {
                    Response.Write("<script>alert('商品已含有勾選的類別')</script>");
                }
            }
        }
        void getdate()
        {
            Main.FillDDP(CBL_Cate, "select * from Product_Cate where Store_ID='" + Comm.Store_ID() + "'", "Cate_Name", "idno");
        } 
     }
}
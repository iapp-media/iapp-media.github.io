using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_UrlRefer : System.Web.UI.Page
{
    JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2")); 
    string Constr = System.Configuration.ConfigurationManager.AppSettings.Get("Database2");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LB1.Text = Main.Scalar("select count(1) from UrlRefer");
           
            L.Text = "select *,(select Store_Name from Store_info where Store_ID in(select IDNo from Store where Store_NID=UrlRefer.SN) ) as SName from UrlRefer ";


           
        }

         SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;

  
    }

    protected void BTSearch_Click(object sender, EventArgs e)
    {
        L.Text = "select * from (select *,(select Store_Name from Store_info where Store_ID in(select IDNo from Store where Store_NID=UrlRefer.SN) ) as SName from UrlRefer ) aa where 1=1 ";
 
        if (TBName.Text != "")
        {
            L.Text += " and SName like '%"+TBName.Text+"%' ";
        }

        if (Main.IsDate(TBSDate.Text) )
        {
            L.Text += " and Date>='" + TBSDate.Text + "'";
        }
        if (Main.IsDate(TBEDate.Text))
        {
            System.DateTime Date1 = Convert.ToDateTime(TBEDate.Text);
            Date1 = Date1.AddDays(1);

            L.Text += " and Date<='" + Date1.ToShortDateString() + "'";
        }
      
        SD.ConnectionString = Constr;
        SD.SelectCommand = L.Text;
        GV.DataSourceID = SD.ID;
        
    }
}
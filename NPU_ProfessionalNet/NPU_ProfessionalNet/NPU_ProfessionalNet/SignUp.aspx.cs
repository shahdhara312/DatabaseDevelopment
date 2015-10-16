using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace NPU_ProfessionalNet
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //drpcountry.DataSource = GetCountry();
            //drpcountry.DataBind();
            //drpcountry.Items.Insert(0, "Select");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            btncreateprofile.Visible = true;
        }

        protected void btncreateprofile_Click(object sender, EventArgs e)
        {

        }

        protected void rdbemployed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbemployed.Checked == true)
            {
                pnlemployed.Visible = true;
                pnljobseeker.Visible = false;
                pnlstudent.Visible = false;
            }
            else 
            {
                pnlemployed.Visible = false;
            }
        }
            
        protected void rdbjobseeker_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbjobseeker.Checked == true)
            {
                pnljobseeker.Visible = true;
                pnlemployed.Visible = false;
                pnlstudent.Visible = false;
            }
            else
            {
                pnljobseeker.Visible = false;
            }
        }

        protected void rdbstudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbstudent.Checked == true)
            {
                pnlstudent.Visible = true;
                pnljobseeker.Visible = false;
                pnlemployed.Visible = false;
            }
            else
            {
                pnlstudent.Visible = false;
            }
        }
        public List<string> GetCountry()
        {
            List<string> list = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            foreach (CultureInfo culture in cultures)
            {
                if (culture.LCID != 127)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);

                    if (!(list.Contains(region.EnglishName)))
                    {
                        list.Add(region.EnglishName);
                    }
                }
            }

            list.Sort(); //put the country list in alphabetic order.


            return list;
        }
    }
}
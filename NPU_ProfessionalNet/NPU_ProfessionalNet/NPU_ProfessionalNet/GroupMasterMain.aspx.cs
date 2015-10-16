using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPU.BusinessLogic;
using NPU.BusinessEntity;
using System.Collections;


namespace NPU_ProfessionalNet
{
    public partial class GroupMasterMain : System.Web.UI.Page
    {
        string userId = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["UserId"] != null)
            {
                userId = Convert.ToString(Session["UserId"]);
            }*/
            userId = "8993C24B-7595-4FE6-8496-DB6C3D5D1EDB";
            if (!IsPostBack)
            {
                GroupMasterAction objGroupMasterAction = new GroupMasterAction();


                List<GroupMaster> lstGroupMaster = objGroupMasterAction.GetGroupByUserId(new Guid(userId));

                dgGroup.DataSource = lstGroupMaster;
                dgGroup.DataBind();

            }
        }

        protected void btnjoin_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string lstConnection = string.Empty;
            // Looping through all the rows in the GridView

            foreach (DataGridItem row in dgGroup.Items)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("cbRows");
                HiddenField hdnConnectionId = (HiddenField)row.FindControl("hdnConnectionId");
                if (checkbox.Checked)
                {
                    lstConnection = lstConnection + ",'" + hdnConnectionId.Value + "'";
                }
            }
            if (lstConnection.Length > 0)
            {
                lstConnection = lstConnection.Substring(1, lstConnection.Length - 1);
                 // delete method

                GroupMasterAction objGroupMasterAction = new GroupMasterAction();
                objGroupMasterAction.DeleteConnection(lstConnection);
                
                // get grid data
                List<GroupMaster> lstConnectionMaster = objGroupMasterAction.GetGroupByUserId(new Guid(userId));

                dgGroup.DataSource = lstConnectionMaster;
                dgGroup.DataBind();
            }
        }
     }
}
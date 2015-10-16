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
    public partial class GroupHomeMain : System.Web.UI.Page
    {
        string userId = string.Empty;
        string groupnm = string.Empty;
        string groupid = string.Empty;
        Boolean likeflag;
        Guid grpid;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblgroupname.Text = HttpUtility.UrlDecode(Request.QueryString["GroupName"]);
            groupid = HttpUtility.UrlDecode(Request.QueryString["GroupID"]);
            groupnm = HttpUtility.UrlDecode(Request.QueryString["GroupName"]);
            /*if (Session["UserId"] != null)
            {
                userId = Convert.ToString(Session["UserId"]);
            }*/
            userId = "8993C24B-7595-4FE6-8496-DB6C3D5D1EDB";
            if (!IsPostBack)
            {
                PostMasterAction objGroupMasterAction = new PostMasterAction();
                List<PostMaster> lstGroupMaster = objGroupMasterAction.GetPostByGroupid(new Guid(groupid));

                dgpost.DataSource = lstGroupMaster;
                dgpost.DataBind();

                UsertoGroupAction objUsertoGroupMasterAction = new UsertoGroupAction();
                UsertoGroupMaster lstUserGroupMaster = objUsertoGroupMasterAction.GetUsertoGroupById((new Guid(userId)), (new Guid(groupid)));

                likeflag = lstUserGroupMaster.IsLike;
                if (!likeflag)
                {
                    btnlike.Visible = true;
                }
                else
                {
                    btnunlike.Visible = true;
                }
            }
        }

        protected void btnlike_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnleave_Click(object sender, EventArgs e)
        {

        }

        protected void btnpost_Click(object sender, EventArgs e)
        {
            PostMasterAction objUserMasterAction = new PostMasterAction();
            PostMaster objPostMaster = new PostMaster();
            objPostMaster.GroupID = new Guid(groupid);
            objPostMaster.UserID = new Guid(userId);
            objPostMaster.post = txtpost.Text.Trim();
            objPostMaster.PostID = objUserMasterAction.AddPostMaster(objPostMaster);
        }
    }
}
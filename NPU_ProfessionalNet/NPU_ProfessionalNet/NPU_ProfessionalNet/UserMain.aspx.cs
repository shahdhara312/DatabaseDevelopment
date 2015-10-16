using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPU.BusinessLogic;
using NPU.BusinessEntity;

namespace NPU_ProfessionalNet
{
    public partial class UserMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserMasterAction objUserMasterAction = new UserMasterAction();
            UserMaster objUserMaster = new UserMaster();
            objUserMaster.FName = "Hima";
            objUserMaster.LName = "Shah";
            objUserMaster.Email = "shah11781@mailnpu.com";
            objUserMaster.Country = "USA";
            objUserMaster.Password = "testpass";
            objUserMaster.ZipCode = 12345;
            objUserMaster.UserType = "student";
            objUserMaster.CompanyID = new Guid("482B029F-45DF-47C6-AEA5-19EA25F8FA9F");
            objUserMaster.SchoolID = new Guid("7278075E-1E88-4138-919C-32EE7B4FF5E5");
            objUserMaster.UserID = objUserMasterAction.AddUserMaster(objUserMaster);

            if(objUserMaster.UserID != Guid.Empty)
            {
                lblMessage.Text = "User Added";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserMasterAction objUserMasterAction = new UserMasterAction();
            UserMaster objUserMaster = new UserMaster();

            // get user
            objUserMaster = objUserMasterAction.GetUserByUserid(new Guid("3E3407C8-506F-4FE3-AE50-78C033836324"));
            objUserMaster.LName = "Desai";

            // update user
            Boolean result = objUserMasterAction.UpdateUserMaster(objUserMaster);

            if (result)
            {
                lblMessage.Text = "User updated";
            }
        }
    }
}
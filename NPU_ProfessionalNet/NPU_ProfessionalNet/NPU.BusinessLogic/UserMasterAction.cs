using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using NPU.DataAccess;

namespace NPU.BusinessLogic
{
    public class UserMasterAction
    {
        public Guid AddUserMaster(UserMaster pUserMaster)
        {
            UserMasterRepository myUserMasterRep = new UserMasterRepository();
           
            try
            {
                return myUserMasterRep.AddUser(pUserMaster);
            }
            catch (Exception)
            {
                return Guid.Empty;

            }            
        }

        public Boolean UpdateUserMaster(UserMaster pUserMaster)
        {
            UserMasterRepository myUserMasterRep = new UserMasterRepository();

            try
            {
                return myUserMasterRep.UpdateUser(pUserMaster);
            }
            catch (Exception)
            {
                return false;

            }
        }

        public UserMaster GetUserByUserid(Guid pUserId)
        {
            UserMasterRepository myUserMasterRep = new UserMasterRepository();

            try
            {
                return myUserMasterRep.GetUserByUserid(pUserId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

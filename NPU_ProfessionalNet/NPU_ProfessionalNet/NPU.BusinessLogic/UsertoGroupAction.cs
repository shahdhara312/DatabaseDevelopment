using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using NPU.DataAccess;

namespace NPU.BusinessLogic
{
    public class UsertoGroupAction
    {
        public UsertoGroupMaster GetUsertoGroupById(Guid pUserId,Guid pGroupId)
        {
            UsertoGroupMasterRepository myUserGroupMasterRep = new UsertoGroupMasterRepository();

            try
            {
                return myUserGroupMasterRep.GetUsertoGroupByid(pUserId,pGroupId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

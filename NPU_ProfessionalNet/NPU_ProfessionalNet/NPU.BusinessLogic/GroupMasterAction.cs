using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using NPU.DataAccess;

namespace NPU.BusinessLogic
{
    public class GroupMasterAction
    {
        public List<GroupMaster> GetGroupByUserId(Guid pUserId)
        {
            GroupMasterRepository myGroupMasterRep = new GroupMasterRepository();

            try
            {
                return myGroupMasterRep.GetGroupByUserId(pUserId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Guid JoinGroupMaster(GroupMaster pGroupMaster)
        {
            GroupMasterRepository myUserMasterRep = new GroupMasterRepository();

            try
            {
                return myUserMasterRep.JoinGroup(pGroupMaster);
            }
            catch (Exception)
            {
                return Guid.Empty;

            }
        }

        public Boolean DeleteConnection(string lstConnectionId)
        {
            GroupMasterRepository myGroupMasterRep = new GroupMasterRepository();

            try
            {
                return myGroupMasterRep.DeleteConnection(lstConnectionId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using System.Data;

namespace NPU.DataAccess
{
    public class UsertoGroupMasterRepository : Repository<UsertoGroupMaster>
    {
        public UsertoGroupMasterRepository()
        {
        }
        public UsertoGroupMasterRepository(DbTransaction pTrasaction)
        {
            base.Transaction = pTrasaction;
        }

        public UsertoGroupMaster GetUsertoGroupByid(Guid pUserId,Guid pGroupId)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.GetUserToGroupByGroupId");
            Database.AddInParameter(command, "GroupID", DbType.Guid, pGroupId);
            Database.AddInParameter(command, "UserID", DbType.Guid, pUserId);
            return base.FindOne(command, new UserGroupMasterFactory());
        }

    }
    internal class UserGroupMasterFactory : IDomainObjectFactory<UsertoGroupMaster>
    {
        public UsertoGroupMaster Construct(IDataReader reader)
        {
            UsertoGroupMaster myUserGroupMaster = new UsertoGroupMaster();

            myUserGroupMaster.UserGroupID = HelperMethods.GetGuid(reader, "UserGroupID");
            myUserGroupMaster.UserID = HelperMethods.GetGuid(reader, "UserId");
            myUserGroupMaster.GroupID = HelperMethods.GetGuid(reader, "GroupID");
            myUserGroupMaster.IsLike = HelperMethods.GetBoolean(reader, "IsLike");
            myUserGroupMaster.JoinDate = HelperMethods.GetDateTime(reader, "JoinDate");
            myUserGroupMaster.CreatedOn = HelperMethods.GetDateTime(reader, "CreatedOn");
            myUserGroupMaster.UpdatedOn = HelperMethods.GetDateTime(reader, "UpdatedOn");
            return myUserGroupMaster;
        }
    }
}

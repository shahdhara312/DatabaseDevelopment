using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using System.Data;

namespace NPU.DataAccess
{
    public class GroupMasterRepository : Repository<GroupMaster>
    {
        public GroupMasterRepository()
        {
        }
        public GroupMasterRepository(DbTransaction pTrasaction)
        {
            base.Transaction = pTrasaction; 
        }
        public List<GroupMaster> GetGroupByUserId(Guid pUserId)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.GetGroupByUserId");
            Database.AddInParameter(command, "UserID", DbType.Guid, pUserId);
            return base.Find(command, new GroupMasterFactory());
        }
        public Guid JoinGroup(GroupMaster pGroupMaster)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.AddGroup");
            Database.AddInParameter(command, "FName", DbType.String, pGroupMaster.GroupName);
            Database.AddOutParameter(command, "GroupID", DbType.Guid, 16);
            var result = base.Add(command, "GroupID");
            return new Guid(result.ToString());
        }

        public bool DeleteConnection(string lstConnectionId)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.DeleteGroup");
            Database.AddInParameter(command, "GroupID", DbType.Guid, 16);
            return base.Save(command);
        }
    }
    internal class GroupMasterFactory : IDomainObjectFactory<GroupMaster>
    {
        public GroupMaster Construct(IDataReader reader)
        {
            GroupMaster myGroupMaster = new GroupMaster();

            myGroupMaster.GroupID = HelperMethods.GetGuid(reader, "GroupID");
            myGroupMaster.GroupName = HelperMethods.GetString(reader, "GroupName");

            myGroupMaster.CreatedOn = HelperMethods.GetDateTime(reader, "CreatedOn");

            return myGroupMaster;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using System.Data;

namespace NPU.DataAccess
{
    public class UserMasterRepository : Repository<UserMaster>
    {
        public UserMasterRepository()
        {
        }
        public UserMasterRepository(DbTransaction pTrasaction)
        {
            base.Transaction = pTrasaction;
        }

        public Guid AddUser(UserMaster pUserMaster)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.AddUser");
            Database.AddInParameter(command, "FName", DbType.String, pUserMaster.FName);
            Database.AddInParameter(command, "LName", DbType.String, pUserMaster.LName);
            Database.AddInParameter(command, "Email", DbType.String, pUserMaster.Email);
            Database.AddInParameter(command, "Password", DbType.String, pUserMaster.Password);
            Database.AddInParameter(command, "Country", DbType.String, pUserMaster.Country);
            Database.AddInParameter(command, "ZipCode", DbType.Int32, pUserMaster.ZipCode);
            Database.AddInParameter(command, "UserType", DbType.String, pUserMaster.UserType);
            Database.AddInParameter(command, "CompanyID", DbType.Guid, pUserMaster.CompanyID);
            Database.AddInParameter(command, "SchoolID", DbType.Guid, pUserMaster.SchoolID);
            Database.AddOutParameter(command, "UserId", DbType.Guid, 16);
            var result = base.Add(command, "UserId");           
            return new Guid(result.ToString());            
        }

        public Boolean UpdateUser(UserMaster pUserMaster)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.UpdateUser");
            Database.AddInParameter(command, "FName", DbType.String, pUserMaster.FName);
            Database.AddInParameter(command, "LName", DbType.String, pUserMaster.LName);
            Database.AddInParameter(command, "Email", DbType.String, pUserMaster.Email);
            Database.AddInParameter(command, "Password", DbType.String, pUserMaster.Password);
            Database.AddInParameter(command, "Country", DbType.String, pUserMaster.Country);
            Database.AddInParameter(command, "ZipCode", DbType.Int32, pUserMaster.ZipCode);
            Database.AddInParameter(command, "UserType", DbType.String, pUserMaster.UserType);
            Database.AddInParameter(command, "CompanyID", DbType.Guid, pUserMaster.CompanyID);
            Database.AddInParameter(command, "SchoolID", DbType.Guid, pUserMaster.SchoolID);
            Database.AddInParameter(command, "UserId", DbType.Guid, pUserMaster.UserID);
            return base.Save(command);
        }

        public UserMaster GetUserByUserid(Guid pUserId)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.SelectUser");
            Database.AddInParameter(command, "UserId", DbType.Guid, pUserId);
            return base.FindOne(command, new UserMasterFactory());
        }
    }

    internal class UserMasterFactory : IDomainObjectFactory<UserMaster>
    {
        public UserMaster Construct(IDataReader reader)
        {
            UserMaster myUserMaster = new UserMaster();

            myUserMaster.UserID = HelperMethods.GetGuid(reader, "UserId");
            myUserMaster.FName = HelperMethods.GetString(reader, "FName");
            myUserMaster.LName = HelperMethods.GetString(reader, "LName");
            myUserMaster.Email = HelperMethods.GetString(reader, "Email");
            myUserMaster.Password = HelperMethods.GetString(reader, "Password");
            myUserMaster.Country = HelperMethods.GetString(reader, "Country");
            myUserMaster.ZipCode = HelperMethods.GetInt32(reader, "ZipCode");
            myUserMaster.UserType = HelperMethods.GetString(reader, "UserType");
            myUserMaster.CompanyID = HelperMethods.GetGuid(reader, "CompanyID");
            myUserMaster.SchoolID = HelperMethods.GetGuid(reader, "SchoolID");
            myUserMaster.CreatedOn = HelperMethods.GetDateTime(reader, "CreatedOn");
            myUserMaster.UpdatedOn = HelperMethods.GetDateTime(reader, "UpdatedOn");
            return myUserMaster;
        }
    }
}

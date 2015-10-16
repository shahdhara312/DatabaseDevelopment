using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using System.Data;

namespace NPU.DataAccess
{
    public class PostMasterRepository : Repository<PostMaster>
    {
          public PostMasterRepository()
        {
        }
        public PostMasterRepository(DbTransaction pTrasaction)
        {
            base.Transaction = pTrasaction; 
        }
        public List<PostMaster> GetPostByGroupId(Guid pUserId)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.GetPostByGroupID");
            Database.AddInParameter(command, "GroupID", DbType.Guid, pUserId);
            return base.Find(command, new PostMasterFactory());
        }
        public Guid AddPost(PostMaster pPostMaster)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.AddPost");
            Database.AddInParameter(command, "UserID", DbType.Guid, pPostMaster.UserID);
            if (pPostMaster.GroupID != Guid.Empty)
            {
                Database.AddInParameter(command, "GroupID", DbType.Guid, pPostMaster.GroupID);
            }
            else
            {
                Database.AddInParameter(command, "GroupID", DbType.Guid, DBNull.Value);
            }

            if (pPostMaster.CompanyID != Guid.Empty)
            {
                Database.AddInParameter(command, "CompanyID", DbType.Guid, pPostMaster.CompanyID);
            }
            else
            {
                Database.AddInParameter(command, "CompanyID", DbType.Guid, DBNull.Value);

            }

            if (pPostMaster.SchoolID != Guid.Empty)
            {
                Database.AddInParameter(command, "SchoolID", DbType.Guid, pPostMaster.SchoolID);
            }
            else
            {
                Database.AddInParameter(command, "SchoolID", DbType.Guid, DBNull.Value);

            }
           
            Database.AddInParameter(command, "Post", DbType.String, pPostMaster.post);
            Database.AddOutParameter(command, "PostID", DbType.Guid, 16);
            var result = base.Add(command, "PostID");
            return new Guid(result.ToString());
        }
    }
    internal class PostMasterFactory : IDomainObjectFactory<PostMaster>
    {
        public PostMaster Construct(IDataReader reader)
        {
            PostMaster myPostMaster = new PostMaster();
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
            myPostMaster.PostUserMaster = myUserMaster;

            myPostMaster.PostID = HelperMethods.GetGuid(reader, "PostID");
            myPostMaster.UserID = HelperMethods.GetGuid(reader, "UserID");
            myPostMaster.GroupID = HelperMethods.GetGuid(reader, "GroupID");
            myPostMaster.CompanyID = HelperMethods.GetGuid(reader, "CompanyID");
            myPostMaster.SchoolID = HelperMethods.GetGuid(reader, "SchoolID");
            myPostMaster.PostedOn = HelperMethods.GetDateTime(reader, "PostedOn");
            myPostMaster.post = HelperMethods.GetString(reader, "post");

            return myPostMaster;
        }
    }
}

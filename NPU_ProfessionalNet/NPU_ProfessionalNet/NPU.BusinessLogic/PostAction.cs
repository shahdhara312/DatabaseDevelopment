using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using NPU.DataAccess;


namespace NPU.BusinessLogic
{
    public class PostAction
    {
        public List<PostMaster> GetPostByGroupId(Guid pUserId)
        {
            PostMasterRepository myPostMasterRep = new PostMasterRepository();

            try
            {
                return myPostMasterRep.GetPostByGroupId(pUserId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

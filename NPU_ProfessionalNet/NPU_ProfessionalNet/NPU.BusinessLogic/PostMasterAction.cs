using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using NPU.BusinessEntity;
using NPU.DataAccess;

namespace NPU.BusinessLogic
{
    public class PostMasterAction
    {
        public List<PostMaster> GetPostByGroupid(Guid pGroupId)
        {
            PostMasterRepository myPostMasterRep = new PostMasterRepository();

            try
            {
                return myPostMasterRep.GetPostByGroupId(pGroupId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Guid AddPostMaster(PostMaster pPostMaster)
        {
            PostMasterRepository myPostMasterRep = new PostMasterRepository();

            try
            {
                return myPostMasterRep.AddPost(pPostMaster);
            }
            catch (Exception)
            {
                return Guid.Empty;

            }
        }
    }
}

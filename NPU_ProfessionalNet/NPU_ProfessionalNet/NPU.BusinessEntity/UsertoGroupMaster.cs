using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.BusinessEntity
{
    public class UsertoGroupMaster
    {
        public Guid UserGroupID { get; set; }
        public Guid UserID { get; set; }
        public Guid GroupID { get; set; }
        public Boolean IsLike { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}

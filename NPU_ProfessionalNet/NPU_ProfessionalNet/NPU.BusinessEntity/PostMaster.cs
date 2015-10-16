using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.BusinessEntity
{
    public class PostMaster
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public Guid GroupID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid SchoolID { get; set; }
        public DateTime PostedOn { get; set; }
        public string post { get; set; }
        public UserMaster PostUserMaster { get; set; }
    }
}

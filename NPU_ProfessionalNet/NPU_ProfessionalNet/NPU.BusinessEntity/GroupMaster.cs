using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.BusinessEntity
{
    public class GroupMaster
    {
        public Guid GroupID { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

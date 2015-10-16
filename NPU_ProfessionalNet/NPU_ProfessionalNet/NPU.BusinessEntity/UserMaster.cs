using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.BusinessEntity
{
    public class UserMaster
    {
        public Guid UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string UserType { get; set; }
        public Guid CompanyID { get; set; }
        public Guid SchoolID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}

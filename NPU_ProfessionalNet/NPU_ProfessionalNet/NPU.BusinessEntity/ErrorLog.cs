
      
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.BusinessEntity
{
  public class ErrorLog
  {
    
      public Int32 ErrorId {get; set;}
    
      public String Message {get; set;}
    
      public String ip {get; set;}

      public Int32 GeneratedBy { get; set; }
    
      public DateTime GeneratedOn {get; set;}
    
      public String StackTrace {get; set;}
    

    public ErrorLog ()
    {

    }
  }
}
  
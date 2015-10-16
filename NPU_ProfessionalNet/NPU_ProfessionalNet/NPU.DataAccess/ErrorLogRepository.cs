

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using NPU.BusinessEntity;


namespace NPU.DataAccess
{

    public class ErrorLogRepository : Repository<ErrorLog>
    {

        #region CRUD methods

        public Int32 AddErrorLog(ErrorLog pErrorLog)
        {
            DbCommand command = Database.GetStoredProcCommand("dbo.InsertErrorLog");


            Database.AddOutParameter(command, "ErrorId", DbType.Int32, 4);

            Database.AddInParameter(command, "Message", DbType.String, pErrorLog.Message);

            Database.AddInParameter(command, "ip", DbType.String, pErrorLog.ip);

            Database.AddInParameter(command, "GeneratedBy", DbType.Int32, pErrorLog.GeneratedBy);

            Database.AddInParameter(command, "GeneratedOn", DbType.DateTime, pErrorLog.GeneratedOn);

            Database.AddInParameter(command, "StackTrace", DbType.String, pErrorLog.StackTrace);


            var result = base.Add(command, "ErrorId");

            return Convert.ToInt32(result);

        }

        #endregion

    }

}

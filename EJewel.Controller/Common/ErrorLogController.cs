using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Controller.Common
{
    public class ErrorLogController
    {
        ErrorLogDAL objDAL = new ErrorLogDAL();

        public long SetErrorLog(ErrorLogModel model)
        {
            return objDAL.SetErrorLog(model);
        }

        public List<ErrorLogModel> ErrorLogList(long logId)
        {
            return objDAL.ErrorLogList(logId);
        }
    }
}

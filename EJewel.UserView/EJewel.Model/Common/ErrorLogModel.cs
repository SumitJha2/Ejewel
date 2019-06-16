using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel
{
    public class ErrorLogModel
    {
        public long ErrorLogId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorSource { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string UserID { get; set; }
        public DateTime LogTime { get; set; }
    }
}

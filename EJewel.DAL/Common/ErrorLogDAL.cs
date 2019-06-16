using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL;
//model
namespace EJewel
{
    /// <summary>
    /// Manage the Error Details
    /// Author: Partha @ 01-03-13
    /// </summary>
    public class ErrorLogDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public long SetErrorLog(ErrorLogModel model)
        {
            long logID = 0;
            try
            {
                if (model != null)
                {
                    ej_ErrorLog ErrorLog = new ej_ErrorLog()
                    {
                        ErrorLogId = model.ErrorLogId,
                        ErrorMessage = model.ErrorMessage,
                        ErrorSource = model.ErrorSource,
                        InnerException = model.InnerException,
                        LogTime = model.LogTime,
                        StackTrace = model.StackTrace,
                        UserID = model.UserID
                    };
                    objEntity.AddToej_ErrorLog(ErrorLog);
                    objEntity.SaveChanges();
                    logID = ErrorLog.ErrorLogId;
                }
            }
            catch(Exception)
            {

            }
            return logID;
        }

        public List<ErrorLogModel> ErrorLogList(long logId)
        {
            
            List<ErrorLogModel> lstModel = new List<ErrorLogModel>();
            try
            {
                List<ej_ErrorLog> lstErrorLog = null;
                if (logId > 0)
                {
                    lstErrorLog = objEntity.ej_ErrorLog.Where(tbl => tbl.ErrorLogId == logId).ToList();
                }
                else
                {
                    lstErrorLog = objEntity.ej_ErrorLog.Select(tbl => tbl).ToList();
                }
                if (lstErrorLog != null)
                {
                    lstModel = (from errorLog in lstErrorLog
                                select new ErrorLogModel()
                                {
                                    ErrorLogId = errorLog.ErrorLogId,
                                    ErrorMessage = errorLog.ErrorMessage,
                                    ErrorSource = errorLog.ErrorSource,
                                    InnerException = errorLog.InnerException,
                                    LogTime = errorLog.LogTime,
                                    StackTrace = errorLog.StackTrace,
                                    UserID = errorLog.UserID
                                }).OrderByDescending(tbl => tbl.ErrorLogId).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLogDAL obj = new ErrorLogDAL();
                obj.SetErrorLog(new ErrorLogModel()
                {
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    InnerException = Convert.ToString(ex.InnerException),
                    LogTime = DateTime.Now,
                    StackTrace = ex.StackTrace,
                    UserID = "DAL"
                });
            }
            return lstModel;

        }
    }
}

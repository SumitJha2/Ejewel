using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.DAL.Admin.Master.Location
{
  public class StateDAL
    {

        EJewelEntities objEntity = new EJewelEntities();



        public StateModel SaveUpdateState(StateModel model)
        {
            try
            {
                if (model.StateId > 0)
                {
                    ej_State objState = objEntity.ej_State.Where(tbl => tbl.StateId == model.StateId).FirstOrDefault();
                    if (objState != null)
                    {
                        //check that the sub State is present or not
                        if (objState.StateName != model.StateName)
                        {
                            objState.StateName = model.StateName;
                        }
                        //State
                        objState.StateCode = model.StateCode;
                        objState.CreatedBy = model.CreatedBy;
                        objState.CreatedDate = model.CreatedDate;
                        objState.Status = model.Status;
                        objEntity.SaveChanges();
                    }
                }
                else
                {
                    ej_State objState = new ej_State()
                    {
                        StateId = model.StateId,
                        CountryId = model.CountryId,
                        StateName = model.StateName,
                        StateCode = model.StateCode,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,
                        Status = model.Status,

                    };
                    objEntity.AddToej_State(objState);
                    objEntity.SaveChanges();
                    model.StateId = objState.StateId;
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
            return model;

        }



        public bool DeleteState(int stateID)
        {
            try
            {
                ej_State objState = objEntity.ej_State.Where(tbl => tbl.StateId == stateID).FirstOrDefault();
                if (objState != null)
                {
                    objEntity.DeleteObject(objState);
                    objEntity.SaveChanges();
                    return true;
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
            return false;
        }


        public bool IsExistState(int countryId, int StateID, string stateName)
        {
            try
            {
                return objEntity.ej_State.Where(tbl => tbl.CountryId == countryId && tbl.StateId != StateID && tbl.StateName == stateName).Any();
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
            return false;
        }




        public List<StateModel> GetStateListByCountryID(int countryID, CommonModel.RecordStatus rStatus)
        {
            List<StateModel> lstModel = new List<StateModel>();

            try
            {
                List<ej_State> lstState = null;
                if (countryID > 0)
                {
                    lstState = objEntity.ej_State.Where(tbl => tbl.CountryId == countryID).ToList();
                }
                else
                {
                    lstState = objEntity.ej_State.Select(tbl => tbl).ToList();
                }

                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstState = lstState.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstState != null)
                {
                    lstModel = (from state in lstState
                                join country in objEntity.ej_Country
                                on state.CountryId equals country.CountryId
                                where country.Status == true
                                select new StateModel
                                {
                                    CountryId = state.CountryId,
                                    StateId = state.StateId,
                                    CountryName = country.CountryName,
                                    StateName = state.StateName,
                                    StateCode = state.StateCode,
                                    CreatedBy = Convert.ToInt32(state.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(state.CreatedDate),
                                    Status = Convert.ToBoolean(state.Status)
                                }).OrderByDescending(tbl => tbl.StateName).ToList();
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




        public List<StateModel> GetStateList(int stateID, CommonModel.RecordStatus rStatus)
        {
            List<StateModel> lstModel = new List<StateModel>();

            try
            {
                List<ej_State> lstState = null;
                if (stateID > 0)
                {
                    lstState = objEntity.ej_State.Where(tbl => tbl.StateId == stateID).ToList();
                }
                else
                {
                    lstState = objEntity.ej_State.Select(tbl => tbl).ToList();
                }

                if (rStatus == CommonModel.RecordStatus.Enabled)
                {
                    lstState = lstState.Where(tbl => tbl.Status == true).ToList();
                }

                //
                if (lstState != null)
                {
                    lstModel = (from state in lstState
                                join country in objEntity.ej_Country
                                on state.CountryId equals country.CountryId
                                where country.Status == true
                                select new StateModel
                                {
                                    CountryId = state.CountryId,
                                    StateId = state.StateId,
                                    CountryName = country.CountryName,
                                    StateName = state.StateName,
                                    StateCode = state.StateCode,
                                    CreatedBy = Convert.ToInt32(state.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(state.CreatedDate),
                                    Status = Convert.ToBoolean(state.Status)
                                }).OrderByDescending(tbl => tbl.StateName).ToList();
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

        public List<StateModel> GetStateIDByStateName(string stateName)
        {
            List<StateModel> lstModel = new List<StateModel>();

            try
            {
                List<ej_State> lstState = null;

                lstState = objEntity.ej_State.Where(tbl => tbl.StateName == stateName && tbl.Status == true).ToList();



                //
                if (lstState != null)
                {
                    lstModel = (from state in lstState
                                join country in objEntity.ej_Country
                                on state.CountryId equals country.CountryId
                                where country.Status == true
                                select new StateModel
                                {
                                    CountryId = state.CountryId,
                                    StateId = state.StateId,
                                    CountryName = country.CountryName,
                                    StateName = state.StateName,
                                    StateCode = state.StateCode,
                                    CreatedBy = Convert.ToInt32(state.CreatedBy),
                                    CreatedDate = Convert.ToDateTime(state.CreatedDate),
                                    Status = Convert.ToBoolean(state.Status)
                                }).OrderByDescending(tbl => tbl.StateName).ToList();
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

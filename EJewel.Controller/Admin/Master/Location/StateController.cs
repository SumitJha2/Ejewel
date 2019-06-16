using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Master.Location;
using EJewel.Model.Admin.Master.Location;
using EJewel.Model.Admin.Common;

namespace EJewel.Controller.Admin.Master.Location
{
   public class StateController
    {
         StateDAL objStateDAL = new StateDAL();

        public StateModel SaveUpdateState(StateModel model)
        {
            return objStateDAL.SaveUpdateState(model);
        }
        public bool IsExistState(int countryId, int stateID, string stateName)
        {
            return objStateDAL.IsExistState(countryId, stateID, stateName);
        }
        public bool DeleteState(int stateId)
        {
            return objStateDAL.DeleteState(stateId);
        }
        public List<StateModel> GetStateListByCountryID(int countryID, CommonModel.RecordStatus rStatus)
        {
            return objStateDAL.GetStateListByCountryID(countryID, rStatus);
        }
       
        public List<StateModel> GetStateList(int StateID, CommonModel.RecordStatus rStatus)
        {
            return objStateDAL.GetStateList(StateID, rStatus);
        }
        public List<StateModel> GetStateIDByStateName(string Statename)
        {
            return objStateDAL.GetStateIDByStateName(Statename);
        }
    }
}

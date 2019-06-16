using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel
{
    /*
       * Partha Ranjan
       * @ 01-02-13
       * This class used to define the common attribute for the application
       * */
    public sealed class CommonModel
    {
        //this is for manag ethe status of the application
        public enum RecordStatus { Both, Enabled };
        //side stone design type
        public enum SideStoneDesignType { ALTERNATE, CONTINEOUS };
        //side stone
        public enum StoneCategoryType { DIAMOND, GEMSTONE };
    }
}
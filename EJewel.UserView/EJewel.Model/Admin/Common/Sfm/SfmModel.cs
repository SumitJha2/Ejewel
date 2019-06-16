using System;

namespace EJewel.Model.Admin.Common.Sfm
{
    /*
     * Partha
     * @ 30-01-13
     * This class helps to manage the 3 field in a table
     * @ modifled name in 05-03-13
     * */
    public class SfmModel
    {
        public enum PageName { None, MetalWeightMaster, MetalNameMaster, SettingType, ChainStyle, ChainLength, CertificateGridle, CertificateCulet, CertificatePolish, CertificateSymmetry, CertificateFlouresence, CertificateLab, RingSize, StoneShape, ShippingName, ShippingType, NewsCategory,ChainClasp,AttributeTitle};
        public int AutoID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}

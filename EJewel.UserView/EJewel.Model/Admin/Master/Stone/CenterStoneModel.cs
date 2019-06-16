using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
    /// <summary>
    /// This Center Stone Model For both FD Center Stone and Rapnet and Supplier
    /// Partha Ranjan
    /// @ 01-04-13
    /// </summary>
    public class CenterStoneModel
    {
        public enum CenterStoneProvider { FascinatingDiamonds, Rapnet, Supplier,None }
        public long StoneId { get; set; }
        public string SKU { get; set; }

        public int StoneCutId { get; set; }
        public string StoneCut { get; set; }
        //
        public int StoneColorId { get; set; }
        public string StoneColor { get; set; }
        //
        public int StoneClarityId { get; set; }
        public string StoneClarity { get; set; }
        //
        public int StoneShapeId { get; set; }
        public string StoneShape { get; set; }
        //
        public int StoneTypeId { get; set; }
        public string StoneType { get; set; }
        //
        public double StoneCarate { get; set; }
        public double StonePrice { get; set; }

        public double CertificateDepth { get; set; }
        public double CertificateTable { get; set; }
        //
        public int CertificateGridleId { get; set; }
        public string CertificateGridle { get; set; }
        //
        public int CertificateSymmetryId { get; set; }
        public string CertificateSymmetry { get; set; }
        //
        public int CertificatePolishId { get; set; }
        public string CertificatePolish { get; set; }
        //
        public int CertificateCuletId { get; set; }
        public string CertificateCulet { get; set; }
        //
        public int CertificateFlouresenceId { get; set; }
        public string CertificateFlouresence { get; set; }
        //
        public string CertificateMeasurement { get; set; }
        public double CertificateCrown { get; set; }
        public double CertificateCrownAngle { get; set; }
        public double CertificatePavillion { get; set; }
        public double CertificatePavillionAngle { get; set; }
        public string Certification { get; set; }
        //
        public int CertificateCertificationLabId { get; set; }
        public string CertificateCertificationLab { get; set; }
        //
        public string CertificationFile { get; set; }
        public bool Status { get; set; }
        //for total data
        public int TotalRecord { get; set; }

        // added by sumit on 31-05-2013
        public double Discount { get; set; }
        public int DiscountType { get; set; }

        //added by sumit on 11-06-2013

        public int Provider { get; set; }
    }
}

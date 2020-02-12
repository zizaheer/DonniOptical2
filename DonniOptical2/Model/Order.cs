using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonniOptical2.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhone { get; set; }
        public string DoctorClinicAddress { get; set; }
        public DateTime? DoctorPrescriptionDate { get; set; }
        public string PrescriptionSphereRight { get; set; }
        public string PrescriptionCylRight { get; set; }
        public string PrescriptionAxisRight { get; set; }
        public string PrescriptionAddRight { get; set; }
        public string PrescriptionPrismRight { get; set; }
        public string PrescriptionSphereLeft { get; set; }
        public string PrescriptionCylLeft { get; set; }
        public string PrescriptionAxisLeft { get; set; }
        public string PrescriptionAddLeft { get; set; }
        public string PrescriptionPrismLeft { get; set; }
        public decimal? FrameTotalPrice { get; set; }
        public decimal? LensTotalPrice { get; set; }
        public decimal? OtherAdjustment { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal? HstAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string PaidBy { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? BalanceDue { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiks.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TrayNumber { get; set; }
        public string ModifiedSphereRight { get; set; }
        public string ModifiedCylRight { get; set; }
        public string ModifiedAxisRight { get; set; }
        public string ModifiedAddRight { get; set; }
        public string ModifiedPrismRight { get; set; }
        public string ModifiedSphereLeft { get; set; }
        public string ModifiedCylLeft { get; set; }
        public string ModifiedAxisLeft { get; set; }
        public string ModifiedAddLeft { get; set; }
        public string ModifiedPrismLeft { get; set; }
        public string MeasurementFpdRight { get; set; }
        public string MeasurementNrPdRight { get; set; }
        public string MeasurementOcRight { get; set; }
        public string MeasurementSegRight { get; set; }
        public string MeasurementBlSizeRight { get; set; }
        public string MeasurementFpdLeft { get; set; }
        public string MeasurementNrPdLeft { get; set; }
        public string MeasurementOcLeft { get; set; }
        public string MeasurementSegLeft { get; set; }
        public string MeasurementBlSizeLeft { get; set; }
        public string MeasurementA { get; set; }
        public string MeasurementB { get; set; }
        public string MeasurementED { get; set; }
        public string MeasurementDBL { get; set; }
        public string FrameCode { get; set; }
        public string FrameColor { get; set; }
        public decimal? FrameUnitPrice { get; set; }
        public int? FrameQuantity { get; set; }
        public string LeftLensDescription { get; set; }
        public decimal? LeftLensUnitPrice { get; set; }
        public int? LeftLensQuantity { get; set; }
        public string RightLensDescription { get; set; }
        public decimal? RightLensUnitPrice { get; set; }
        public int? RightLensQuantity { get; set; }

        public string OtherItemDescription { get; set; }
        public decimal? OtherItemUnitPrice { get; set; }
        public int? OtherItemQuantity { get; set; }

    }
}

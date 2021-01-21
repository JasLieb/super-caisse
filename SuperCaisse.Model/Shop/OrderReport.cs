using System;

namespace SuperCaisse.Model
{
    public enum OrderReportStatus
    {
        Created,
        Asked,
        InTransit,
        Delivered,
        Failing,
        Returned
    }

    public class OrderReport
    {
        public OrderReportStatus Status { get; }
        public DateTime OrderDate { get; }
        public DateTime? DeliveryDate { get; }
        
        public int? Note { get; }
        public string Comment { get; }
        public string PhotoFilePath { get; }

        public OrderReport(
            OrderReportStatus status, 
            DateTime orderDate, 
            DateTime? deliveryDate = null,
            int? note = null,
            string comment = "",
            string photoFilePath = ""
        )
        {
            Status = status;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Note = note;
        }
    }
}
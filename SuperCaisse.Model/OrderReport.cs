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
        public DateTime DeliveryDate { get; }
    }
}
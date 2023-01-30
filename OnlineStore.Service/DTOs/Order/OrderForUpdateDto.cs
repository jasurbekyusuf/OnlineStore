using CoworkingBooking.Domain.Enums;

namespace CoworkingBooking.Service.DTOs.Order
{
    public class OrderForUpdateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

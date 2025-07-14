using System;

namespace Hackney.Shared.Tenure.Infrastructure

{
    public class TemporaryAccommodationEmergencyBookingDb
    {
        public bool? DraftBooking { get; set; }
        public bool? IsRentAccountRequired { get; set; }
        public string NoRentAccountReason { get; set; }
        public DateTime? RentLetterSentDate { get; set; }
        public DateTime? RentCardGivenDate { get; set; }
        public DateTime? TenureAcceptedDate { get; set; }
        public bool? IsSection208NoticeSent { get; set; }
    }
}
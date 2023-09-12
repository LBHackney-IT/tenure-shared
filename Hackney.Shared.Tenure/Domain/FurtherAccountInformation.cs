using System;

namespace Hackney.Shared.Tenure.Domain
{
    public class FurtherAccountInformation
    {
        public bool? IsRentAccountRequired { get; set; }
        public string NoRentAccountReason { get; set; }
        public DateTime? RentLetterSentDate { get; set; }
        public DateTime? RentCardGivenDate { get; set; }
        public DateTime? TenureAcceptedDate { get; set; }
        public bool? IsSection208NoticeSent { get; set; }
    }
}

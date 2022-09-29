using System;
using System.Collections.Generic;
using System.Text;

namespace Hackney.Shared.Tenure.Domain
{
    public class FurtherAccountInformation
    {
        public bool? IsRentAccountRequired { get; set; }
        public string NoRentAccountReason { get; set; }
        public DateTime? RentLetterSentDate { get; set; }
        public DateTime? RentCardGivenDate { get; set; }
    }
}

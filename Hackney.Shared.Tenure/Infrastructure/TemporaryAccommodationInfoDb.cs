using System;

namespace Hackney.Shared.Tenure.Infrastructure
{
    public class TemporaryAccommodationInfoDb
    {
        /// <summary>
        /// Represents the stage the Temporary Accomodation tenure is in.
        /// Possible values: Matched | Under Offer | Accepted | Processing | Awaiting Approval | Completed
        /// </summary>
        public string BookingStatus { get; set; }
        public TemporaryAccommodationOfficerDb AssignedOfficer { get; set; }
    }
}

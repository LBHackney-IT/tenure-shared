using System;

namespace Hackney.Shared.Tenure.Infrastructure
{
    public class TemporaryAccommodationInfoDb
    {
        /// <summary>
        /// Represents the stage the Temporary Accomodation tenure is in.
        /// Some possible values for convenient developer reference:
        /// Matched | Under Offer | Accepted | Processing | Awaiting Approval | Completed
        /// 
        /// This list is not guaranteed to stay up to date.
        /// If that is a concern, please reference the Reference Data Google Sheet instead.
        /// </summary>
        public string BookingStatus { get; set; }
        public TemporaryAccommodationOfficerDb AssignedOfficer { get; set; }
    }
}

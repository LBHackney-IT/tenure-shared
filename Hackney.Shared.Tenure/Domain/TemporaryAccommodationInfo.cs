using System;

namespace Hackney.Shared.Tenure.Domain
{
    public class TemporaryAccommodationInfo
    {
        public string BookingStatus { get; set; }
        public TemporaryAccommodationOfficer AssignedOfficer { get; set; }
    }
}

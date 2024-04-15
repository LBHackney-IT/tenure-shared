using System;

namespace Hackney.Shared.Tenure.Boundary.Response
{
    public class TemporaryAccommodationInfoResponse
    {
        public string BookingStatus { get; set; }
        public TemporaryAccommodationOfficerResponse AssignedOfficer { get; set; }
    }
}

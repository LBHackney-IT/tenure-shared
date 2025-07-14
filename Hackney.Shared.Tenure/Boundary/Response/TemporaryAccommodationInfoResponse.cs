using System;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Response
{
    public class TemporaryAccommodationInfoResponse
    {
        public string BookingStatus { get; set; }
        public TemporaryAccommodationOfficerResponse AssignedOfficer { get; set; }
        public TemporaryAccommodationEmergencyBookingResponse EmergencyBooking { get; set; }

    }
}

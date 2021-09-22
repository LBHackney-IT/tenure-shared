using System;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class EditTenureDetailsRequestObject
    {
        public DateTime? StartOfTenureDate { get; set; }
        public DateTime? EndOfTenureDate { get; set; }
        public TenureType TenureType { get; set; }
    }
}

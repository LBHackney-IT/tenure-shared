using Hackney.Shared.Tenure.Domain;
using System;
using System.Collections.Generic;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class UpdateTenureRequestObject
    {
        public Guid Id { get; set; }
        public List<HouseholdMembers> HouseholdMembers { get; set; }
    }
}

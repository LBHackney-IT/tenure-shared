using Hackney.Shared.Tenure.Domain;
using System;
using System.Collections.Generic;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class UpdateTenureRequestObject
    {
        public Guid Id { get; set; }
        public List<HouseholdMembers> HouseholdMembers { get; set; }
        public DateTime? StartOfTenureDate { get; set; }
        public DateTime? EndOfTenureDate { get; set; }
        public TenureType TenureType { get; set; }
        public string TenureSource { get; set; }
        public string PaymentReference { get; set; }
        public Terminated Terminated { get; set; }
        public string FundingSource { get; set; }
        public string NumberOfAdultsInProperty { get; set; }
        public string NumberOfChildrenInProperty { get; set; }
        public bool? HasOffsiteStorage { get; set; }
        public Account Account { get; set; }
        public int? VersionNumber { get; set; }
    }
}

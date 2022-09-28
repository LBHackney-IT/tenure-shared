using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hackney.Shared.Tenure.Domain
{
    public class TenureInformation
    {
        public Guid Id { get; set; }
        public string PaymentReference { get; set; }
        public IEnumerable<HouseholdMembers> HouseholdMembers { get; set; }
        public TenuredAsset TenuredAsset { get; set; }
        public Charges Charges { get; set; }
        public DateTime? StartOfTenureDate { get; set; }
        public DateTime? EndOfTenureDate { get; set; }
        public TenureType TenureType { get; set; }
        public string TenureSource { get; set; }
        [JsonIgnore]
        public bool IsActive => TenureHelpers.IsTenureActive(EndOfTenureDate);

        public bool? IsTenanted { get; set; }
        public Terminated Terminated { get; set; }
        public DateTime? SuccessionDate { get; set; }
        public AgreementType AgreementType { get; set; }
        public DateTime? EvictionDate { get; set; }
        public DateTime? PotentialEndDate { get; set; }
        public IEnumerable<Notices> Notices { get; set; }
        public IEnumerable<LegacyReference> LegacyReferences { get; set; }
        public bool? IsMutualExchange { get; set; }
        public bool? InformHousingBenefitsForChanges { get; set; }
        public bool? IsSublet { get; set; }
        public DateTime? SubletEndDate { get; set; }
        public int? VersionNumber { get; set; }
        public string FundingSource { get; set; }
        public string NumberOfAdultsInProperty { get; set; }
        public string NumberOfChildrenInProperty { get; set; }
        public bool? HasOffsiteStorage { get; set; }
        public Account Account { get; set; }

    }
}

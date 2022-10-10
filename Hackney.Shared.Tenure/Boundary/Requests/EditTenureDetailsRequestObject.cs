using System;
using System.Collections.Generic;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class EditTenureDetailsRequestObject
    {
        public DateTime? StartOfTenureDate { get; set; }
        public DateTime? EndOfTenureDate { get; set; }
        //This is needed by the finance api so adding back in
        public string PaymentReference { get; set; }
        public TenureType TenureType { get; set; }
        public string TenureSource { get; set; }
        public Terminated Terminated { get; set; }
        public string FundingSource { get; set; }
        public int NumberOfAdultsInProperty { get; set; }
        public int NumberOfChildrenInProperty { get; set; }
        public bool? HasOffsiteStorage { get; set; }
        public FurtherAccountInformation FurtherAccountInformation { get; set; }
        public IEnumerable<LegacyReference> LegacyReferences { get; set; }
    }
}

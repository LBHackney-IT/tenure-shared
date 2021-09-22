using System;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Infrastructure;

namespace Hackney.Shared.Tenure.Factories
{
    public static class CreateRequestFactory
    {
        public static TenureInformationDb ToDatabase(this CreateTenureRequestObject createTenureRequestObject)
        {
            return new TenureInformationDb()
            {
                Id = createTenureRequestObject.Id == Guid.Empty ? Guid.NewGuid() : createTenureRequestObject.Id,
                AgreementType = createTenureRequestObject.AgreementType,
                Charges = createTenureRequestObject.Charges,
                EndOfTenureDate = createTenureRequestObject.EndOfTenureDate,
                EvictionDate = createTenureRequestObject.EvictionDate,
                HouseholdMembers = createTenureRequestObject.HouseholdMembers.ToListOrEmpty(),
                InformHousingBenefitsForChanges = createTenureRequestObject.InformHousingBenefitsForChanges,
                IsMutualExchange = createTenureRequestObject.IsMutualExchange,
                IsSublet = createTenureRequestObject.IsSublet,
                IsTenanted = createTenureRequestObject.IsTenanted,
                LegacyReferences = createTenureRequestObject.LegacyReferences.ToListOrEmpty(),
                Notices = createTenureRequestObject.Notices.ToListOrEmpty(),
                PaymentReference = createTenureRequestObject.PaymentReference,
                PotentialEndDate = createTenureRequestObject.PotentialEndDate,
                StartOfTenureDate = createTenureRequestObject.StartOfTenureDate,
                SubletEndDate = createTenureRequestObject.SubletEndDate,
                SuccessionDate = createTenureRequestObject.SuccessionDate,
                TenuredAsset = createTenureRequestObject.TenuredAsset,
                TenureType = createTenureRequestObject.TenureType,
                Terminated = createTenureRequestObject.Terminated
            };
        }
    }
}

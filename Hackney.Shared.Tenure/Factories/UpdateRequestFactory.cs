﻿using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Infrastructure;

namespace Hackney.Shared.Tenure.Factories
{
    public static class UpdateRequestFactory
    {
        public static TenureInformationDb ToDatabase(this UpdateTenureRequestObject updateTenureRequestObject)
        {
            return new TenureInformationDb()
            {
                Id = updateTenureRequestObject.Id,
                StartOfTenureDate = updateTenureRequestObject.StartOfTenureDate,
                EndOfTenureDate = updateTenureRequestObject.EndOfTenureDate,
                TenureType = updateTenureRequestObject.TenureType,
                TenureSource = updateTenureRequestObject.TenureSource,
                Terminated = updateTenureRequestObject.Terminated,
                HouseholdMembers = updateTenureRequestObject.HouseholdMembers.ToListOrNull(),
                LegacyReferences = updateTenureRequestObject.LegacyReferences.ToListOrNull(),
                Notices = null,
                FundingSource = updateTenureRequestObject.FundingSource,
                NumberOfAdultsInProperty = updateTenureRequestObject.NumberOfAdultsInProperty,
                NumberOfChildrenInProperty = updateTenureRequestObject.NumberOfChildrenInProperty,
                HasOffsiteStorage = updateTenureRequestObject.HasOffsiteStorage,
                FurtherAccountInformation = updateTenureRequestObject.FurtherAccountInformation,
                PaymentReference = updateTenureRequestObject.PaymentReference
            };
        }
    }
}

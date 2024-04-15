using System.Collections.Generic;
using System.Linq;
using Hackney.Shared.Tenure.Boundary.Response;
using Hackney.Shared.Tenure.Domain;
using Hackney.Shared.Tenure.Infrastructure;

namespace Hackney.Shared.Tenure.Factories
{
    public static class ResponseFactory
    {
        #region Tenure Information
        public static TenureResponseObject ToResponse(this TenureInformation domain)
        {
            if (domain == null) return null;
            return new TenureResponseObject
            {
                Id = domain.Id,
                Charges = domain.Charges,
                EndOfTenureDate = domain.EndOfTenureDate,
                EvictionDate = domain.EvictionDate,
                HouseholdMembers = domain.HouseholdMembers.ToListOrEmpty(),
                InformHousingBenefitsForChanges = domain.InformHousingBenefitsForChanges,
                IsActive = domain.IsActive,
                IsMutualExchange = domain.IsMutualExchange,
                IsSublet = domain.IsSublet,
                IsTenanted = domain.IsTenanted,
                LegacyReferences = domain.LegacyReferences.ToListOrEmpty(),
                Notices = domain.Notices.ToListOrEmpty(),
                PaymentReference = domain.PaymentReference,
                PotentialEndDate = domain.PotentialEndDate,
                StartOfTenureDate = domain.StartOfTenureDate,
                SubletEndDate = domain.SubletEndDate,
                SuccessionDate = domain.SuccessionDate,
                TenuredAsset = domain.TenuredAsset,
                TenureType = domain.TenureType,
                TenureSource = domain.TenureSource,
                Terminated = domain.Terminated,
                AgreementType = domain.AgreementType,
                FundingSource = domain.FundingSource,
                NumberOfAdultsInProperty = domain.NumberOfAdultsInProperty,
                NumberOfChildrenInProperty = domain.NumberOfChildrenInProperty,
                HasOffsiteStorage = domain.HasOffsiteStorage,
                TempAccommodationInfo = domain.TempAccommodationInfo.ToResponse(),
                FurtherAccountInformation = domain.FurtherAccountInformation
            };
        }

        public static List<TenureResponseObject> ToResponse(this IEnumerable<TenureInformation> domainList)
        {
            if (null == domainList) return new List<TenureResponseObject>();
            return domainList.Select(domain => ToResponse(domain)).ToList();
        }
        #endregion
        #region Temporary Accommodation Information
        public static TemporaryAccommodationOfficerResponse ToResponse(this TemporaryAccommodationOfficer taOfficerDomain)
        {
            if (taOfficerDomain == null) return null;

            return new TemporaryAccommodationOfficerResponse
            {
                FirstName = taOfficerDomain.FirstName,
                LastName = taOfficerDomain.LastName,
                Email = taOfficerDomain.Email
            };
        }

        public static TemporaryAccommodationInfoResponse ToResponse(this TemporaryAccommodationInfo taInfoDomain)
        {
            if (taInfoDomain == null) return null;

            return new TemporaryAccommodationInfoResponse
            {
                BookingStatus = taInfoDomain.BookingStatus,
                AssignedOfficer = taInfoDomain.AssignedOfficer.ToResponse()
            };
        }
        #endregion
    }
}

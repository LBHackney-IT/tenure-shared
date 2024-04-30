using Hackney.Shared.Tenure.Boundary.Response;
using Hackney.Shared.Tenure.Domain;
using Hackney.Shared.Tenure.Infrastructure;

namespace Hackney.Shared.Tenure.Factories
{
    public static class EntityFactory
    {
        #region Tenure Information
        // Entity to Domain
        public static TenureInformation ToDomain(this TenureInformationDb databaseEntity)
        {
            if (databaseEntity == null) return null;

            return new TenureInformation
            {
                Id = databaseEntity.Id,
                Terminated = databaseEntity.Terminated,
                TenureType = databaseEntity.TenureType,
                TenureSource = databaseEntity.TenureSource,
                TenuredAsset = databaseEntity.TenuredAsset,
                SuccessionDate = databaseEntity.SuccessionDate,
                AgreementType = databaseEntity.AgreementType,
                Charges = databaseEntity.Charges,
                EndOfTenureDate = databaseEntity.EndOfTenureDate,
                EvictionDate = databaseEntity.EvictionDate,
                HouseholdMembers = databaseEntity.HouseholdMembers,
                InformHousingBenefitsForChanges = databaseEntity.InformHousingBenefitsForChanges,
                IsMutualExchange = databaseEntity.IsMutualExchange,
                IsSublet = databaseEntity.IsSublet,
                IsTenanted = databaseEntity.IsTenanted,
                LegacyReferences = databaseEntity.LegacyReferences,
                Notices = databaseEntity.Notices,
                PaymentReference = databaseEntity.PaymentReference,
                PotentialEndDate = databaseEntity.PotentialEndDate,
                StartOfTenureDate = databaseEntity.StartOfTenureDate,
                SubletEndDate = databaseEntity.SubletEndDate,
                VersionNumber = databaseEntity.VersionNumber,
                FundingSource = databaseEntity.FundingSource,
                NumberOfAdultsInProperty = databaseEntity.NumberOfAdultsInProperty,
                NumberOfChildrenInProperty = databaseEntity.NumberOfChildrenInProperty,
                HasOffsiteStorage = databaseEntity.HasOffsiteStorage,
                TempAccommodationInfo = databaseEntity.TempAccommodationInfo.ToDomain(),
                FurtherAccountInformation = databaseEntity.FurtherAccountInformation
            };
        }

        // Domain to Entity
        public static TenureInformationDb ToDatabase(this TenureInformation domain)
        {
            if (domain == null) return null;

            return new TenureInformationDb
            {
                Id = domain.Id,
                Terminated = domain.Terminated,
                TenureType = domain.TenureType,
                TenureSource = domain.TenureSource,
                TenuredAsset = domain.TenuredAsset,
                SuccessionDate = domain.SuccessionDate,
                AgreementType = domain.AgreementType,
                Charges = domain.Charges,
                EndOfTenureDate = domain.EndOfTenureDate,
                EvictionDate = domain.EvictionDate,
                HouseholdMembers = domain.HouseholdMembers.ToListOrEmpty(),
                InformHousingBenefitsForChanges = domain.InformHousingBenefitsForChanges,
                IsMutualExchange = domain.IsMutualExchange,
                IsSublet = domain.IsSublet,
                IsTenanted = domain.IsTenanted,
                LegacyReferences = domain.LegacyReferences.ToListOrEmpty(),
                Notices = domain.Notices.ToListOrEmpty(),
                PaymentReference = domain.PaymentReference,
                PotentialEndDate = domain.PotentialEndDate,
                StartOfTenureDate = domain.StartOfTenureDate,
                SubletEndDate = domain.SubletEndDate,
                VersionNumber = domain.VersionNumber,
                FundingSource = domain.FundingSource,
                NumberOfAdultsInProperty = domain.NumberOfAdultsInProperty,
                NumberOfChildrenInProperty = domain.NumberOfChildrenInProperty,
                HasOffsiteStorage = domain.HasOffsiteStorage,
                TempAccommodationInfo = domain.TempAccommodationInfo.ToDatabase(),
                FurtherAccountInformation = domain.FurtherAccountInformation
            };
        }
        #endregion
        #region Temporary Accommodation Information
        // Entity to Domain
        public static TemporaryAccommodationOfficer ToDomain(this TemporaryAccommodationOfficerDb taOfficerEntity)
        {
            if (taOfficerEntity == null) return null;

            return new TemporaryAccommodationOfficer
            {
                Id = taOfficerEntity.Id,
                FirstName = taOfficerEntity.FirstName,
                LastName = taOfficerEntity.LastName,
                Email = taOfficerEntity.Email
            };
        }
        // Entity to Domain
        public static TemporaryAccommodationInfo ToDomain(this TemporaryAccommodationInfoDb taInfoEntity)
        {
            if (taInfoEntity == null) return null;

            return new TemporaryAccommodationInfo
            {
                BookingStatus = taInfoEntity.BookingStatus,
                AssignedOfficer = taInfoEntity.AssignedOfficer.ToDomain()
            };
        }

        // Entity to Domain
        public static TemporaryAccommodationOfficerDb ToDatabase(this TemporaryAccommodationOfficer taOfficerDomain)
        {
            if (taOfficerDomain == null) return null;

            return new TemporaryAccommodationOfficerDb
            {
                Id = taOfficerDomain.Id,
                FirstName = taOfficerDomain.FirstName,
                LastName = taOfficerDomain.LastName,
                Email = taOfficerDomain.Email
            };
        }
        // Entity to Domain
        public static TemporaryAccommodationInfoDb ToDatabase(this TemporaryAccommodationInfo taInfoDomain)
        {
            if (taInfoDomain == null) return null;

            return new TemporaryAccommodationInfoDb
            {
                BookingStatus = taInfoDomain.BookingStatus,
                AssignedOfficer = taInfoDomain.AssignedOfficer.ToDatabase()
            };
        }
        #endregion
    }
}

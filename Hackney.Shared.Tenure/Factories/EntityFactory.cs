using Hackney.Shared.Tenure.Domain;
using Hackney.Shared.Tenure.Infrastructure;

namespace Hackney.Shared.Tenure.Factories
{
    public static class EntityFactory
    {
        public static TenureInformation ToDomain(this TenureInformationDb databaseEntity)
        {
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
                FurtherAccountInformation = databaseEntity.FurtherAccountInformation
            };
        }

        public static TenureInformationDb ToDatabase(this TenureInformation entity)
        {
            return new TenureInformationDb
            {
                Id = entity.Id,
                Terminated = entity.Terminated,
                TenureType = entity.TenureType,
                TenureSource = entity.TenureSource,
                TenuredAsset = entity.TenuredAsset,
                SuccessionDate = entity.SuccessionDate,
                AgreementType = entity.AgreementType,
                Charges = entity.Charges,
                EndOfTenureDate = entity.EndOfTenureDate,
                EvictionDate = entity.EvictionDate,
                HouseholdMembers = entity.HouseholdMembers.ToListOrEmpty(),
                InformHousingBenefitsForChanges = entity.InformHousingBenefitsForChanges,
                IsMutualExchange = entity.IsMutualExchange,
                IsSublet = entity.IsSublet,
                IsTenanted = entity.IsTenanted,
                LegacyReferences = entity.LegacyReferences.ToListOrEmpty(),
                Notices = entity.Notices.ToListOrEmpty(),
                PaymentReference = entity.PaymentReference,
                PotentialEndDate = entity.PotentialEndDate,
                StartOfTenureDate = entity.StartOfTenureDate,
                SubletEndDate = entity.SubletEndDate,
                VersionNumber = entity.VersionNumber,
                FundingSource = entity.FundingSource,
                NumberOfAdultsInProperty = entity.NumberOfAdultsInProperty,
                NumberOfChildrenInProperty = entity.NumberOfChildrenInProperty,
                HasOffsiteStorage = entity.HasOffsiteStorage,
                FurtherAccountInformation = entity.FurtherAccountInformation
            };
        }
    }
}

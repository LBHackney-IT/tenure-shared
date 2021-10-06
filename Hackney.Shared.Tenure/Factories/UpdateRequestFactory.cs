using Hackney.Shared.Tenure.Boundary.Requests;
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
                HouseholdMembers = updateTenureRequestObject.HouseholdMembers.ToListOrNull(),
                LegacyReferences = null,
                Notices = null
            };
        }
    }
}

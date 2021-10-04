using System;
using System.Text;

namespace Hackney.Shared.Tenure.Domain
{
    public class HouseholdMembers
    {
        public Guid Id { get; set; }

        public HouseholdMembersType Type { get; set; }

        public string FullName { get; set; }

        public bool IsResponsible { get; set; }

        public DateTime DateOfBirth { get; set; }
        public PersonTenureType PersonTenureType { get; set; }

        public override bool Equals(object obj)
        {
            if (GetType() != obj?.GetType()) return false;
            var otherObj = (HouseholdMembers)obj;
            return otherObj != null
                && Id.Equals(otherObj.Id)
                && Type.Equals(otherObj.Type)
                && (String.Compare(FullName, otherObj.FullName) == 0)
                && IsResponsible.Equals(otherObj.IsResponsible)
                && DateOfBirth.Equals(otherObj.DateOfBirth)
                && PersonTenureType.Equals(otherObj.PersonTenureType);
        }

        public override int GetHashCode()
        {
            StringBuilder builder = new StringBuilder();
            return builder.Append(Id.ToString())
                          .Append(Type)
                          .Append(FullName)
                          .Append(IsResponsible)
                          .Append(DateOfBirth)
                          .Append(PersonTenureType)
                          .ToString()
                          .GetHashCode();
        }
    }
}

namespace Hackney.Shared.Tenure.Domain
{
    public class Charges
    {
        public float Rent { get; set; }

        public float CurrentBalance { get; set; }

        public string BillingFrequency { get; set; }

        public float ServiceCharge { get; set; }

        public float OtherCharges { get; set; }

        public float CombinedServiceCharges { get; set; }

        public float CombinedRentCharges { get; set; }

        public float TenancyInsuranceCharge { get; set; }

        public float OriginalRentCharge { get; set; }

        public float OriginalServiceCharge { get; set; }

        /// <summary>
        /// A separately-recorded storage charge
        /// eg. for tenants using the council's storage facility.
        /// </summary>
        public float? StorageCharge { get; set; }

        /// <summary>
        /// An separately-recorded adjustment made to the standard rent,
        /// usually a discount (eg. -20f).
        /// </summary>
        public float? RentAdjustment { get; set; }

        /// <summary>
        /// A reason given for the <see cref="RentAdjustment"/>
        /// </summary>
        public string RentAdjustmentReason { get; set; }
    }
}

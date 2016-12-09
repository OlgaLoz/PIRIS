namespace Lab1.Models
{
    public enum DepositCreditType : byte
    {
        CallableDeposit = 1,
        UncallableDeposit = 2,
        AnnuityPaymentCredit = 3,
        DifferentialPaymentCredit = 4
    }
}
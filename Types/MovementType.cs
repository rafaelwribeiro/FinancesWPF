using System.ComponentModel;

namespace FinancesWPF.Types
{
    public enum MovementType
    {
        [Description("C")]
        Credit = 0,
        [Description("D")]
        Debit = 1
    }
}

using FinancesWPF.Types;
using System;

namespace FinancesWPF.Entities
{
    public class Movement
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual decimal Value { get; set; }
        public virtual string Description { get; set; }
        public virtual MovementType Type { get; set; }
        public virtual Category Category { get; set; }
    }
}

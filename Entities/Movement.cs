using FinancesWPF.Types;
using System;

namespace FinancesWPF.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public MovementType Type { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

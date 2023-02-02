using FinancesWPF.Types;
using System;

namespace FinancesWPF.DTO.Movement
{
    public class CreateMovementDTO
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public MovementType Type { get; set; }
        public int CategoryId { get; set; }
    }
}

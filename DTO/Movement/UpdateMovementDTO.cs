using FinancesWPF.DTO.Category;
using FinancesWPF.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesWPF.DTO.Movement
{
    public class UpdateMovementDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public MovementType Type { get; set; }
        public int CategoryId { get; set; }
        public ReadCategoryDTO Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesWPF.DTO.Category
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "ID é obrigatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Name { get; set; }
    }
}

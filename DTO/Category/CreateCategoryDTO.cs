using System.ComponentModel.DataAnnotations;

namespace FinancesWPF.DTO.Category
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Name { get; set; }
    }
}

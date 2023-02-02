using FinancesWPF.DTO.Category;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using Mapster;

namespace FinancesWPF.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryRespository _categoryRepository;

        public CategoryController(ICategoryRespository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ReadCategoryDTO Create(CreateCategoryDTO dto)
        {
            var category = dto.Adapt<Category>();
            var createdCategory = _categoryRepository.Create(category);
            return createdCategory.Adapt<ReadCategoryDTO>();
        }
    }
}

using FinancesWPF.DTO.Category;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesWPF.Controllers
{
    public class CategoryController
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(CreateCategoryDTO dto)
        {
            var category = dto.Adapt<Category>();
            var createdCategory = _categoryRepository.Create(category);
        }
    }
}

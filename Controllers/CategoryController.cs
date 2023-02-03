using FinancesWPF.DTO.Category;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using Mapster;
using System;
using System.Collections.Generic;

namespace FinancesWPF.Controllers
{
    public class CategoryController
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ReadCategoryDTO Create(CreateCategoryDTO dto)
        {
            var category = dto.Adapt<Category>();
            var createdCategory = _categoryRepository.Create(category);
            return createdCategory.Adapt<ReadCategoryDTO>();
        }

        public List<ReadCategoryDTO> GetAll()
        {
            var list = _categoryRepository.GetAll();
            return list.Adapt<List<ReadCategoryDTO>>();
        }
    }
}

using FinancesWPF.DTO.Category;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using FinancesWPF.Validators;
using Mapster;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancesWPF.Controllers
{
    public class CategoryController
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ICustomValidator _validator;
        

        public CategoryController(IRepository<Category> categoryRepository, ICustomValidator validator)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
        }

        public ReadCategoryDTO Create(CreateCategoryDTO dto)
        {
            _validator.Validate(dto);
            var category = dto.Adapt<Category>();
            var createdCategory = _categoryRepository.Create(category);
            return createdCategory.Adapt<ReadCategoryDTO>();
        }

        public void Update(UpdateCategoryDTO dto)
        {
            _validator.Validate(dto);
            var category = _categoryRepository.Get(dto.Id);
            dto.Adapt(category);
            _categoryRepository.Update(category);
        }

        public List<ReadCategoryDTO> GetAll()
        {
            var list = _categoryRepository.GetAll();
            return list.Adapt<List<ReadCategoryDTO>>();
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}

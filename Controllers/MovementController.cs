using FinancesWPF.DTO.Category;
using FinancesWPF.DTO.Movement;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using Mapster;
using System;
using System.Collections.Generic;

namespace FinancesWPF.Controllers
{
    public class MovementController
    {
        private readonly IRepository<Movement> _movementRepository;
        private readonly IRepository<Category> _categoryRepository;

        public MovementController(IRepository<Movement> movementRepository, IRepository<Category> categoryRepository)
        {
            _movementRepository = movementRepository;
            _categoryRepository = categoryRepository;
        }

        public ReadMovementDTO Create(CreateMovementDTO contract)
        {
            var movement = contract.Adapt<Movement>();
            movement.Category = _categoryRepository.Get(contract.Category?.Id ?? 0);
            var createdMovement = _movementRepository.Create(movement);
            return createdMovement.Adapt<ReadMovementDTO>();
        }

        public void Update(UpdateMovementDTO contract)
        {
            var movement = _movementRepository.Get(contract.Id);
            var category = _categoryRepository.Get(contract.Category?.Id ?? 0);
            contract.Adapt(movement);
            movement.Category = category;
            _movementRepository.Update(movement);
        }

        public List<ReadMovementDTO> GetAll()
        {
            var movements = _movementRepository.GetAll();
            var list = movements.Adapt<List<ReadMovementDTO>>();
            list.ForEach(x =>
            {
                x.Category = _categoryRepository.Get(x.CategoryId).Adapt<ReadCategoryDTO>();
            });
            return list;
        }

        public void Delete(int id)
        {
            _movementRepository.Delete(id);
        }
    }
}
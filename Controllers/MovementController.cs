using FinancesWPF.DTO.Movement;
using FinancesWPF.Entities;
using FinancesWPF.Repositories;
using Mapster;

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

        public ReadMovementDTO AddMovement(CreateMovementDTO contract)
        {
            var movement = contract.Adapt<Movement>();
            movement.Category = _categoryRepository.Get(contract.CategoryId);
            var createdMovement = _movementRepository.Create(movement);
            return createdMovement.Adapt<ReadMovementDTO>();
        }
    }
}
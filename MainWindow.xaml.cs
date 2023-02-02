using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using FinancesWPF.DTO.Movement;
using System.Windows;
using Unity;

namespace FinancesWPF
{
    public partial class MainWindow : Window
    {
        private IUnityContainer container;
        private CategoryController categoryController;
        private MovementController movementController;

        public MainWindow()
        {
            InitializeComponent();

            container = UnityConfig.GetContainer();
            categoryController = container.Resolve<CategoryController>();
            movementController = container.Resolve<MovementController>();

            var createdCategory = categoryController.Create(new CreateCategoryDTO
            {
                Name= "Category",
            });


            movementController.AddMovement(new CreateMovementDTO
            {
                Description = "teste",
                CategoryId= createdCategory.Id,
            });
        }
    }
}


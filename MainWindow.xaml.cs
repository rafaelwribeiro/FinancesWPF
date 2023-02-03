using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using FinancesWPF.DTO.Movement;
using FinancesWPF.Views;
using System;
using System.Windows;
using System.Windows.Input;
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


            //CreateSomeData();
             
            CommandBinding binding = new CommandBinding(ApplicationCommands.Open, OpenCommandHandler);
            CommandBindings.Add(binding);
        }

        private void CreateSomeData()
        {
            var createdCategory = categoryController.Create(new CreateCategoryDTO
            {
                Name = "Category",
            });


            movementController.Create(new CreateMovementDTO
            {
                Description = "teste",
                CategoryId = createdCategory.Id,
            });
        }

        private void OpenCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("Navigating to " + e.Parameter);
            ContentFrame.NavigationService.Navigate(new Uri($"Views/{e.Parameter}Page.xaml", UriKind.Relative));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Source = new Uri("Views/HomePage.xaml", UriKind.Relative);
        }
    }
}


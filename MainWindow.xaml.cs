using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using System.Windows;
using Unity;

namespace FinancesWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private CategoryController controller;
        
        public MainWindow()
        {
            InitializeComponent();


            controller = UnityConfig.GetInstance().Resolve<CategoryController>();

            controller.Create(new CreateCategoryDTO
            {
                Name= "Category",
            });

        }


    }
}

using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace FinancesWPF.Views
{
    /// <summary>
    /// Interação lógica para CategoryPage.xam
    /// </summary>
    public partial class CategoryPage : Page
    {
        private CategoryController categoryController;
        public List<ReadCategoryDTO> Categories { get; set; }
        public CategoryPage()
        {
            InitializeComponent();
            categoryController = UnityConfig.Resolve<CategoryController>();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Categories = categoryController.GetAll();
            if (Categories == null) return;
            dataGrid.ItemsSource = Categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createdCategory = categoryController.Create(new CreateCategoryDTO
            {
                Name = "Category",
            });
            LoadData();
        }
    }
}

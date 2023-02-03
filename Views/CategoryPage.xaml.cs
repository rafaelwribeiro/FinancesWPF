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
using System.Windows.Markup;
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
            NavigationService.Navigate(new CategoryFormPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var data = GetRowDataContext(sender, e);

            int id = data.Id;
            ExecuteDeleteMethod(id);
        }

        private void ExecuteDeleteMethod(int id)
        {
            categoryController.Delete(id);
            LoadData();
        }

        public ReadCategoryDTO GetRowDataContext(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return null;

            DataGridRow row = DataGridRow.GetRowContainingElement(button);
            if (row == null) return null;

            ReadCategoryDTO data = row.DataContext as ReadCategoryDTO;
            return data;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var data = GetRowDataContext(sender, e);
            int id = data.Id;
            NavigationService.Navigate(new CategoryFormPage(data));
        }
    }
}

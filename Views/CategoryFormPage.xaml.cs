using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using FluentNHibernate.Cfg;
using Mapster;
using System;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;

namespace FinancesWPF.Views
{

    public partial class CategoryFormPage : Page
    {
        private CategoryController _categoryController { get; set; }
        private ReadCategoryDTO _data { get; set; }
        public CategoryFormPage()
        {
            InitializeComponent();
            _data = new ReadCategoryDTO();
            Setup();
        }

        public CategoryFormPage(ReadCategoryDTO data)
        {
            InitializeComponent();
            _data = data;
            Setup();
        }

        private void Setup()
        {
            _categoryController = UnityConfig.Resolve<CategoryController>();
            this.DataContext = _data;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var isEditing = _data.Id != 0;
                if (isEditing)
                    _categoryController.Update(_data.Adapt<UpdateCategoryDTO>());
                else
                    _categoryController.Create(_data.Adapt<CreateCategoryDTO>());
                this.NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

using FinancesWPF.Controllers;
using FinancesWPF.DTO.Category;
using FinancesWPF.DTO.Movement;
using FinancesWPF.Entities;
using FinancesWPF.Types;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinancesWPF.Views
{
    public partial class MovementFormPage : Page
    {
        private MovementController _movementController { get; set; }
        private CategoryController _categoryController { get; set; }
        private ReadMovementDTO _data { get; set; }
        public List<ReadCategoryDTO> Categories { get; set; }
        public MovementFormPage()
        {
            InitializeComponent();
            DatePicker.IsEnabled = false;
            _data = new ReadMovementDTO();
            _data.Date = DateTime.Now;
            Setup();
            
        }

        private void Setup()
        {
            _movementController = UnityConfig.Resolve<MovementController>();
            _categoryController = UnityConfig.Resolve<CategoryController>();
            Categories = _categoryController.GetAll();
            DataContext = _data;

            TypeComboBox.SelectedIndex = 0;

            CategoryComboBox.ItemsSource = Categories;
            CategoryComboBox.DisplayMemberPath = "Name";
            CategoryComboBox.SelectedValuePath = "Id";
            CategoryComboBox.SelectedIndex = 0; 
        }

        public MovementFormPage(ReadMovementDTO data)
        {
            InitializeComponent();
            _data = data;
            Setup();
            TypeComboBox.SelectedIndex = (int)data.Type;
            //CategoryComboBox.SelectedItem = Categories.FirstOrDefault(x => x.Id == data.CategoryId);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var isEditing = _data.Id != 0;
                _data.Category = CategoryComboBox.SelectedItem as ReadCategoryDTO;
                _data.Type = (MovementType) TypeComboBox.SelectedIndex;

                if(isEditing)
                    _movementController.Update(_data.Adapt<UpdateMovementDTO>());
                else
                    _movementController.Create(_data.Adapt<CreateMovementDTO>());
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

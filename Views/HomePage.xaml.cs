using FinancesWPF.Controllers;
using FinancesWPF.DTO.Movement;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FinancesWPF.Views
{
    public partial class HomePage : Page
    {
        private MovementController movementController;
        public List<ReadMovementDTO> Movements { get; set; }
        public HomePage()
        {
            InitializeComponent();
            movementController = UnityConfig.Resolve<MovementController>();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Movements = movementController.GetAll();
            if (Movements == null) return;
            dataGrid.ItemsSource = Movements;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var data = GetRowDataContext(sender);
            int id = data.Id;
            ExecuteDeleteMethod(id);
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var data = GetRowDataContext(sender);

            NavigationService.Navigate(new MovementFormPage(data));
        }

        private void ExecuteDeleteMethod(int id)
        {
            movementController.Delete(id);
            LoadData();
        }

        private ReadMovementDTO GetRowDataContext(object sender)
        {
            Button button = sender as Button;
            if (button == null) return null;

            DataGridRow row = DataGridRow.GetRowContainingElement(button);
            if (row == null) return null;

            ReadMovementDTO data = row.DataContext as ReadMovementDTO;
            return data;
        }

        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MovementFormPage());
        }
    }
}

using BLAPI;

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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddLineWindow.xaml
    /// </summary>
    public partial class AddLineWindow : Window
    {
        IBL bl;
        BO.Line lineToAdd;
        public AddLineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            AddLineGrid.DataContext = new BO.Line();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            RefreshButton.IsEnabled = false;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineGrid.DataContext = new BO.Line();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            RefreshButton.IsEnabled = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lineToAdd = AddLineGrid.DataContext as BO.Line;
                if (lineToAdd != null && lineToAdd.Code > 0)
                {
                    bl.AddLine(lineToAdd);
                    MessageBox.Show("succeeded", "AddLine", MessageBoxButton.OK);
                    AddLineGrid.DataContext = new BO.Line();
                    areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
                    RefreshButton.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

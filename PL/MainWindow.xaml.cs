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

using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL();
        BO.User myUser= new BO.User();
        public MainWindow()
        {
            InitializeComponent();
            gridUser.DataContext = myUser;
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myUser = gridUser.DataContext as BO.User;
                if (myUser != null)
                {
                    BO.User user = bl.GetUser(myUser.UserName, myUser.Password);
                    if (user.Admin == true)
                    {
                        AdminWindow win = new AdminWindow(bl, true);
                        win.Show();
                    }
                    else
                    {
                        AdminWindow win = new AdminWindow(bl, false);
                        win.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("User not found, click NEW to create a new account!", "Not Seccssed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gridUser.DataContext = new BO.User();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            myUser = gridUser.DataContext as BO.User;
            try
            {
                if (myUser != null && myUser.UserName != null && myUser.Password != null)
                {
                    bl.AddUser(myUser);
                    AdminWindow win = new AdminWindow(bl, false);
                    win.ShowDialog();
                }
                else
                {
                    MessageBox.Show("you need to enter a name and password", "Not Seccssed", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch
            {
                MessageBox.Show("The name is already exist", "Not Seccssed", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}

using kursach.user;
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

namespace kursach.admin
{
    /// <summary>
    /// Логика взаимодействия для panel.xaml
    /// </summary>
    public partial class panel : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        public panel(users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                userslist window = new userslist(user);
                window.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                materials window = new materials(user);
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                materials window = new materials(user);
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using kursach.admin;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.users.FirstOrDefault(x=>x.login == login.Text && x.password == password.Text);

            try
            {
                if (user != null)
                {
                    if (user.type == 1)
                    {
                        materials window = new materials(user);
                        window.Show();
                        this.Close();
                    }
                    else if (user.type == 2)
                    {
                        panel window = new panel(user);
                        window.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newuser = db.users.FirstOrDefault(x=>x.login == reg_login.Text && x.password == reg_password.Text && x.fio == fio.Text);

            try
            {
                if (newuser == null)
                {
                    users users = new users
                    {
                        login = reg_login.Text,
                        password = reg_password.Text,
                        fio = fio.Text,
                        type = 1
                    };
                    db.users.Add(users);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь зарегистрирован");
                    tabcontrol.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

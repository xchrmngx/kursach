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
    /// Логика взаимодействия для userslist.xaml
    /// </summary>
    public partial class userslist : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        public userslist(users user)
        {
            InitializeComponent();
            this.user = user;

            var users = db.users.ToList();
            List.ItemsSource = users.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                panel window = new panel(user);
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
            var selectedUser = List.SelectedItem as users;

            if (selectedUser != null)
            {
                if (selectedUser.id == user.id)
                {
                    MessageBox.Show("Самого себя изменить нельзя");
                }
                else
                {
                    try
                    {
                        if (selectedUser.type == 1)
                        {
                            selectedUser.type = 2;
                            db.SaveChanges();

                            MessageBox.Show($"Тип пользователя {selectedUser.fio} изменен на 2.");
                            List.ItemsSource = db.users.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Тип пользователя уже установлен на 2.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Сперва выберите пользователя для редактирования");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedUser = List.SelectedItem as users;

            if (selectedUser != null)
            {
                if (selectedUser.id == user.id)
                {
                    MessageBox.Show("Самого себя изменить нельзя");
                }
                else
                {
                    try
                    {
                        if (selectedUser.type == 2)
                        {
                            selectedUser.type = 1;
                            db.SaveChanges();

                            MessageBox.Show($"Тип пользователя {selectedUser.fio} изменен на 1.");
                            List.ItemsSource = db.users.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Тип пользователя уже установлен на 1.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Сперва выберите пользователя для редактирования");
            }
        }
    }
}

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

namespace kursach.f1
{
    /// <summary>
    /// Логика взаимодействия для f1page3.xaml
    /// </summary>
    public partial class f1page3 : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        material_type selectedType;
        public f1page3(users user, material_type selectedType)
        {
            InitializeComponent();
            this.user = user;
            this.selectedType = selectedType;

            if (user.type == 1)
            {
                text.IsReadOnly = true;
                save.Visibility = Visibility.Hidden;
            }
            if (user.type == 2)
            {
                text.IsReadOnly = false;
                save.Visibility = Visibility.Visible;
                text.BorderThickness = new Thickness(1);
            }

            LoadData();
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                if (selectedType.preview != null)
                {
                    string savePath = System.IO.Path.GetFullPath(@"..\\..\\img");
                    savePath = savePath + "\\" + selectedType.preview;
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.UriSource = new Uri(savePath);
                    bm.EndInit();
                    IMG.Source = bm;
                }
                else
                {
                    MessageBox.Show("Фото нетб");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                List<material> materials = db.material
                    .Where(m => m.type == selectedType.id && m.page == 3)
                    .ToList();

                foreach (var material in materials)
                {
                    text.Text = material.name;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                f1page4 window = new f1page4(user, selectedType);
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
                f1page2 window = new f1page2(user, selectedType);
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
                var material = db.material.FirstOrDefault(m => m.type == selectedType.id && m.page == 3);

                if (material != null)
                {
                    // Обновляем поле name выбранного материала
                    material.name = text.Text;

                    // Сохраняем изменения в базе данных
                    db.SaveChanges();

                    MessageBox.Show("Изменения успешно сохранены!");
                }
                else
                {
                    MessageBox.Show("Материал не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

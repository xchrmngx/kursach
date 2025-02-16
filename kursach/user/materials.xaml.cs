using kursach.f1;
using kursach.tests;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace kursach.user
{
    /// <summary>
    /// Логика взаимодействия для materials.xaml
    /// </summary>
    public partial class materials : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        List<material_type> type;
        material_type selectedType;
        string imageSource, imageName;
        public materials(users user)
        {
            InitializeComponent();
            this.user = user;

            type = db.material_type.ToList();

            AddList(type);



            if (user.type == 1)
            {
                opisanie.IsReadOnly = true;
                nazvanie.IsReadOnly = true;
                addnew.Visibility = Visibility.Hidden;
            }
            else if (user.type == 2)
            {
                opisanie.IsReadOnly = false;
                nazvanie.IsReadOnly = false;
                addnew.Visibility = Visibility.Visible;
            }
        }

        private void AddList(List<material_type> type)
        {
            try
            {
                typelist.Items.Clear();
                for (int i = 0; i < type.Count; i++)
                {
                    WrapPanel wp = new WrapPanel();
                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                    Label lb = new Label();

                    wp.Height = 100;
                    wp.Width = 300;

                    lb.Content = type[i].type_name;
                    lb.Foreground = Brushes.Black;
                    string savePath = System.IO.Path.GetFullPath(@"..\\..\\img");
                    savePath = savePath + "\\" + type[i].preview;
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.UriSource = new Uri(savePath);
                    bm.EndInit();
                    img.Source = bm;

                    img.MouseDown += new MouseButtonEventHandler(MyImage_MouseDown);

                    img.Height = 100;
                    img.Width = 100;

                    img.Uid = type[i].id.ToString();

                    wp.Children.Add(img);
                    wp.Children.Add(lb);
                    typelist.Items.Add(wp);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MyImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Windows.Point mousePoint = Mouse.GetPosition(this);
                IInputElement element = InputHitTest(mousePoint);
                string elementName = (element as FrameworkElement)?.Uid;

                int id = Convert.ToInt32(elementName);

                selectedType = type.Find(x => x.id == id);
                string savePath = System.IO.Path.GetFullPath(@"..\\..\\img");
                savePath = savePath + "\\" + selectedType.preview;
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(savePath);
                bm.EndInit();
                IMG.Source = bm;
                nazvanie.Text = selectedType.type_name;
                opisanie.Text = selectedType.description;

                var test = db.test.FirstOrDefault(t => t.material_id == selectedType.id);
                if (test != null)
                {
                    var historyEntry = db.history
                        .FirstOrDefault(h => h.test_id == test.id && h.user_id == user.id);

                    if (historyEntry != null)
                    {
                        int totalQuestions = db.questions.Count(q => q.test_id == test.id);
                        result.Content = "Этот тест уже пройден";
                        count.Content = $"Правильных ответов: {historyEntry.score}/{totalQuestions}";
                    }
                    else
                    {
                        result.Content = "Тест ещё не пройден.";
                        count.Content = "";
                    }
                }
                else
                {
                    result.Content = "Теста нет.";
                    count.Content = "";
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
                if (selectedType != null)
                {
                    f1page1 window = new f1page1(user, selectedType);
                    window.Show();
                    this.Close();
                }
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
                if (selectedType != null)
                {
                    var test = db.test.FirstOrDefault(t => t.material_id == selectedType.id);
                    if (test != null)
                    {
                        var historyEntry = db.history
                            .FirstOrDefault(h => h.test_id == test.id && h.user_id == user.id);

                        if (historyEntry != null && historyEntry.score > 3)
                        {
                            MessageBoxResult result = MessageBox.Show(
                            "Вы уверены, что хотите пройти тест повторно?",
                            "подтверждение действия",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                test1 window = new test1(user, selectedType);
                                window.Show();
                                this.Close();
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            test1 window = new test1(user, selectedType);
                            window.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            typelist.UnselectAll();
            IMG.Source = null;
            opisanie.Text = null;
            nazvanie.Text = null;
            opisanie.BorderThickness = new Thickness(0);
            nazvanie.BorderThickness = new Thickness(0);
            result.Content = "";
            count.Content = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == true)
            {
                IMG.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                imageName = openFileDialog.SafeFileName;
                imageSource = openFileDialog.FileName;
            }

            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(imageSource);
            img.EndInit();

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(img));

            string imagePath = System.IO.Path.GetFullPath(@"..\\..\\img") + "\\" + imageName;

            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }

        private void typelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (typelist.SelectedItem != null)
                {
                    read.Visibility = Visibility.Visible;
                    test.Visibility = Visibility.Visible;
                    reset.Visibility = Visibility.Visible;
                    if (user.type == 2)
                    {
                        save.Visibility = Visibility.Visible;
                        addpreview.Visibility = Visibility.Visible;
                        opisanie.BorderThickness = new Thickness(1);
                        nazvanie.BorderThickness = new Thickness(1);
                    }

                }
                else if (typelist.SelectedItem == null)
                {
                    read.Visibility = Visibility.Hidden;
                    test.Visibility = Visibility.Hidden;
                    reset.Visibility = Visibility.Hidden;
                    save.Visibility = Visibility.Hidden;
                    addpreview.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (selectedType != null)
                {
                    selectedType.type_name = nazvanie.Text;
                    selectedType.description = opisanie.Text;
                    string imagePath = IMG.Source.ToString();
                    string fileName = System.IO.Path.GetFileName(new Uri(imagePath).LocalPath);
                    selectedType.preview = fileName;

                    db.SaveChanges();
                    MessageBox.Show("Изменения внесены");
                    AddList(type);
                }

                else
                {

                    string imagePath = IMG.Source.ToString();
                    string fileName = System.IO.Path.GetFileName(new Uri(imagePath).LocalPath);

                    material_type newmat = new material_type
                    {
                        type_name = nazvanie.Text,
                        description = opisanie.Text,
                        preview = fileName
                    };

                    db.material_type.Add(newmat);
                    db.SaveChanges();
                    MessageBox.Show("Материал добавлен");
                    AddList(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            read.Visibility = Visibility.Visible;
            test.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
            addpreview.Visibility = Visibility.Visible;
            opisanie.BorderThickness = new Thickness(1);
            nazvanie.BorderThickness = new Thickness(1);
        }
    }
}

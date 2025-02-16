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

namespace kursach.tests
{
    /// <summary>
    /// Логика взаимодействия для test5.xaml
    /// </summary>
    public partial class test5 : Window
    {
        aaaaaaaEntities db = new aaaaaaaEntities();
        users user;
        material_type selectedType;
        private int currentQuestionIndex = 4;
        private List<questions> loadedQuestions = new List<questions>();
        private int correctAnswers;
        public test5(users user, material_type selectedType, int correctAnswers)
        {
            InitializeComponent();
            this.user = user;
            this.selectedType = selectedType;
            this.correctAnswers = correctAnswers;

            LoadData();

            if (user.type == 1)
            {
                save.Visibility = Visibility.Hidden;
                variant1.Visibility = Visibility.Hidden;
                variant2.Visibility = Visibility.Hidden;
                variant3.Visibility = Visibility.Hidden;
                answer.Visibility = Visibility.Hidden;
                otvet1.Visibility = Visibility.Hidden;
                otvet2.Visibility = Visibility.Hidden;
                otvet3.Visibility = Visibility.Hidden;
                otvet.Visibility = Visibility.Hidden;
            }
            else if (user.type == 2)
            {
                save.Visibility = Visibility.Visible;
                option1.Visibility = Visibility.Hidden;
                option2.Visibility = Visibility.Hidden;
                option3.Visibility = Visibility.Hidden;

                if (option1.Content != null && option2.Content != null && option3.Content != null)
                {
                    variant1.Text = option1.Content.ToString();
                    variant2.Text = option2.Content.ToString();
                    variant3.Text = option3.Content.ToString();
                }
            }
        }

        private void LoadData()
        {
            try
            {
                // Находим тест, связанный с текущим материалом
                var test = db.test.FirstOrDefault(t => t.material_id == selectedType.id);

                if (test != null)
                {
                    // Загружаем все вопросы, связанные с тестом
                    loadedQuestions = db.questions.Where(q => q.test_id == test.id).ToList();

                    if (loadedQuestions.Any())
                    {
                        // Отображаем первый вопрос
                        DisplayQuestion(currentQuestionIndex);
                    }
                    else
                    {
                        MessageBox.Show("Для данного материала нет вопросов.");
                    }
                }
                else
                {
                    MessageBox.Show("Для данного материала нет тестов.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index >= 0 && index < loadedQuestions.Count)
            {
                var question = loadedQuestions[index];

                text.Text = question.question;

                option1.Content = question.variant1;
                option2.Content = question.variant2;
                option3.Content = question.variant3;
                answer.Text = question.answer;

                option1.IsChecked = false;
                option2.IsChecked = false;
                option3.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (user.type == 1)
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Вы уверены, что хотите завершить тест досрочно?",
                    "подтверждение действия",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("зря");
                        materials window = new materials(user);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("атлишна, продолжайте");
                    }
                }
                else if (user.type == 2)
                {
                    materials window = new materials(user);
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
                if (user.type == 1)
                {
                    if (currentQuestionIndex >= 0 && currentQuestionIndex < loadedQuestions.Count)
                    {
                        // Получаем текущий вопрос
                        var currentQuestion = loadedQuestions[currentQuestionIndex];

                        // Проверяем, какой вариант ответа выбран
                        string selectedAnswer = null;
                        if (option1.IsChecked == true)
                            selectedAnswer = option1.Content.ToString();
                        else if (option2.IsChecked == true)
                            selectedAnswer = option2.Content.ToString();
                        else if (option3.IsChecked == true)
                            selectedAnswer = option3.Content.ToString();

                        // Сравниваем выбранный ответ с правильным
                        if (!string.IsNullOrEmpty(selectedAnswer) && selectedAnswer == currentQuestion.answer)
                        {
                            correctAnswers++;
                            MessageBox.Show($"Ответ правильный! Тест завершен! Правильных ответов: {correctAnswers}/{loadedQuestions.Count}.",
                                            "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Ответ неправильный! Тест завершен! Правильных ответов: {correctAnswers}/{loadedQuestions.Count}.",
                                            "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }


                        // Проверяем наличие существующего результата
                        var testResult = db.history
                            .FirstOrDefault(x => x.user_id == user.id && x.test_id == currentQuestion.test_id);

                        bool isPassed = correctAnswers >= 3;

                        if (testResult != null)
                        {
                            // Обновляем существующий результат
                            testResult.date = DateTime.Now;
                            testResult.score = correctAnswers;
                            testResult.result = isPassed ? "Сдан" : "Не сдан";
                        }
                        else
                        {
                            // Добавляем новый результат
                            db.history.Add(new history
                            {
                                user_id = user.id,
                                test_id = currentQuestion.test_id,
                                date = DateTime.Now,
                                score = correctAnswers,
                                result = isPassed ? "Сдан" : "Не сдан"
                            });
                        }

                        // Сохраняем изменения
                        db.SaveChanges();

                        MessageBox.Show("Результат сохранен");

                        // Открываем окно материалов
                        materials window = new materials(user);
                        window.Show();
                        this.Close();
                    }
                }
                else if (user.type == 2)
                {
                    materials window = new materials(user);
                    window.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentQuestionIndex >= 0 && currentQuestionIndex < loadedQuestions.Count)
                {
                    var currentQuestion = loadedQuestions[currentQuestionIndex];

                    // Обновляем данные текущего вопроса из интерфейса
                    currentQuestion.question = text.Text;
                    currentQuestion.variant1 = variant1.Text;
                    currentQuestion.variant2 = variant2.Text;
                    currentQuestion.variant3 = variant3.Text;
                    currentQuestion.answer = answer.Text;

                    // Сохраняем изменения в базе данных
                    db.SaveChanges();

                    MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Невозможно сохранить изменения: текущий вопрос не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

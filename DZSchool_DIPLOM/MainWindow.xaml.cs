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

namespace DZSchool_DIPLOM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindow mainwindow;
        SchoolDZEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new SchoolDZEntities();
            
        }
        int Kek = 0;
        int id;

        private void EnterInSys(object sender, RoutedEventArgs e)
        {

            try
            {
                int tabNam = Convert.ToInt32(LoginW.Text);
                string pass = PasswordW.Text;

                Pupil pupil = context.Pupil.ToList().Find(x => x.id == tabNam);
                Teachers teachers = context.Teachers.ToList().Find(x => x.id == tabNam);
                if (pupil == null)
                {
                    LoginW.Background = new SolidColorBrush(Colors.Red);
                    PasswordW.Background = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Для входа нужно заполнить обе строки!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    if (pupil.Password.Equals(pass))
                    {
                        int Kek = 0;
                        Kek = 1;
                        id = pupil.id;
                        LoginW.Background = new SolidColorBrush(Colors.Green);
                        PasswordW.Background = new SolidColorBrush(Colors.Green);
                        MessageBox.Show("Пароль верный! Выполняется вход!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window1 window1 = new Window1(teachers, pupil, this, Kek, id);
                        window1.Show();
                        
                    }
                    else
                    {
                        PasswordW.Background = new SolidColorBrush(Colors.Red);
                        MessageBox.Show("Неправильно введен пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                    if (teachers == null)
                    {
                        LoginW.Background = new SolidColorBrush(Colors.Red);
                        PasswordW.Background = new SolidColorBrush(Colors.Red);
                        MessageBox.Show("Для входа нужно заполнить обе строки!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        if (teachers.Password.Equals(pass))
                        {
                            Kek = 2;
                            id = teachers.id;
                            LoginW.Background = new SolidColorBrush(Colors.Green);
                            PasswordW.Background = new SolidColorBrush(Colors.Green);
                            MessageBox.Show("Пароль верный! Выполняется вход!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                            Window1 window1 = new Window1(teachers, pupil, this, Kek, id);
                            window1.Show();
                        }
                        else
                        {
                            PasswordW.Background = new SolidColorBrush(Colors.Red);
                            MessageBox.Show("Неправильно введен пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }

                }


            }
            catch (FormatException)
            {
                LoginW.Background = new SolidColorBrush(Colors.Red);
                PasswordW.Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Неверно введен логин!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}

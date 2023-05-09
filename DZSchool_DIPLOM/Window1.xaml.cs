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

namespace DZSchool_DIPLOM
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SchoolDZEntities context;
        MainWindow mainWindow;
        SchoolDZEntities cont;
        Pupil pupl;
        Teachers teacher;
        public Window1(Teachers teachers, Pupil pupil, MainWindow mainWindow, int kek, int id)
        {
            InitializeComponent();
            context = new SchoolDZEntities();

            if (kek == 1)
            {
                context = cont;
                pupl = pupil;
                NameLabel.Content = pupil.Fio.ToString();
            }
            else
            {
                context = cont;
                teacher = teachers;
                NameLabel.Content = teacher.Fio.ToString();
            }

        }

        private void StartTest(object sender, RoutedEventArgs e)
        {

        }

        private void ShowPupils(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new PupilsPage());
        }

        private void StatRequest(object sender, RoutedEventArgs e)
        {

        }

        private void StatPupilRequest(object sender, RoutedEventArgs e)
        {

        }

        private void StartGameDz(object sender, RoutedEventArgs e)
        {
            Game game1 = new Game();
            game1.Show();
        }

        private void ShowTimeTable(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new TimeTablePage());
        }

        private void ProfilButton(object sender, RoutedEventArgs e)
        {
            Pupil pupil = this.pupl;
            int NeedId = this.pupl.id;
            MastersFrame.Navigate(new ProfilePage(pupil, NeedId));
        }
    }
}

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
    /// Логика взаимодействия для PupilsPage.xaml
    /// </summary>
    public partial class PupilsPage : Page
    {
        SchoolDZEntities context;
        public PupilsPage()
        {
            InitializeComponent();
            context = new SchoolDZEntities();
            MastersGrid.ItemsSource = context.Pupil.ToList();
        }
        public void Refresher()
        {
            var list = context.Pupil.ToList();
            if (!string.IsNullOrWhiteSpace(MasterFIObox.Text))
            {
                list = list.Where(x => x.Fio.ToLower().Contains(MasterFIObox.Text.ToLower())).ToList();
            }
            MastersGrid.ItemsSource = list;
        }

        private void DeleteMaster(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить данного ученика?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Pupil pupil = MastersGrid.SelectedItem as Pupil;
                    context.Pupil.Remove(pupil);
                    context.SaveChanges();
                    NavigationService.Navigate(new PupilsPage());                
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void FIOchanged(object sender, TextChangedEventArgs e)
        {
            Refresher();
        }

        private void AddMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPupil(context));
        }

        private void EditMaster(object sender, RoutedEventArgs e)
        {
            Pupil pupil = MastersGrid.SelectedItem as Pupil;
            NavigationService.Navigate(new AddPupil(context, pupil));
        }
    }
}

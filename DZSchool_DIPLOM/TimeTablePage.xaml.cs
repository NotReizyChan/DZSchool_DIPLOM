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
    /// Логика взаимодействия для TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        SchoolDZEntities context;
        public TimeTablePage()
        {
            InitializeComponent();
            context = new SchoolDZEntities();
            MastersGrid.ItemsSource = context.TimeTable.ToList();
        }

        public void Refresher()
        {
            var list = context.TimeTable.ToList();
            if (!string.IsNullOrWhiteSpace(MasterFIObox.Text))
            {
                list = list.Where(x => x.Class.ToLower().Contains(MasterFIObox.Text.ToLower())).ToList();
            }
            MastersGrid.ItemsSource = list;
        }


        private void AddTimetable(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTimeTable(context));
        }

        private void EditTimetable(object sender, RoutedEventArgs e)
        {
            TimeTable timeTable = MastersGrid.SelectedItem as TimeTable;
            NavigationService.Navigate(new AddTimeTable(context, timeTable));
        }

        private void DeleteTimetable(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить данный урок?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    TimeTable timeTable = MastersGrid.SelectedItem as TimeTable;
                    context.TimeTable.Remove(timeTable);
                    context.SaveChanges();
                    NavigationService.Navigate(new TimeTablePage());
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void ClassChanged(object sender, TextChangedEventArgs e)
        {
            Refresher();
        }
    }
}

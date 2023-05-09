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
    /// Логика взаимодействия для AddTimeTable.xaml
    /// </summary>
    public partial class AddTimeTable : Page
    {
        bool flag; //добавить - true, редактировать - false
        SchoolDZEntities context;
        public AddTimeTable(SchoolDZEntities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }
        TimeTable timeTable;
        private void SaveMaster(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                TimeTable timeTable = new TimeTable()
                {
                    id = Convert.ToInt32(id.Text),
                    idSubject = (SubjectMasbox.SelectedItem as subjects).id,
                    Class = Convert.ToString(ClassBox.SelectedItem),
                    Classroom = Classroom.Text,
                };
                context.TimeTable.Add(timeTable);
                context.SaveChanges();
                NavigationService.Navigate(new TimeTablePage());
            }
            else
            {
                context.TimeTable.Find(timeTable.id).id = Convert.ToInt32(id.Text);
                context.TimeTable.Find(timeTable.id).idSubject = (SubjectMasbox.SelectedItem as subjects).id;
                context.TimeTable.Find(timeTable.id).Class = Convert.ToString(ClassBox.SelectedItem);
                context.TimeTable.Find(timeTable.id).Classroom = Classroom.Text;
                context.SaveChanges();
                NavigationService.Navigate(new TimeTablePage());
            }
        }
        public AddTimeTable(SchoolDZEntities cont, TimeTable timeTable)//контструктор редактирования 
        {
            InitializeComponent();
            context = cont;
            id.Text = Convert.ToString(id);
            SubjectMasbox.ItemsSource = context.subjects.ToList();
            ClassBox.ItemsSource = context.Classes.ToList();
            Classroom.Text = timeTable.Classroom.ToString();
            flag = false;
        }
    }
}

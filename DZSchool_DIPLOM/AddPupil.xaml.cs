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
    /// Логика взаимодействия для AddPupil.xaml
    /// </summary>
    public partial class AddPupil : Page
    {
        bool flag; //добавить - true, редактировать - false
        SchoolDZEntities context;
        public AddPupil(SchoolDZEntities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }

        Pupil pupl;


        private void SaveMaster(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Pupil pupil = new Pupil()
                {
                    id = Convert.ToInt32(TABNOMbox.Text),
                    idMarks = Convert.ToInt32(Marksbox.Text),
                    AvgMarks = Convert.ToDouble(AvgMarksbox.Text),
                    Fio = FIObox.Text,
                    idInf = Convert.ToInt32(idinfbox.Text),
                    FatherFio = Fatherbox.Text,
                    MotherFio = Motherbox.Text,
                    Password = Passwordbox.Text,
                };
                context.Pupil.Add(pupil);
                context.SaveChanges();
                NavigationService.Navigate(new PupilsPage());
            }
            else
            {
                context.Pupil.Find(pupl.id).Fio = FIObox.Text;
                context.Pupil.Find(pupl.id).idMarks = Convert.ToInt32(Marksbox.Text);
                context.Pupil.Find(pupl.id).AvgMarks = Convert.ToDouble(AvgMarksbox.Text);
                context.Pupil.Find(pupl.id).idInf = Convert.ToInt32(idinfbox.Text);
                context.Pupil.Find(pupl.id).FatherFio = Fatherbox.Text;
                context.Pupil.Find (pupl.id).MotherFio = Motherbox.Text;
                context.Pupil.Find(pupl.id).Password = Passwordbox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new PupilsPage());
            }
        }
        public AddPupil(SchoolDZEntities cont, Pupil pupil)//контструктор редактирования 
        {
            InitializeComponent();
            context = cont;
            pupl = pupil;
            idinfbox.Text = pupil.id.ToString();
            FIObox.Text = pupil.Fio.ToString();
            AvgMarksbox.Text = pupil.AvgMarks.ToString();
            Marksbox.Text = pupil.idMarks.ToString();
            idinfbox.Text = pupil.idInf.ToString();
            Fatherbox.Text = pupil.FatherFio.ToString();
            Motherbox.Text = pupil.MotherFio.ToString();
            Passwordbox.Text = pupil.Password.ToString();
            flag = false;
        }

        double Mark = 0;
        double resultMark = 0;
        double step = 0;
        private void ForMarksClick(object sender, RoutedEventArgs e)
        {
            Mark = Convert.ToDouble(markbox.Text);
            resultMark += Mark;
            step += 1;
            markbox.Text ="";
            ResultBlock.Text = Convert.ToString(resultMark);
        }

        private void ForResult(object sender, RoutedEventArgs e)
        {
            resultMark /= step;
            ResultBlock.Text = Convert.ToString(resultMark);
        }

        private void ForDelete(object sender, RoutedEventArgs e)
        {
            ResultBlock.Text = "";
            markbox.Text = "";
            step = 0;
            resultMark = 0;
            Mark = 0;
        }
    }
}

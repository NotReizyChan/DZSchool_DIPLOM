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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        SchoolDZEntities context;
        public ProfilePage(Pupil pupil, int id)
        {
            InitializeComponent();
            context = new SchoolDZEntities();
            pupil = pupil;
            PupilFio.Content = pupil.Fio.ToString();
            Lvl.Content = pupil.AvgMarks.ToString();
            lvlbar.Value = Convert.ToDouble(pupil.AvgMarks.ToString());
            double reward = Convert.ToDouble(pupil.AvgMarks.ToString());
            Image myImage = new Image();
            myImage.Width = 200;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();

            if (reward <= 2)
            {
                Reward.Text = "Старайся лучше!";
                RewardName.Text = "К сожалению ты ничего не получаешь";
                myBitmapImage.UriSource = new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\rewards\nothing.jpg");
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
            }
            else
                if ((reward > 2) && (reward <= 3))
            {
                Reward.Text = "Ты можешь лучше, но в конце месяца получишь конфетку";
                RewardName.Text = "Твоя награда - конфетка";
                myBitmapImage.UriSource = new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\rewards\sweet.jpg");
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
            }
            else if ((reward > 3) && (reward <= 4))
            {
                Reward.Text = "Ты молодец, но еще есть куда расти, в конце месяца ты получишь набор для учебы";
                RewardName.Text = "Твоя награда - набор из: 2 тетради 48 листов, ручка синяя c дизайном на выбор!";
                myBitmapImage.UriSource = new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\rewards\copybookANDpen.jpg");
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
            }
            else if (reward > 4)
            {
                Reward.Text = "Ты просто бог учебы, мои поздравления, в конце месяца ты получишь билет в кино или в театр на выбор";
                RewardName.Text = "Твоя награда - один билет в кино или театр (на твой выбор), и фильм, оперу или балет выбираешь ты! Поздравляю!";
                myBitmapImage.UriSource = new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\rewards\tickets.jpg");
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.EndInit();
            }
            myImage.Source = myBitmapImage;
        }
    }
}

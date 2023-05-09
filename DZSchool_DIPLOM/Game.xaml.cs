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
using System.Collections;
using System.ComponentModel;

namespace DZSchool_DIPLOM
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            var lst = new BindingList<BitmapImage>();
            lst.Add(new BitmapImage(new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\puzzle\Pic1.jpg")));
            lst.Add(new BitmapImage(new Uri(@"C:\Users\arbuz\source\repos\DZSchool_DIPLOM\res\puzzle\Pic2.jpg")));
            this.DataContext = lst;
        }
        Point startPoint;
        string format = "image";
        void DragList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        void DragList_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (Math.Abs(diff.X) <= SystemParameters.MinimumHorizontalDragDistance
             && Math.Abs(diff.Y) <= SystemParameters.MinimumVerticalDragDistance)
                return;
            var lst = sender as ListBox;
            var li = FindAnchestor<ListBoxItem>((DependencyObject)e.OriginalSource);
            if (li == null) return;
            var img = lst.ItemContainerGenerator.ItemFromContainer(li);
            var data = new DataObject(format, img);
            var res = DragDrop.DoDragDrop(li, data, DragDropEffects.All);
            if (res == DragDropEffects.Move)
                (lst.ItemsSource as IList).Remove(img);
        }
        void Canvas_Drop(object sender, DragEventArgs e)
        {
            var img = new Image()
            {
                Source = e.Data.GetData(format) as BitmapImage,
                MaxHeight = 100,
                MaxWidth = 100
            };
            var c = sender as Canvas;
            var p = e.GetPosition(c);
            Canvas.SetLeft(img, p.X);
            Canvas.SetTop(img, p.Y);
            c.Children.Insert(0, img);
            e.Effects = DragDropEffects.Move;
        }
        void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(format))
                e.Effects = DragDropEffects.Move;
        }
        static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T) return (T)current;
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }
}

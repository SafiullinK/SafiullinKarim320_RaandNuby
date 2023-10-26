using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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
using Microsoft.Win32;
using SafiullinKarim320_RaandNuby.DB;

namespace SafiullinKarim320_RaandNuby.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindowforNuby.xaml
    /// </summary>
    public partial class MainWindowforNuby : Page
    {
        public static List<Sobachka_Nuby> nuby { get; set; }
        public MainWindowforNuby()
        {
            InitializeComponent();
            nuby = new List<Sobachka_Nuby>(Connection.raAndNubyEntities.Sobachka_Nuby.ToList());
            this.DataContext = this;
            NubyLv.ItemsSource = new List<Sobachka_Nuby>(Connection.raAndNubyEntities.Sobachka_Nuby.ToList());

        }


        Sobachka_Nuby nuby1 = new Sobachka_Nuby();
        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                nuby1.Image = File.ReadAllBytes(openFileDialog.FileName);
                TestImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void AddNuby_Click(object sender, RoutedEventArgs e)
        {
            nuby1.deystv = deystv.Text;
            Connection.raAndNubyEntities.Sobachka_Nuby.Add(nuby1);
            Connection.raAndNubyEntities.SaveChanges();
            NubyLv.ItemsSource = new List<Sobachka_Nuby>(Connection.raAndNubyEntities.Sobachka_Nuby.ToList());
        }

        private void AddRa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainWindowforRa());
            MessageBox.Show("Добро пожаловать к Нуби Деля!!");
        }

        private void FiltrTb_TextChanged(object sender, TextChangedEventArgs e)
        {
                if(FiltrTb.Text.Length > 0)
                NubyLv.ItemsSource = Connection.raAndNubyEntities.Sobachka_Nuby.Where(i => i.deystv.Contains(FiltrTb.Text.Trim())).ToList();
                else
                NubyLv.ItemsSource = new List<Sobachka_Nuby>(Connection.raAndNubyEntities.Sobachka_Nuby.ToList());
        }

        private void RaOrNubyCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RaOrNubyCb.SelectedIndex == 1)
            {
                NavigationService.Navigate(new MainWindowforRa());
                MessageBox.Show("А вот вам и красавчик Ра!!"); 
            }
        }
    }
}

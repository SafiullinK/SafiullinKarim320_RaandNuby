using Microsoft.Win32;
using SafiullinKarim320_RaandNuby.DB;
using System;
using System.Collections.Generic;
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

namespace SafiullinKarim320_RaandNuby.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindowforRa.xaml
    /// </summary>
    public partial class MainWindowforRa : Page
    {   public static List<Kotenok_Ra> ra = new List<Kotenok_Ra>();
        public MainWindowforRa()
        {
            InitializeComponent();
            this.DataContext = this;
            RaLv.ItemsSource = new List<Kotenok_Ra>(Connection.raAndNubyEntities.Kotenok_Ra.ToList());

        }

        Kotenok_Ra ra1 = new Kotenok_Ra();
        private void AddRa_Click(object sender, RoutedEventArgs e)
        {
            ra1.deystv = deystv.Text;
            Connection.raAndNubyEntities.Kotenok_Ra.Add(ra1);
            Connection.raAndNubyEntities.SaveChanges();
            RaLv.ItemsSource = new List<Kotenok_Ra>(Connection.raAndNubyEntities.Kotenok_Ra.ToList());
        }

        private void AddNuby_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainWindowforNuby());
            MessageBox.Show("Добро пожаловать к Ра Андрей!!"); 
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                ra1.Image = File.ReadAllBytes(openFileDialog.FileName);
                TestImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void FiltrTb_TextChanged(object sender, TextChangedEventArgs e)
        { 
            if (FiltrTb.Text.Length > 0) 
            RaLv.ItemsSource = Connection.raAndNubyEntities.Kotenok_Ra.Where(i => i.deystv.Contains(FiltrTb.Text.Trim())).ToList(); 
            else
            RaLv.ItemsSource = new List<Kotenok_Ra>(Connection.raAndNubyEntities.Kotenok_Ra.ToList());

        }

        private void RaOrNubyCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RaOrNubyCb.SelectedIndex == 1)
            {
                NavigationService.Navigate(new MainWindowforNuby());
                MessageBox.Show("А вот вам и красавчик Нуби!!");
            }
        }
    }
}

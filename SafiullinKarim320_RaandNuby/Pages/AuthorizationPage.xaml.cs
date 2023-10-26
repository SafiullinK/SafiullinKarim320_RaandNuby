using SafiullinKarim320_RaandNuby.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        public static List<User> users = new List<User>();
        private void OpenBt_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string Password = PasswordTb.Password.Trim();
            users = new List<User>(Connection.raAndNubyEntities.User.ToList());
            User user = users.FirstOrDefault(i => i.Login == login && i.Password == Password);
            if ( user != null && user.Id_user == 1)
            {
                MessageBox.Show("Добро пожаловать "+ user.Name);
                NavigationService.Navigate(new MainWindowforRa());
            }
            else if (user != null && user.Id_user == 2)
            {
                MessageBox.Show("Добро пожаловать " + user.Name);
                NavigationService.Navigate(new MainWindowforNuby());
            }
            else
            {
                MessageBox.Show("Что-то пошло не по плану");
                LoginTb.Text = "";
                PasswordTb.Password = "";
            }
            //string login = loginTb.Text.Trim();
            //string password = passwordTb.Password.Trim();
            //employees = new List<Employee>(DbConnection.parisEntities.Employee.ToList());
            //Employee currentUser = employees.FirstOrDefault(i => i.Login == login && i.Password == password);
            //if (currentUser != null)
            //{
            //    NavigationService.Navigate(new MainMenuPage(currentUser));
            //}
            //else
            //{
            //    var dan = "Перейдем на страницу регистрации?";
            //    if (MessageBox.Show(dan, "Неправильный логин или пароль", MessageBoxButton.YesNo) == MessageBoxResult.No)
            //    {
            //        loginTb.Text = "";
            //        passwordTb.Password = "";
            //    }
            //    else
            //    {
            //        NavigationService.Navigate(new RegestrationPage());
            //    }
            //}
        }
    }
}

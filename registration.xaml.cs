using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();
            reg.Show();
            this.Hide();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Hide();

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {

            var login = LoginBox.Text;

            var pass =PasswordBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (login.Length == 0)
            {
                MessageBox.Show("Введите логин!");
                return;
            }
            if(pass.Length == 0)
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            if (user_exists is not null) 
            {
                MessageBox.Show("Такой пользователь уже в клубе крутышек");
                return;
            }
            var user = new user { Login = login, Password = pass };
            context.Users.Add(user);    
            context.SaveChanges();
            MessageBox.Show("Welcome to the club,buddy");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

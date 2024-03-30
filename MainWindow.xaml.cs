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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();
            reg.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }


        private void login_Click(object sender, RoutedEventArgs e)
        {
            var login =loginbox.Text;
            var password = PasswordBox.Text;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт");
        }

        
    }
}

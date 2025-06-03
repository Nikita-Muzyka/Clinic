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
using Clinic.Doctor;

namespace Clinic
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private MainWindow mainWindow;

        private string _login;
        private string _password;

        private bool loginCheck;
        private bool passwordCheck;


        public Registration()
        {
            InitializeComponent();
        }

        private void LogIn_Button(object sender, RoutedEventArgs e)
        {
            _login = Login.Text;
            _password = PasswordBoxCheck();
            loginCheck = CheckLogin();
            passwordCheck = CheckPassword();
            AcceptReg();
        }

        /// <summary>
        /// Проверка откуда брать данные пароля
        /// </summary>
        /// <returns></returns>
        string PasswordBoxCheck()
        {
            if (Password.Visibility == Visibility.Collapsed)
            {
                return Password_Box.Text;
            }
            else
            {
                return Password.Password;
            }
        }
        bool CheckLogin() 
        {
            using (var db = new ClinicContext())
            {
                var login = db.Workers.Any(u => u.infoReg.Login == _login);
                if (login != null)
                {
                    Database.Instance.Worker = db.Workers.FirstOrDefault(u => u.infoReg.Login == _login);
                }
                if (login == false)
                {
                    Verification.Visibility = Visibility.Visible;
                }

                return login;
            }
        }
        bool CheckPassword()
        {
            using (var db = new ClinicContext())
            {
                var password = db.Workers.Any(u => u.infoReg.Password == _password);
                if (password == false)
                {
                    Verification.Visibility = Visibility.Visible;
                    //return db.Admins.Any(u => u.infoReg.Password == _password);
                }
                return password;
            }
        }

        void AcceptReg()
        {
            if (loginCheck == true && passwordCheck == true)
            {
                mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
            else
            {
                Verification.Visibility = Visibility.Visible;
            }
        }

        private void FucusOnPassword_Button(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Password.Visibility == Visibility.Collapsed)
                {
                    Password_Box.Focus();
                }
                else
                {
                    Password.Focus();
                }
            }
        }

        private void FucusOnEntrance_Button(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Entrance.Focus();
                Entrance.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Login_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "Login")
            {
                Login.Text = "";
            }
        }

        private void Login_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "Login";
            }
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Button(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                Password_Box.Visibility = Visibility.Visible;
                Password_Box.Text = Password.Password;
                Password.Visibility = Visibility.Collapsed;
            }
            else
            {
                Password.Visibility = Visibility.Visible;
                Password.Password = Password_Box.Text;
                Password_Box.Visibility = Visibility.Collapsed;
            }
        }

        private void MouseDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

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
        public Worker work;

        private string _login;
        private string _password;

        private bool loginCheck;
        private bool passwordCheck;

        public delegate void regTrue(); // делегает для запуска события в mainwindows
        public event regTrue MyEvent; // Event на основе делегата regTrue для запуска события в mainwindows

        public Registration()
        {
            InitializeComponent();
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogIn_Button(object sender, RoutedEventArgs e)
        {
            _login = Login.Text;
            _password = Password.Text;
            loginCheck = CheckLogin();
            passwordCheck = CheckPassword();
            AcceptReg();
        }

        bool CheckLogin()
        {
            using (var db = new ClinicContext())
            {
                var login = db.Workers.Any(u => u.infoReg.Login == _login);
                if (login != null)
                {
                    work = db.Workers.FirstOrDefault(u => u.infoReg.Login == _login);
                }
                if (login == false)
                {
                    return db.Admins.Any(u => u.infoReg.Login == _login);
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
                    return db.Admins.Any(u => u.infoReg.Password == _password);
                }
                return password;
            }
        }

        void AcceptReg()
        {
            if (loginCheck == true && passwordCheck == true)
            {
                MyEvent.Invoke();
                this.Close();
            }
            else
            {
                Verification.Visibility = Visibility.Visible;
            }
        }
    }
}

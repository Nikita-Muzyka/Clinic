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
        private string _login;
        private string _password;

        private bool loginAccept;
        private bool passwordAccept;

        public delegate void regTrue(); // делегает для запуска события в mainwindows

        public event regTrue MyEvent; // Event на основе делегата regTrue для запуска события в mainwindows
        public Registration()
        {
            InitializeComponent();
            //DoctorsPassword pass1 = new DoctorsPassword
            //{
            //    Id = 1,
            //    Login = "11",
            //    Password = "22"
            //};
            //Doctors doc1 = new Doctors
            //{
            //    Id = 1,
            //    FirstName = "Foo",
            //    LastName = "Bar",
            //    Salary = "20000",
            //    Title = "Title",
            //    infoReg = pass1
            //};
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogIn_Button(object sender, RoutedEventArgs e)
        {
            _login = Login.Text;
            _password = Password.Text;
            loginAccept= CheckLogin();
            passwordAccept = CheckPassword();
            AcceptReg();
        }

        bool CheckLogin()
        {
            using (var db = new DoctorsContext())
            {
                return db.Doctors.Any(u => u.infoReg.Login == _login);
            }
        }
        bool CheckPassword()
        {
            using (var db = new DoctorsContext())
            {
                return db.Doctors.Any(u => u.infoReg.Password == _password);
            }
        }

        void AcceptReg()
        {
            if (loginAccept == true && passwordAccept == true)
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

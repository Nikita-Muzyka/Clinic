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

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Change_tb();
        }
        void Change_tb()
        {
            TitleWorker tl1 = new TitleWorker
            {
                Id = 1,
                AccessTitle = 1,
                NameTitle = "Doctor"
            };
            PeopleRegistration reg1 = new PeopleRegistration
            {
                Id = 1,
                Login = "11",
                Password = "119"
            };
            ClinicPersonal work1 = new Worker
            {
                Id = 1,
                FirstName = "DIma",
                LastName = "Sosin",
                Salary = "10000",
                Age = 20,
                Title = tl1,
                infoReg = reg1
            };

            FirstNameWorker.Text = work1.FirstName;
            LastNameWorker.Text = work1.LastName;
            AgeWorker.Text = work1.Age.ToString();

        }
    }
}

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
using Clinic.Doctor;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ClinicPerson worker = Database.Instance.Worker;
        public MainPage()
        {
            InitializeComponent();
            Change_tb();
        }
        void Change_tb()
        {
            FirstNameWorker.Text = worker.FirstName;
            LastNameWorker.Text = worker.LastName;
            AgeWorker.Text = worker.Age.ToString();
        }
    }
}







//    //TitleWorker tl1 = new TitleWorker
//    //{
//    //    AccessTitle = 1,
//    //    NameTitle = "Doctor"
//    //};
//    //PeopleRegistration reg1 = new PeopleRegistration
//    //{
//    //    Login = "11",
//    //    Password = "11"
//    //};
//    //PeopleRegistration reg2 = new PeopleRegistration
//    //{
//    //    Id = 1,
//    //    Login = "55",
//    //    Password = "55"
//    //};
//    //Worker work1 = new Worker
//    //{
//    //    FirstName = "DIma",
//    //    LastName = "Sosin",
//    //    Salary = "10000",
//    //    Age = 20,
//    //    Title = tl1,
//    //    infoReg = reg1
//    //};

//    //Administrator admin = new Administrator
//    //{
//    //    FirstName = "admin",
//    //    infoReg = reg1
//    //};
//    //using (ClinicContext db = new ClinicContext())
//    //{
//    //    db.Admins.Add(admin);
//    //    db.Workers.Add(work1);
//    //    db.SaveChanges();
//    //}

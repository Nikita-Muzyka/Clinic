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
    /// Логика взаимодействия для ReceptionPage.xaml
    /// </summary>
    public partial class ReceptionPage : Page
    {
        private List<ClinicPerson> patientList = new List<ClinicPerson>();
        private ClinicPerson worker;
        public ReceptionPage(ClinicPerson work)
        {
            InitializeComponent();
            this.worker = work;
            for (int i = 0; i < Database.Instance.Appos.Count;i++)
            {
                if (Database.Instance.Appos[i].Workers.Id == worker.Id)
                {
                    patientList.Add(Database.Instance.Appos[i].Patients);
                }
            }
            ListB.ItemsSource = patientList;
        }

    }

}

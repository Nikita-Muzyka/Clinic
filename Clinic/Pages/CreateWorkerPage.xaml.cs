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
    /// Логика взаимодействия для CreateWorkerPage.xaml
    /// </summary>
    public partial class CreateWorkerPage : Page
    {
        WorkerValidation workerValid = new WorkerValidation();
        Dictionary<string, string> Errors;
        public CreateWorkerPage()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = roleBox.SelectedValue as string;
            ErrorsClear();
            Errors = workerValid.Validation(
                firstNameBox.Text,
                lastNameBox.Text,
                patronymicBox.Text,
                datebirthBox.Text,
                genderBox.Text,
                phoneBox.Text,
                emailBox.Text,
                placeBox.Text,
                roleBox.SelectionBoxItem as string,
                logBox.Text,
                passBox.Text);
            CheckErrors();

        }
        private void CheckErrors()
        {
            if (Errors.Count > 0)
            {
                foreach (var err in Errors)
                {
                    var control = this.FindName(err.Key) as Control;
                    if (control != null)
                    {
                        control.BorderBrush = new SolidColorBrush(Colors.Red);
                        control.ToolTip = err.Value;
                    }
                }
            }
        }
        private void ErrorsClear()
        {
            if (Errors != null)
            {
                foreach (var err in Errors)
                {
                    var control = this.FindName(err.Key) as Control;
                    if (control != null)
                    {
                        control.BorderBrush = new SolidColorBrush(Colors.Green);
                        control.ToolTip = "";
                    }
                }
            }
        }
    }
}

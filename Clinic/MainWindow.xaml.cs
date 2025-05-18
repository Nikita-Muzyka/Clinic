using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool registration = false;
        Registration regWindow = new Registration();
        public MainWindow()
        {
            InitializeComponent();
            regWindow.MyEvent += ChangeReg;
            regWindow.ShowDialog();
            CheckReg();
        }

        void CheckReg()
        {
            if (registration == false)
            {
                this.Close();
            }
        }

        void ChangeReg()
        {
            registration = true;
        }
    }
}
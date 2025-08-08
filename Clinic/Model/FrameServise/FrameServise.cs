using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clinic.Model.FrameServise
{
    internal class FrameServise
    {
        Frame _frame;
        public FrameServise(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<T>() where T : Page, new()
        {
            _frame?.Navigate(new T());  
        }
    }
}

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
        public Frame _Frame;
        public static event Action NavigateEvent;
        public FrameServise(Frame _frame)
        {
            _Frame = _frame;
        }

        public void NavigateTo<T>() where T : Page, new()
        {
            _Frame?.Navigate(new T());
        }
        public void GoBack()
        {
            _Frame?.GoBack();
        }
        public static void NavigateInvoke()
        {
            NavigateEvent?.Invoke();
        }
    }
}

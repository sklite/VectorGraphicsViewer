using System;
using System.Windows.Forms;

namespace GraphicsViewer.Extensions
{
    public static class ControlThreadingExtensions
    {
        public static void Invoke<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
                c.Invoke(new Action(() => action(c)));
            else
                action(c);
        }
    }
}

using System;
using System.Windows.Forms;

namespace SETUNA.Main
{
    internal class FormManager
    {
        public delegate void FormHandler(Form form);

        public static event FormHandler Showed;
        public static event FormHandler Closed;
        public static event FormHandler Activated;
        public static event FormHandler Deactivated;


        public static void RegisterForm(Form form)
        {
            form.Shown += Form_Showed;
            form.FormClosed += Form_Closed;
            form.Activated += Form_Activated;
            form.Deactivate += Form_Deactivated;
        }

        public static void DeregisterForm(Form form)
        {
            form.Shown -= Form_Showed;
            form.FormClosed -= Form_Closed;
            form.Activated -= Form_Activated;
            form.Deactivate -= Form_Deactivated;
        }

        static void Form_Showed(object sender, EventArgs e)
        {
            Showed?.Invoke((Form)sender);
        }

        static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Closed?.Invoke((Form)sender);
        }

        static void Form_Deactivated(object sender, EventArgs e)
        {
            Deactivated?.Invoke((Form)sender);
        }

        static void Form_Activated(object sender, EventArgs e)
        {
            Activated?.Invoke((Form)sender);
        }
    }
}

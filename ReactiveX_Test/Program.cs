using ReactiveX_Test.reactive;
using System;
using System.Windows.Forms;

namespace ReactiveX_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ViewForm());
        }
    }
}

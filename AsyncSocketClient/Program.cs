using System;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    class Program
    {
        private const string exitString = "<EXIT>";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm());
        }
    }
}
